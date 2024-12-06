from django.contrib import admin
from .models import Szamla

@admin.register(Szamla)
class SzamlaAdmin(admin.ModelAdmin):
    list_display = ('felhasznalo', 'szamlaszam', 'egyenleg')
    search_fields = ('felhasznalo__username', 'szamlaszam')
