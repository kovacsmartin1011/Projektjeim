﻿using System;
using System.Collections.Generic;
using CSharpBeadando;
using Microsoft.EntityFrameworkCore;

namespace CSharpBeadando.model;

public partial class musorok : DbContext
{
    public musorok()
    {
    }

    public musorok(DbContextOptions<musorok> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kovac\\source\\repos\\CSharpBeadando\\CSharpBeadando\\bin\\Debug\\net8.0-windows\\musorok.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
