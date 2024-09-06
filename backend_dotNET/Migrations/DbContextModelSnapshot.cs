﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend_dotNET.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.7.24405.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PostgreSQL.Data.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DocumentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DocumentId");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PostgreSQL.Data.DocumentAccess", b =>
                {
                    b.Property<int>("DocumentAccessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DocumentAccessId"));

                    b.Property<string>("AccessLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("GrantedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("DocumentAccessId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("DocumentAccesses");
                });

            modelBuilder.Entity("PostgreSQL.Data.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("PaidAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.HasKey("PaymentId");

                    b.HasIndex("TenantId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PostgreSQL.Data.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PermissionId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("PostgreSQL.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId");

                    b.HasIndex("TenantId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PostgreSQL.Data.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RolePermissionId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("PostgreSQL.Data.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TenantId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("PostgreSQL.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PostgreSQL.Data.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRoleId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PostgreSQL.Data.Document", b =>
                {
                    b.HasOne("PostgreSQL.Data.User", "Creator")
                        .WithMany("CreatedDocuments")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgreSQL.Data.Tenant", "Tenant")
                        .WithMany("Documents")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PostgreSQL.Data.DocumentAccess", b =>
                {
                    b.HasOne("PostgreSQL.Data.Document", "Document")
                        .WithMany("DocumentAccesses")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgreSQL.Data.User", "User")
                        .WithMany("DocumentAccesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostgreSQL.Data.Payment", b =>
                {
                    b.HasOne("PostgreSQL.Data.Tenant", "Tenant")
                        .WithMany("Payments")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PostgreSQL.Data.Role", b =>
                {
                    b.HasOne("PostgreSQL.Data.Tenant", "Tenant")
                        .WithMany("Roles")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PostgreSQL.Data.RolePermission", b =>
                {
                    b.HasOne("PostgreSQL.Data.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgreSQL.Data.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PostgreSQL.Data.User", b =>
                {
                    b.HasOne("PostgreSQL.Data.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PostgreSQL.Data.UserRole", b =>
                {
                    b.HasOne("PostgreSQL.Data.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PostgreSQL.Data.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostgreSQL.Data.Document", b =>
                {
                    b.Navigation("DocumentAccesses");
                });

            modelBuilder.Entity("PostgreSQL.Data.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("PostgreSQL.Data.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("PostgreSQL.Data.Tenant", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Payments");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PostgreSQL.Data.User", b =>
                {
                    b.Navigation("CreatedDocuments");

                    b.Navigation("DocumentAccesses");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
