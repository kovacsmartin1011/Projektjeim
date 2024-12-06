from django.db import models
from django.contrib.auth.models import User
import uuid

class Szamla(models.Model):
    felhasznalo = models.OneToOneField(User, on_delete=models.CASCADE, related_name='szamla')
    szamlaszam = models.CharField(max_length=20, unique=True, default=str(uuid.uuid4().int)[:10])
    egyenleg = models.DecimalField(max_digits=12, decimal_places=2, default=0)
    letrehozas_datum = models.DateTimeField(auto_now_add=True)
    
    def __str__(self):
        return f'{self.felhasznalo.username} - {self.szamlaszam}'
    
    def penz_feltoltes(self, osszeg):
        if osszeg <= 0:
            raise ValueError("A feltöltés összege nem lehet nulla vagy negatív!")
        self.egyenleg += osszeg
        self.save()
        
        Tranzakcio.objects.create(
            szamla=self,
            tranzakcio_tipus='feltöltés',
            osszeg=osszeg,
            kategoria='Pénzfeltöltés',
    )
        
    def penz_levetel(self, osszeg):
        if osszeg < 1000:
            raise ValueError("A levétel összege minimum 1000 HUF!")
        if osszeg > self.egyenleg:
            raise ValueError("Nincs elegendő egyenleg.")
        self.egyenleg -= osszeg
        self.save()
        
        Tranzakcio.objects.create(
            szamla=self,
            tranzakcio_tipus='levétel',
            osszeg=osszeg,
            kategoria='Pénzlevétel',
        )
        
    def penz_utalas(self, cel_szamlaszam, osszeg, kategoria=None):
        if osszeg <= 0:
            raise ValueError("Az utalás összege nem lehet nulla vagy negatív!")
        if osszeg > self.egyenleg:
            raise ValueError("Nincs elegendő egyenleg az utaláshoz.")
        
        try:
            cel_szamlaszam = Szamla.objects.get(szamlaszam=cel_szamlaszam)
        except Szamla.DoesNotExist:
            raise ValueError("A cél számlaszám nem létezik.")
        
        if self.szamlaszam == cel_szamlaszam:
            raise ValueError("Saját számlaszámra nem lehet utalni!")
        
        self.egyenleg -= osszeg
        self.save()
        
        cel_szamlaszam.egyenleg += osszeg
        cel_szamlaszam.save()
        
        if kategoria:
            Tranzakcio.objects.create(
                szamla=self,
                tranzakcio_tipus='utalás',
                osszeg=osszeg,
                kategoria=kategoria
            )
        
        return f"Sikeresen utaltál {osszeg} összeget a(z) {cel_szamlaszam} számlaszámra."

class Tranzakcio(models.Model):
    TRANZAKCIOK = (
        ('feltöltés', 'Feltöltés'),
        ('levétel', 'Levétel'),
        ('utalás', 'Utalás'),    
    )
    
    TRANZAKCIO_KATEGORIAK = (
        ('közelkedés', 'Közlekedés'),
        ('szórakozás', 'Szórakozás'),
        ('egészség', 'Egészség'),
        ('otthon', 'Otthon'),
        ('ruházat', 'Ruházat'),
        ('egyéb', 'Egyéb'),
        ('bevásárlás', 'Bevásárlás'),
        ('adomány', 'Adomány'),
        ('vendéglátás', 'Vendéglátás'),
        ('utazás', 'Utazás'),

    )
    
    szamla = models.ForeignKey(Szamla, on_delete=models.CASCADE)
    tranzakcio_tipus = models.CharField(max_length=20, choices=TRANZAKCIOK)
    tranzakcio_datum = models.DateTimeField(auto_now_add=True)
    osszeg = models.DecimalField(max_digits=10, decimal_places=2)
    kategoria = models.CharField(max_length=50, choices=TRANZAKCIO_KATEGORIAK, default='egyéb')
    
    def __str__(self):
        return f'{self.tranzakcio_tipus} - {self.osszeg} ({self.kategoria})'