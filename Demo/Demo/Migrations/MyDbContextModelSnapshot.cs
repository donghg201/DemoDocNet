﻿// <auto-generated />
using System;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.Models.AccTransaction", b =>
                {
                    b.Property<int>("TxnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int?>("ExecutionBranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FundsAvailDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TellerEmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TxnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TxnTypeCd")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TxnId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExecutionBranchId");

                    b.HasIndex("TellerEmpId");

                    b.ToTable("AccTransactions");
                });

            modelBuilder.Entity("Demo.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float?>("AvailBalance")
                        .HasColumnType("real");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OpenBranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OpenEmpId")
                        .HasColumnType("int");

                    b.Property<float?>("PendingBalance")
                        .HasColumnType("real");

                    b.Property<string>("ProductCd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AccountId");

                    b.HasIndex("CustId");

                    b.HasIndex("OpenBranchId");

                    b.HasIndex("OpenEmpId");

                    b.HasIndex("ProductCd");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Demo.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("BranchId");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Demo.Models.Bussiness", b =>
                {
                    b.Property<string>("StateId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("CustId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IncorpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("StateId");

                    b.HasIndex("CustId");

                    b.ToTable("Bussiness");
                });

            modelBuilder.Entity("Demo.Models.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("City")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustTypeCd")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("FedId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("State")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Demo.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Demo.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignedBranchId")
                        .HasColumnType("int");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SuperiorEmpId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("EmpId");

                    b.HasIndex("AssignedBranchId");

                    b.HasIndex("DeptId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Demo.Models.Individual", b =>
                {
                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FirstName");

                    b.HasIndex("CustId");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.Property<string>("ProductCd")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("DateOffered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRetired")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductTypeCd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ProductCd");

                    b.HasIndex("ProductTypeCd");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Demo.Models.ProductType", b =>
                {
                    b.Property<string>("ProductTypeCd")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductTypeCd");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Demo.Models.AccTransaction", b =>
                {
                    b.HasOne("Demo.Models.Account", "Account")
                        .WithMany("AccTransaction")
                        .HasForeignKey("AccountId");

                    b.HasOne("Demo.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("ExecutionBranchId");

                    b.HasOne("Demo.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("TellerEmpId");

                    b.Navigation("Account");

                    b.Navigation("Branch");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Demo.Models.Account", b =>
                {
                    b.HasOne("Demo.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustId");

                    b.HasOne("Demo.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("OpenBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("OpenEmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Demo.Models.Product", "Product")
                        .WithMany("Accounts")
                        .HasForeignKey("ProductCd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demo.Models.Bussiness", b =>
                {
                    b.HasOne("Demo.Models.Customer", "Customer")
                        .WithMany("Bussiness")
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Demo.Models.Employee", b =>
                {
                    b.HasOne("Demo.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("AssignedBranchId");

                    b.HasOne("Demo.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptId");

                    b.Navigation("Branch");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Demo.Models.Individual", b =>
                {
                    b.HasOne("Demo.Models.Customer", "Customer")
                        .WithMany("Individuals")
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.HasOne("Demo.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeCd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Demo.Models.Account", b =>
                {
                    b.Navigation("AccTransaction");
                });

            modelBuilder.Entity("Demo.Models.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Bussiness");

                    b.Navigation("Individuals");
                });

            modelBuilder.Entity("Demo.Models.Product", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
