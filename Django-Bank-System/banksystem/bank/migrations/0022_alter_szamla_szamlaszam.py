# Generated by Django 5.1.3 on 2024-11-26 17:10

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ("bank", "0021_alter_szamla_szamlaszam"),
    ]

    operations = [
        migrations.AlterField(
            model_name="szamla",
            name="szamlaszam",
            field=models.CharField(default="1893385274", max_length=20, unique=True),
        ),
    ]