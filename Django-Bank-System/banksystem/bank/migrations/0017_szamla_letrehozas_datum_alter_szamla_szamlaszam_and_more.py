# Generated by Django 5.1.1 on 2024-11-26 08:37

import django.db.models.deletion
import django.utils.timezone
from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('bank', '0016_alter_szamla_szamlaszam'),
    ]

    operations = [
        migrations.AddField(
            model_name='szamla',
            name='letrehozas_datum',
            field=models.DateTimeField(auto_now_add=True, default=django.utils.timezone.now),
            preserve_default=False,
        ),
        migrations.AlterField(
            model_name='szamla',
            name='szamlaszam',
            field=models.CharField(default='1890007068', max_length=20, unique=True),
        ),
        migrations.CreateModel(
            name='Tranzakcio',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('tranzakcio_tipus', models.CharField(choices=[('feltöltés', 'Feltöltés'), ('levétel', 'Levétel'), ('utalás', 'Utalás')], max_length=20)),
                ('tranzakcio_datum', models.DateTimeField(auto_now_add=True)),
                ('osszeg', models.DecimalField(decimal_places=2, max_digits=10)),
                ('kategoria', models.CharField(choices=[('közelkedés', 'Közlekedés'), ('szórakozás', 'Szórakozás'), ('egészség', 'Egészség'), ('otthon', 'Otthon'), ('ruházat', 'Ruházat'), ('egyéb', 'Egyéb'), ('bevásárlás', 'Bevásárlás'), ('adomány', 'Adomány'), ('vendéglátás', 'Vendéglátás'), ('utazás', 'Utazás')], default='egyéb', max_length=50)),
                ('szamla', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='bank.szamla')),
            ],
        ),
    ]
