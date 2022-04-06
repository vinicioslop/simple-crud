using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.db
{
    public partial class simple_crudContext : DbContext
    {
        public simple_crudContext()
        {
        }

        public simple_crudContext(DbContextOptions<simple_crudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_usuario");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
