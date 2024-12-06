from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User
from django import forms
from django.shortcuts import render
from .models import Szamla, Tranzakcio

class RegisztracioForm(UserCreationForm):
    email = forms.EmailField(required=True)
    
    class Meta:
        model = User
        fields = ['username', 'email', 'password1', 'password2']
        
    def save(self, commit=True):
        user = super().save(commit=False)
        user.email = self.cleaned_data['email']
        if commit:
            user.save()
        return user

class PenzMuvForm(forms.Form):
    osszeg = forms.DecimalField(max_digits=12, decimal_places=2, min_value=0.01)

class UtalasForm(forms.Form):
    cel_szamlaszam = forms.CharField(max_length=20)
    osszeg = forms.DecimalField(max_digits=12, decimal_places=2, min_value=0.01)
    kategoria = forms.ChoiceField(choices=Tranzakcio.TRANZAKCIO_KATEGORIAK, initial='egyéb')