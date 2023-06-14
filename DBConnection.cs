using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RRHHApi.DBModels;

namespace RRHHApi;

public partial class DBConnection : DbContext
{
    public DBConnection()
    {
    }

    public DBConnection(DbContextOptions<DBConnection> options)
        : base(options)
    {
    }

    public virtual DbSet<T_COUNTRIES> T_COUNTRIES { get; set; }

    public virtual DbSet<T_DEPARTMENTS> T_DEPARTMENTS { get; set; }

    public virtual DbSet<T_EMPLOYEES> T_EMPLOYEES { get; set; }

    public virtual DbSet<T_JOBS> T_JOBS { get; set; }

    public virtual DbSet<T_JOB_HISTORY> T_JOB_HISTORY { get; set; }

    public virtual DbSet<T_LOCATIONS> T_LOCATIONS { get; set; }

    public virtual DbSet<T_REGIONS> T_REGIONS { get; set; }

    public virtual DbSet<T_USERS> T_USERS { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("DATA SOURCE=localhost:1521/xe;PASSWORD=matiymilla;USER ID=system;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<T_COUNTRIES>(entity =>
        {
            entity.HasKey(e => e.COUNTRY_ID).HasName("COUNTRY_C_ID_PK");

            entity.Property(e => e.COUNTRY_ID)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.COUNTRY_NAME)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.REGION_ID).HasColumnType("NUMBER");

            entity.HasOne(d => d.REGION).WithMany(p => p.T_COUNTRIES)
                .HasForeignKey(d => d.REGION_ID)
                .HasConstraintName("COUNTR_REG_FK");
        });

        modelBuilder.Entity<T_DEPARTMENTS>(entity =>
        {
            entity.HasKey(e => e.DEPARTMENT_ID).HasName("DEPT_ID_PK");

            entity.Property(e => e.DEPARTMENT_ID).HasPrecision(4);
            entity.Property(e => e.DEPARTMENT_NAME)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LOCATION_ID).HasPrecision(4);
            entity.Property(e => e.MANAGER_ID).HasPrecision(6);

            entity.HasOne(d => d.LOCATION).WithMany(p => p.T_DEPARTMENTS)
                .HasForeignKey(d => d.LOCATION_ID)
                .HasConstraintName("DEPT_LOC_FK");

            entity.HasOne(d => d.MANAGER).WithMany(p => p.T_DEPARTMENTS)
                .HasForeignKey(d => d.MANAGER_ID)
                .HasConstraintName("DEPT_MGR_FK");
        });

        modelBuilder.Entity<T_EMPLOYEES>(entity =>
        {
            entity.HasKey(e => e.EMPLOYEE_ID).HasName("EMP_EMP_ID_PK");

            entity.HasIndex(e => e.EMAIL, "EMP_EMAIL_UK").IsUnique();

            entity.Property(e => e.EMPLOYEE_ID)
                .HasPrecision(6)
                .ValueGeneratedNever();
            entity.Property(e => e.COMMISSION_PCT).HasColumnType("NUMBER(2,2)");
            entity.Property(e => e.DEPARTMENT_ID).HasPrecision(4);
            entity.Property(e => e.EMAIL)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FIRST_NAME)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HIRE_DATE).HasColumnType("DATE");
            entity.Property(e => e.JOB_ID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LAST_NAME)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.MANAGER_ID).HasPrecision(6);
            entity.Property(e => e.PHONE_NUMBER)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SALARY).HasColumnType("NUMBER(8,2)");

            entity.HasOne(d => d.DEPARTMENT).WithMany(p => p.T_EMPLOYEES)
                .HasForeignKey(d => d.DEPARTMENT_ID)
                .HasConstraintName("EMP_DEPT_FK");

            entity.HasOne(d => d.JOB).WithMany(p => p.T_EMPLOYEES)
                .HasForeignKey(d => d.JOB_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMP_JOB_FK");

            entity.HasOne(d => d.MANAGER).WithMany(p => p.InverseMANAGER)
                .HasForeignKey(d => d.MANAGER_ID)
                .HasConstraintName("EMP_MANAGER_FK");
        });

        modelBuilder.Entity<T_JOBS>(entity =>
        {
            entity.HasKey(e => e.JOB_ID).HasName("JOB_ID_PK");

            entity.Property(e => e.JOB_ID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.JOB_TITLE)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.MAX_SALARY).HasPrecision(6);
            entity.Property(e => e.MIN_SALARY).HasPrecision(6);
        });

        modelBuilder.Entity<T_JOB_HISTORY>(entity =>
        {
            entity.HasKey(e => new { e.EMPLOYEE_ID, e.START_DATE }).HasName("JHIST_EMP_ID_ST_DATE_PK");

            entity.Property(e => e.EMPLOYEE_ID).HasPrecision(6);
            entity.Property(e => e.START_DATE).HasColumnType("DATE");
            entity.Property(e => e.DEPARTMENT_ID).HasPrecision(4);
            entity.Property(e => e.END_DATE).HasColumnType("DATE");
            entity.Property(e => e.JOB_ID)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.DEPARTMENT).WithMany(p => p.T_JOB_HISTORY)
                .HasForeignKey(d => d.DEPARTMENT_ID)
                .HasConstraintName("JHIST_DEPT_FK");

            entity.HasOne(d => d.EMPLOYEE).WithMany(p => p.T_JOB_HISTORY)
                .HasForeignKey(d => d.EMPLOYEE_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JHIST_EMP_FK");

            entity.HasOne(d => d.JOB).WithMany(p => p.T_JOB_HISTORY)
                .HasForeignKey(d => d.JOB_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JHIST_JOB_FK");
        });

        modelBuilder.Entity<T_LOCATIONS>(entity =>
        {
            entity.HasKey(e => e.LOCATION_ID).HasName("LOC_ID_PK");

            entity.Property(e => e.LOCATION_ID).HasPrecision(4);
            entity.Property(e => e.CITY)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.COUNTRY_ID)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.POSTAL_CODE)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.STATE_PROVINCE)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.STREET_ADDRESS)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.COUNTRY).WithMany(p => p.T_LOCATIONS)
                .HasForeignKey(d => d.COUNTRY_ID)
                .HasConstraintName("LOC_C_ID_FK");
        });

        modelBuilder.Entity<T_REGIONS>(entity =>
        {
            entity.HasKey(e => e.REGION_ID).HasName("REG_ID_PK");

            entity.Property(e => e.REGION_ID).HasColumnType("NUMBER");
            entity.Property(e => e.REGION_NAME)
                .HasMaxLength(25)
                .IsUnicode(false);
        });
        modelBuilder.Entity<T_USERS>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ID_USER)
                .HasPrecision(5)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.PASSWORD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ROLE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.USER_MAIL)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.USER_NAME)
                .HasMaxLength(30)
                .IsUnicode(false);
        });
        modelBuilder.HasSequence("DEPARTMENTS_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("EMPLOYEES_SEQ");
        modelBuilder.HasSequence("LOCATIONS_SEQ").IncrementsBy(100);
        modelBuilder.HasSequence("LOGMNR_DIDS$");
        modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");
        modelBuilder.HasSequence("LOGMNR_SEQ$");
        modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");
        modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");
        modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
