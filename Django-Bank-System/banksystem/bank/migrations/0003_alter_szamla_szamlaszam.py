# Generated by Django 5.1.3 on 2024-11-25 15:52

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('bank', '0002_alter_szamla_szamlaszam'),
    ]

    operations = [
        migrations.AlterField(
            model_name='szamla',
            name='szamlaszam',
            field=models.CharField(default='1385976005', max_length=20, unique=True),
        ),
    ]