from django.urls import path
from . import views

urlpatterns = [
    path('', views.bejelentkezes, name='bejelentkezes'),
    path('regisztracio/', views.regisztracio, name='regisztracio'),
    path('kijelentkezes/', views.kijelentkezes, name='kijelentkezes'),
    path('attekintes/', views.szamla_attekintes, name='szamla_attekintes'),
    path('penz_feltoltes/', views.penz_feltoltes, name='penz_feltoltes'),
    path('penz_levetel/', views.penz_levetel, name='penz_levetel'),
    path('penz_utalas/', views.penz_utalas, name='penz_utalas'),
    path('tranzakcio/', views.tranzakcio, name='tranzakcio'),
]
