# Generated by Django 5.1.3 on 2024-11-26 18:21

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ("bank", "0034_alter_szamla_szamlaszam"),
    ]

    operations = [
        migrations.AlterField(
            model_name="szamla",
            name="szamlaszam",
            field=models.CharField(default="4216840486", max_length=20, unique=True),
        ),
    ]
