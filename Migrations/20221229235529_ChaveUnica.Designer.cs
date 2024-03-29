﻿// <auto-generated />
using System;
using Biblioteca.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Migrations
{
    [DbContext(typeof(ContextoBD))]
    [Migration("20221229235529_ChaveUnica")]
    partial class ChaveUnica
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Biblioteca.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Biblioteca.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(13,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Biblioteca.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LivrosId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Biblioteca.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("Biblioteca.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.Property<int>("PerfilsId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("PerfilsId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("PerfilUsuario");
                });

            modelBuilder.Entity("Biblioteca.Models.Endereco", b =>
                {
                    b.HasOne("Biblioteca.Models.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("Biblioteca.Models.Endereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca.Models.Livro", b =>
                {
                    b.HasOne("Biblioteca.Models.Pedido", "Pedido")
                        .WithMany("Livros")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Biblioteca.Models.Pedido", b =>
                {
                    b.HasOne("Biblioteca.Models.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.HasOne("Biblioteca.Models.Perfil", null)
                        .WithMany()
                        .HasForeignKey("PerfilsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Biblioteca.Models.Pedido", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("Biblioteca.Models.Usuario", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
