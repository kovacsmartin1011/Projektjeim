from django.shortcuts import get_object_or_404, render, redirect
from django.contrib.auth import login, logout, authenticate
from django.contrib.auth.forms import AuthenticationForm
from django.contrib import messages
from django.http import HttpResponse
from reportlab.lib.pagesizes import letter
from .forms import RegisztracioForm, PenzMuvForm, UtalasForm
from .models import Szamla, Tranzakcio
from django.contrib.auth.decorators import login_required
import random
import string

def generate_szamlaszam():
    return ''.join(random.choices(string.digits, k=16))

def home(request):
    return render(request, 'bejelentkezes.html')

def regisztracio(request):
    if request.method == 'POST':
        form = RegisztracioForm(request.POST)
        if form.is_valid():
            user = form.save()
            szamla = Szamla(felhasznalo=user, szamlaszam=generate_szamlaszam(), egyenleg=0)
            szamla.save()
            login(request, user)
            messages.success(request, "Sikeresen regisztráltál!")
            return redirect('szamla_attekintes')
    else:
        form = RegisztracioForm()
    return render(request, 'regisztracio.html', {'form': form})

def bejelentkezes(request):
    if request.method == 'POST':
        form = AuthenticationForm(data=request.POST)
        if form.is_valid():
            user = form.get_user()
            login(request, user)
            messages.success(request, "Sikeresen bejelentkeztél!")
            return redirect('szamla_attekintes')
    else:
        form = AuthenticationForm()
    return render(request, 'bejelentkezes.html', {'form': form})

def kijelentkezes(request):
    logout(request)
    messages.success(request, "Sikeresen kijelentkeztél!")
    return redirect('bejelentkezes')

def osszes_felhasznalo_torlese(request):
    if request.user.is_superuser:
        Szamla.objects.all().delete()
        messages.success(request, "Az összes felhasználó törlésre került!")
    else:
        messages.error(request, "Nincs jogosultságod felhasználót törölni!")
    return redirect('home')

@login_required
def penz_feltoltes(request):
    form = PenzMuvForm(request.POST or None)
    if form.is_valid():
        osszeg = form.cleaned_data['osszeg']
        szamla = request.user.szamla
        szamla.penz_feltoltes(osszeg)
        messages.success(request, f'Sikeresen feltöltöttél {osszeg} összeget.')
        return redirect('szamla_attekintes')
    return render(request, 'penz_feltoltes.html', {'form': form})

@login_required
def penz_levetel(request):
    form = PenzMuvForm(request.POST or None)
    if form.is_valid():
        osszeg = form.cleaned_data['osszeg']
        szamla = request.user.szamla
        try:
            szamla.penz_levetel(osszeg)
            messages.success(request, f'Sikeresen levettél {osszeg} összeget.')
        except ValueError as e:
            messages.error(request, str(e))
        return redirect('szamla_attekintes')
    return render(request, 'penz_levetel.html', {'form': form})

@login_required
def penz_utalas(request):
    form = UtalasForm(request.POST or None)
    if form.is_valid():
        cel_szamlaszam = form.cleaned_data['cel_szamlaszam']
        osszeg = form.cleaned_data['osszeg']
        kategoria = form.cleaned_data['kategoria']
        szamla = request.user.szamla
        try:
            uzenet = szamla.penz_utalas(cel_szamlaszam, osszeg, kategoria)
            messages.success(request, uzenet)
        except ValueError as e:
            messages.error(request, str(e))
        return redirect('szamla_attekintes')
    return render(request, 'penz_utalas.html', {'form': form})

@login_required
def szamla_attekintes(request):
    szamla = request.user.szamla
    return render(request, 'szamla_attekintes.html', {'szamla': szamla})

@login_required
def tranzakcio(request):
    szamla = request.user.szamla
    tranzakciok = Tranzakcio.objects.filter(szamla=szamla).order_by('-tranzakcio_datum')
    return render(request, 'tranzakcio.html', {'tranzakciok': tranzakciok})