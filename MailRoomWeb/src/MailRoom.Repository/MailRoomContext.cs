using System;
using MailRoom.Model;
using MailRoom.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MailRoom.Repository
{
    public partial class MailRoomContext : DbContext, IDisposedTracker
    {
        public MailRoomContext()
        {
        }

        public MailRoomContext(DbContextOptions<MailRoomContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<StagingClaim> StagingClaim { get; set; }
        public virtual DbSet<StagingClaimCms1500> StagingclaimCms1500 { get; set; }
        public virtual DbSet<StagingClaimCms1500Detail> StagingclaimCms1500Detail { get; set; }
        bool IDisposedTracker.IsDisposed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(Configuration.GetConnectionString("MailRoom"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(128)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(128)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(128)");

                entity.Property(e => e.Name).HasColumnType("varchar(128)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<StagingClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("stagingclaim");

                entity.Property(e => e.ClaimId)
                    .HasColumnName("ClaimID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcceptAssignment).HasColumnType("bit(1)");

                entity.Property(e => e.AdditionalClaimInfo).HasColumnType("bit(1)");

                entity.Property(e => e.AnotherHealthBenefitPlan).HasColumnType("bit(1)");

                entity.Property(e => e.BillingProviderNpi)
                    .HasColumnName("BillingProviderNPI")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateOfIllness).HasColumnType("date");

                entity.Property(e => e.DateOfService).HasColumnType("int(11)");

                entity.Property(e => e.DaysOrUnits).HasColumnType("int(11)");

                entity.Property(e => e.Emg)
                    .HasColumnName("EMG")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EpsdtfamilyPlan)
                    .HasColumnName("EPSDTFamilyPlan")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FacilityNameAddress).HasColumnType("varchar(50)");

                entity.Property(e => e.FederalTaxId).HasColumnType("int(11)");

                entity.Property(e => e.HospitalizationDates).HasColumnType("int(11)");

                entity.Property(e => e.InsurancePlan).HasColumnType("varchar(50)");

                entity.Property(e => e.InsurancePlanName).HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredAddress).HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredAuthorizedSignature).HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredDateOfBirth).HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredId)
                    .HasColumnName("InsuredID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredName).HasColumnType("varchar(50)");

                entity.Property(e => e.InsuredPolicyGroup).HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.NatureOfIllness).HasColumnType("varchar(50)");

                entity.Property(e => e.NoWorkDays).HasColumnType("int(11)");

                entity.Property(e => e.OtherClaimId).HasColumnType("varchar(50)");

                entity.Property(e => e.OtherDate).HasColumnType("date");

                entity.Property(e => e.OtherInsurance).HasColumnType("varchar(50)");

                entity.Property(e => e.OtherInsuranceNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.OutsideLab).HasColumnType("bit(1)");

                entity.Property(e => e.ParserErrorCsv).HasColumnType("varchar(1000)");

                entity.Property(e => e.PatientAccountNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.PatientAddress).HasColumnType("varchar(50)");

                entity.Property(e => e.PatientAuthorizedSignature).HasColumnType("varchar(50)");

                entity.Property(e => e.PatientCondition).HasColumnType("bit(1)");

                entity.Property(e => e.PatientName).HasColumnType("varchar(50)");

                entity.Property(e => e.PatientStagingClaimNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.PlaceOfService).HasColumnType("varchar(50)");

                entity.Property(e => e.PriorAuthorizationNumber).HasColumnType("int(11)");

                entity.Property(e => e.ProcedureCodes).HasColumnType("int(11)");

                entity.Property(e => e.ProviderBillingNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.ReferringProvider).HasColumnType("varchar(50)");

                entity.Property(e => e.RelationToInsured).HasColumnType("varchar(50)");

                entity.Property(e => e.RenderingProviderId).HasColumnType("int(11)");

                entity.Property(e => e.ReviewStatus)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReviewerId).HasColumnType("varchar(50)");

                entity.Property(e => e.SecondaryRenderingProviderId).HasColumnType("int(11)");

                entity.Property(e => e.SignatureofProvider).HasColumnType("varchar(50)");

                entity.Property(e => e.SourceId)
                    .HasColumnName("sourceId")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TotalCharge).HasColumnType("decimal(13,2)");

                entity.Property(e => e.TotalClaimAmount).HasColumnType("decimal(13,2)");
            });

            modelBuilder.Entity<StagingClaimCms1500>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("stagingclaim_cms1500");

                entity.Property(e => e.ClaimId)
                    .HasColumnName("ClaimID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConfidenceLevel)
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ParserErrorCsv).HasColumnType("varchar(1000)");

                entity.Property(e => e.ReviewStatus)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReviewerId).HasColumnType("varchar(50)");

                entity.Property(e => e.SourceId)
                    .HasColumnName("sourceId")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._10aPatientConditionEmployment)
                    .HasColumnName("10a_PatientConditionEmployment")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._10bPatientConditionAuto)
                    .HasColumnName("10b_PatientConditionAuto")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e._10cPatientConditionOther)
                    .HasColumnName("10c_PatientConditionOther")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._10dClaimCodes)
                    .HasColumnName("10d_ClaimCodes")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._11InsuredPolicyGroup)
                    .HasColumnName("11_InsuredPolicyGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e._11aInsuredBirthDate)
                    .HasColumnName("11a_InsuredBirthDate")
                    .HasColumnType("date");

                entity.Property(e => e._11aInsuredGender)
                    .HasColumnName("11a_InsuredGender")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._11bOtherClaimId)
                    .HasColumnName("11b_OtherClaimId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._11cInsurancePlanName)
                    .HasColumnName("11c_InsurancePlanName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._11cOtherClaimIdNucc)
                    .HasColumnName("11c_OtherClaimIdNUCC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._11dIsAnotherHealthPlan)
                    .HasColumnName("11d_IsAnotherHealthPlan")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._12PatientAuthorizedSignatureDate)
                    .HasColumnName("12_PatientAuthorizedSignatureDate")
                    .HasColumnType("date");

                entity.Property(e => e._12PatientAuthorizedSignatureImageUrl)
                    .HasColumnName("12_PatientAuthorizedSignatureImageUrl")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._13InsuredAuthorizedSignatureImageUrl)
                    .HasColumnName("13_InsuredAuthorizedSignatureImageUrl")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._14DateOfCurrentIllness)
                    .HasColumnName("14_DateOfCurrentIllness")
                    .HasColumnType("date");

                entity.Property(e => e._14DateOfCurrentIllnessQual)
                    .HasColumnName("14_DateOfCurrentIllnessQual")
                    .HasColumnType("date");

                entity.Property(e => e._15OtherDate)
                    .HasColumnName("15_OtherDate")
                    .HasColumnType("date");

                entity.Property(e => e._15OtherQual)
                    .HasColumnName("15_OtherQual")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._16PatientUnableToWorkEndDate)
                    .HasColumnName("16_PatientUnableToWorkEndDate")
                    .HasColumnType("date");

                entity.Property(e => e._16PatientUnableToWorkStartDate)
                    .HasColumnName("16_PatientUnableToWorkStartDate")
                    .HasColumnType("date");

                entity.Property(e => e._17ReferringProvider)
                    .HasColumnName("17_ReferringProvider")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._17aNonNpireferringProvider)
                    .HasColumnName("17a_NonNPIReferringProvider")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._18HospitalizationEndDate)
                    .HasColumnName("18_HospitalizationEndDate")
                    .HasColumnType("date");

                entity.Property(e => e._18HospitalizationStartDate)
                    .HasColumnName("18_HospitalizationStartDate")
                    .HasColumnType("date");

                entity.Property(e => e._19AdditionalClaimInfo)
                    .HasColumnName("19_AdditionalClaimInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._1PayerType)
                    .HasColumnName("1_PayerType")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._1aPatientInsuredId)
                    .HasColumnName("1a_PatientInsuredID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._20OutsideLab)
                    .HasColumnName("20_OutsideLab")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._21Icdind)
                    .HasColumnName("21_ICDInd")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessA)
                    .HasColumnName("21_NatureOfIllnessA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessB)
                    .HasColumnName("21_NatureOfIllnessB")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessC)
                    .HasColumnName("21_NatureOfIllnessC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessD)
                    .HasColumnName("21_NatureOfIllnessD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessE)
                    .HasColumnName("21_NatureOfIllnessE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessF)
                    .HasColumnName("21_NatureOfIllnessF")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessG)
                    .HasColumnName("21_NatureOfIllnessG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessH)
                    .HasColumnName("21_NatureOfIllnessH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessI)
                    .HasColumnName("21_NatureOfIllnessI")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessJ)
                    .HasColumnName("21_NatureOfIllnessJ")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessK)
                    .HasColumnName("21_NatureOfIllnessK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._21NatureOfIllnessL)
                    .HasColumnName("21_NatureOfIllnessL")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._22OriginalRefNo)
                    .HasColumnName("22_OriginalRefNo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._22ResubmissionCode)
                    .HasColumnName("22_ResubmissionCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._23PriorAuthorizationNumber)
                    .HasColumnName("23_PriorAuthorizationNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e._25FederalTaxId)
                    .HasColumnName("25_FederalTaxId")
                    .HasColumnType("int(10)");

                entity.Property(e => e._25IsSsnorEin)
                    .HasColumnName("25_IsSSNorEIN")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._26PatientAccountNumber)
                    .HasColumnName("26_PatientAccountNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._27AcceptAssignment)
                    .HasColumnName("27_AcceptAssignment")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._28TotalCharge)
                    .HasColumnName("28_TotalCharge")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e._29AmountPaid)
                    .HasColumnName("29_AmountPaid")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e._2PatientName)
                    .HasColumnName("2_PatientName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._30Nuccuse)
                    .HasColumnName("30_NUCCUse")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e._31PhysicianSignatureImageUrl)
                    .HasColumnName("31_PhysicianSignatureImageUrl")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._32ServiceFacilityLocationInfo)
                    .HasColumnName("32_ServiceFacilityLocationInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._32aServiceFacilityLocationInfo)
                    .HasColumnName("32a_ServiceFacilityLocationInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._32bServiceFacilityLocationInfo)
                    .HasColumnName("32b_ServiceFacilityLocationInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._33BillingProviderInfo)
                    .HasColumnName("33_BillingProviderInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._33BillingProviderInfoPhone)
                    .HasColumnName("33_BillingProviderInfoPhone")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._33aBillingProviderInfo)
                    .HasColumnName("33a_BillingProviderInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._33bBillingProviderInfo)
                    .HasColumnName("33b_BillingProviderInfo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._3PatientBirthDate)
                    .HasColumnName("3_PatientBirthDate")
                    .HasColumnType("date");

                entity.Property(e => e._3aPatientGender)
                    .HasColumnName("3a_PatientGender")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._4InsuredName)
                    .HasColumnName("4_InsuredName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._5PatientAddress)
                    .HasColumnName("5_PatientAddress")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._5PatientAddressCity)
                    .HasColumnName("5_PatientAddressCity")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._5PatientAddressState)
                    .HasColumnName("5_PatientAddressState")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._5PatientAddressStreet)
                    .HasColumnName("5_PatientAddressStreet")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._6PatientRelationToInsured)
                    .HasColumnName("6_PatientRelationToInsured")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._7InsuredAddressCity)
                    .HasColumnName("7_InsuredAddressCity")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._7InsuredAddressState)
                    .HasColumnName("7_InsuredAddressState")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._7InsuredAddressStreet)
                    .HasColumnName("7_InsuredAddressStreet")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._7InsuredAddressTelephone)
                    .HasColumnName("7_InsuredAddressTelephone")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._7InsuredAddressZip)
                    .HasColumnName("7_InsuredAddressZip")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e._8ReservedNucc)
                    .HasColumnName("8_ReservedNUCC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9OtherPayerInsuredName)
                    .HasColumnName("9_OtherPayerInsuredName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9aOtherPayerGroup)
                    .HasColumnName("9a_OtherPayerGroup")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9bOtherReservedNucc)
                    .HasColumnName("9b_OtherReservedNUCC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9cOtherInsuranceName)
                    .HasColumnName("9c_OtherInsuranceName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9cOtherReservedNucc)
                    .HasColumnName("9c_OtherReservedNUCC")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<StagingClaimCms1500Detail>(entity =>
            {
                entity.HasKey(e => e.ClaimDetailId);

                entity.ToTable("stagingclaim_cms1500_detail");

                entity.HasIndex(e => e.ClaimId)
                    .HasName("fk_claimId");

                entity.Property(e => e.ClaimDetailId)
                    .HasColumnName("ClaimDetailID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClaimId)
                    .HasColumnName("ClaimID")
                    .HasColumnType("int(11)");

                entity.Property(e => e._24aServiceEndDate)
                    .HasColumnName("24a_ServiceEndDate")
                    .HasColumnType("date");

                entity.Property(e => e._24aServiceStartDate)
                    .HasColumnName("24a_ServiceStartDate")
                    .HasColumnType("date");

                entity.Property(e => e._24bPlaceofService)
                    .HasColumnName("24b_PlaceofService")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._24cEmg)
                    .HasColumnName("24c_EMG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._24dCpthcpcs)
                    .HasColumnName("24d_CPTHCPCS")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._24dModifier)
                    .HasColumnName("24d_Modifier")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._24eDiagnosisPointer)
                    .HasColumnName("24e_DiagnosisPointer")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._24fCharges)
                    .HasColumnName("24f_charges")
                    .HasColumnType("decimal(13,2)");

                entity.Property(e => e._24gDaysOrUnits)
                    .HasColumnName("24g_DaysOrUnits")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e._24hEpsdt)
                    .HasColumnName("24h_EPSDT")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e._24iQual)
                    .HasColumnName("24i_Qual")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e._24jRenderingProviderId)
                    .HasColumnName("24j_RenderingProviderId")
                    .HasColumnType("int(13)");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.StagingclaimCms1500Detail)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stagingclaim_cms1500_detail_ibfk_1");
            });
        }
    }
}
