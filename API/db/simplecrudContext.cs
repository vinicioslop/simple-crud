using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.db
{
    public partial class simplecrudContext : DbContext
    {
        public simplecrudContext()
        {
        }

        public simplecrudContext(DbContextOptions<simplecrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbUsuario> TbUsuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tb_usuario");

                entity.HasIndex(e => e.Login, "login")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.NmEmail)
                    .HasMaxLength(60)
                    .HasColumnName("nm_email");

                entity.Property(e => e.NmUsuario)
                    .HasMaxLength(80)
                    .HasColumnName("nm_usuario");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(11)
                    .HasColumnName("nr_cpf")
                    .IsFixedLength();

                entity.Property(e => e.NrTelefone)
                    .HasMaxLength(11)
                    .HasColumnName("nr_telefone")
                    .IsFixedLength();

                entity.Property(e => e.Senha)
                    .HasMaxLength(64)
                    .HasColumnName("senha")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
