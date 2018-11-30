using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MailRoom.ParserLib
{
    public partial class mailroomContext : DbContext
    {
        string connectionString = null;
        public mailroomContext(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public mailroomContext(DbContextOptions<mailroomContext> options, IConfiguration configuratio)
            : base(options)
        {
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
        public virtual DbSet<Stagingclaim> Stagingclaim { get; set; }
        public virtual DbSet<StagingClaimCms1500> StagingClaimCms1500 { get; set; }
        public virtual DbSet<StagingClaimCms1500Detail> StagingclaimCms1500Detail { get; set; }
        public virtual DbSet<Cms15001> Cms15001 { get; set; }
        public virtual DbSet<Cms15002> Cms15002 { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySql("server=localhost;port=3306;database=mailroom;uid=admin;password=sql@2012");
                optionsBuilder.UseMySql(connectionString);
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

            modelBuilder.Entity<Cms15001>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.ToTable("cms1500_1");

                entity.Property(e => e.ClaimId)
                    .HasColumnName("ClaimID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.IaPayerName)
                    .HasColumnName("ia_PayerName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IbPayerAddress1)
                    .HasColumnName("ib_PayerAddress1")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IcPayerAddress2)
                    .HasColumnName("ic_PayerAddress2")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IdPayerCityStateZipcode)
                    .HasColumnName("id_Payer_city_state_zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._10aEmployment)
                    .HasColumnName("10a_employment")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10bAAutoAccidentPlace)
                    .HasColumnName("10b-a_Auto_Accident_Place")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._10bAutoAccident)
                    .HasColumnName("10b_Auto_Accident")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10cOtherAccident)
                    .HasColumnName("10c_Other_Accident")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10dClaimCodes)
                    .HasColumnName("10d_Claim_codes")
                    .HasColumnType("varchar(19)");

                entity.Property(e => e._11InsuredsPolicyNumber)
                    .HasColumnName("11_InsuredsPolicyNumber")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._11aAMm)
                    .HasColumnName("11a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._11aBDd)
                    .HasColumnName("11a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._11aCYyyy)
                    .HasColumnName("11a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._11aDGender)
                    .HasColumnName("11a-d_Gender")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._11bAQualifier)
                    .HasColumnName("11b-a_qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._11bBClaimId)
                    .HasColumnName("11b-b_ClaimID")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._11cInsurancePlanName)
                    .HasColumnName("11c_InsurancePlanName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._11dAnotherHealthBenefitPlan)
                    .HasColumnName("11d_Another_Health_Benefit_Plan")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._12ASignatureUrl)
                    .HasColumnName("12-a_Signature_URL")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._12BAMm)
                    .HasColumnName("12-b-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._12BBDd)
                    .HasColumnName("12-b-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._12BCYyyy)
                    .HasColumnName("12-b-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._13InsuredsAuthorizedSignatureUrl)
                    .HasColumnName("13_InsuredsAuthorizedSignature_URL")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._14AMm)
                    .HasColumnName("14-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._14BDd)
                    .HasColumnName("14-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._14CYyyy)
                    .HasColumnName("14-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._14DQualifier)
                    .HasColumnName("14-d_qualifier")
                    .HasColumnType("int(3)");

                entity.Property(e => e._15AMm)
                    .HasColumnName("15-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._15BDd)
                    .HasColumnName("15-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._15CYyyy)
                    .HasColumnName("15-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._15DQualifier)
                    .HasColumnName("15-d_qualifier")
                    .HasColumnType("int(3)");

                entity.Property(e => e._16AAMm)
                    .HasColumnName("16-a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16ABDd)
                    .HasColumnName("16-a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16ACYyyy)
                    .HasColumnName("16-a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._16AMm)
                    .HasColumnName("16-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16BDd)
                    .HasColumnName("16-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16CYyyy)
                    .HasColumnName("16-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._17AName)
                    .HasColumnName("17-a_Name")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._17Qualifier)
                    .HasColumnName("17_qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._17aAQualifier)
                    .HasColumnName("17a-a_Qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._17aBIdNumber)
                    .HasColumnName("17a-b_ID number")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._17bIdNumber)
                    .HasColumnName("17b_ID number")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._18AAMm)
                    .HasColumnName("18-a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18ABDd)
                    .HasColumnName("18-a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18ACYyyy)
                    .HasColumnName("18-a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._18AMm)
                    .HasColumnName("18-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18BDd)
                    .HasColumnName("18-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18CYyyy)
                    .HasColumnName("18-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._19AdditionalClaimInformation)
                    .HasColumnName("19_Additional_Claim_Information")
                    .HasColumnType("varchar(71)");

                entity.Property(e => e._1PayerType)
                    .HasColumnName("1_PAYER_TYPE")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e._1aInsuredIdNumber)
                    .HasColumnName("1a_Insured_Id_number")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._20AChargesDollars)
                    .HasColumnName("20-a_Charges_dollars")
                    .HasColumnType("int(8)");

                entity.Property(e => e._20BChargesCents)
                    .HasColumnName("20-b_charges_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._20YesOrNo)
                    .HasColumnName("20_YES OR NO")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._21IcdIndicator)
                    .HasColumnName("21_ICD_Indicator")
                    .HasColumnType("int(1)");

                entity.Property(e => e._21aNatureOfIllnes)
                    .HasColumnName("21A_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21bNatureOfIllnes)
                    .HasColumnName("21B_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21cNatureOfIllnes)
                    .HasColumnName("21C_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21dNatureOfIllnes)
                    .HasColumnName("21D_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21eNatureOfIllnes)
                    .HasColumnName("21E_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21fNatureOfIllnes)
                    .HasColumnName("21F_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21gNatureOfIllnes)
                    .HasColumnName("21G_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21hNatureOfIllnes)
                    .HasColumnName("21H_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21iNatureOfIllnes)
                    .HasColumnName("21I_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21jNatureOfIllnes)
                    .HasColumnName("21J_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21kNatureOfIllnes)
                    .HasColumnName("21K_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21lNatureOfIllnes)
                    .HasColumnName("21L_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._22AReSubmissionCodeQualifier)
                    .HasColumnName("22-a_ReSubmissionCode_qualifier")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e._22BOriginalRefNo)
                    .HasColumnName("22-b_original_ref_No")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e._23PriorAuthorizationNumber)
                    .HasColumnName("23_PriorAuthorizationNumber")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._25AType)
                    .HasColumnName("25-a_type")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._25BIdNumber)
                    .HasColumnName("25-b_ID_Number")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e._26PatientAccNumber)
                    .HasColumnName("26_Patient_Acc_Number")
                    .HasColumnType("int(14)");

                entity.Property(e => e._27AcceptAssignment)
                    .HasColumnName("27_Accept_Assignment")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._28ADollars)
                    .HasColumnName("28-a_dollars")
                    .HasColumnType("int(6)");

                entity.Property(e => e._28BCents)
                    .HasColumnName("28-b_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._29ADollars)
                    .HasColumnName("29-a_dollars")
                    .HasColumnType("int(6)");

                entity.Property(e => e._29BCents)
                    .HasColumnName("29-b_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._2aLastName)
                    .HasColumnName("2a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2bSuffix)
                    .HasColumnName("2b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2cFirstName)
                    .HasColumnName("2c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2dMiddleName)
                    .HasColumnName("2d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._30ACode)
                    .HasColumnName("30-a_code")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._30BQualifier)
                    .HasColumnName("30-b_qualifier")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._31ASignature)
                    .HasColumnName("31-a_Signature")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._31BAMm)
                    .HasColumnName("31-b-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._31BBDd)
                    .HasColumnName("31-b-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._31BCYyyy)
                    .HasColumnName("31-b-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._32AProviderName)
                    .HasColumnName("32-a_ProviderName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32BProviderAddress)
                    .HasColumnName("32-b_ProviderAddress")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32CCityStateZipcode)
                    .HasColumnName("32-c_City_State_Zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32aNationalProviderIdentifierNumber)
                    .HasColumnName("32a_NationalProvider_IdentifierNumber")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._32bPayerAssignedIdentifierOfBillingProvider)
                    .HasColumnName("32b_PayerAssignedIdentifier_of_BillingProvider")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._33AAreaCode)
                    .HasColumnName("33-a_AreaCode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._33BPhoneNumber)
                    .HasColumnName("33-b_PhoneNumber")
                    .HasColumnType("int(10)");

                entity.Property(e => e._33CBillingProviderName)
                    .HasColumnName("33-c_BillingProvider_Name")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33DBillingProviderAddress)
                    .HasColumnName("33-d_BillingProvider_Address")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33EBillingproviderCityStateZipcode)
                    .HasColumnName("33-e_Billingprovider_city_state_zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33aNationalProviderIdentifierNumber)
                    .HasColumnName("33a_NationalProvider_IdentifierNumber")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._33bPayerAssignedIdentifierOfBillingProvider)
                    .HasColumnName("33b_PayerAssignedIdentifier_of_BillingProvider")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._3aMm)
                    .HasColumnName("3a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._3bDd)
                    .HasColumnName("3b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._3cYyyy)
                    .HasColumnName("3c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._3dGender)
                    .HasColumnName("3d_Gender")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._4aLastName)
                    .HasColumnName("4a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4bSuffix)
                    .HasColumnName("4b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4cFirstName)
                    .HasColumnName("4c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4dMiddleName)
                    .HasColumnName("4d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._5aStreetAddress)
                    .HasColumnName("5a_Street_Address")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._5bCity)
                    .HasColumnName("5b_City")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._5cState)
                    .HasColumnName("5c_State")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._5dZipcode)
                    .HasColumnName("5d_Zipcode")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._5eTelephoneAreacode)
                    .HasColumnName("5e_Telephone_areacode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._5fTelephonePhoneNumber)
                    .HasColumnName("5f_Telephone_phone number")
                    .HasColumnType("int(10)");

                entity.Property(e => e._6PatientRelationshipToInsured)
                    .HasColumnName("6_Patient_Relationship_to_Insured")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._7aStreetAddress)
                    .HasColumnName("7a_Street_Address")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._7bCity)
                    .HasColumnName("7b_City")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._7cState)
                    .HasColumnName("7c_State")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._7dZipCode)
                    .HasColumnName("7d_Zip code")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._7eTelephoneAreacode)
                    .HasColumnName("7e_Telephone_areacode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._7fTelephonePhonenumber)
                    .HasColumnName("7f_Telephone_phonenumber")
                    .HasColumnType("int(10)");

                entity.Property(e => e._8ReservedForNuccUse)
                    .HasColumnName("8_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9ALastName)
                    .HasColumnName("9-a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9BSuffix)
                    .HasColumnName("9-b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9CFirstName)
                    .HasColumnName("9-c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9DMiddleName)
                    .HasColumnName("9-d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9aOtherPoliciesNumber)
                    .HasColumnName("9a_other_policies_number")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._9bReservedForNuccUse)
                    .HasColumnName("9b_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._9cReservedForNuccUse)
                    .HasColumnName("9c_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._9dInsuranceplanName)
                    .HasColumnName("9d_InsuranceplanName")
                    .HasColumnType("varchar(28)");
            });

            modelBuilder.Entity<Cms15002>(entity =>
            {
                entity.ToTable("cms1500_2");

                entity.HasIndex(e => e._24XClaimId)
                    .HasName("fk_claimId");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e._24XClaimId)
                    .HasColumnName("24-X_Claim Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e._24aAMm)
                    .HasColumnName("24a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aBDd)
                    .HasColumnName("24a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aCYyyy)
                    .HasColumnName("24a-c_YYYY")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aDMm)
                    .HasColumnName("24a-d_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aEDd)
                    .HasColumnName("24a-e_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aFYyyy)
                    .HasColumnName("24a-f_YYYY")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24bPlaceOfService)
                    .HasColumnName("24b_Place of Service")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24cEmg)
                    .HasColumnName("24c_EMG")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._24dACptHcpcs)
                    .HasColumnName("24d-a_CPT/HCPCS")
                    .HasColumnType("int(6)");

                entity.Property(e => e._24dBModifier)
                    .HasColumnName("24d-b_Modifier")
                    .HasColumnType("int(8)");

                entity.Property(e => e._24eDiagnosticPointer)
                    .HasColumnName("24E_Diagnostic Pointer")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e._24fCharges)
                    .HasColumnName("24F_charges")
                    .HasColumnType("int(6)");

                entity.Property(e => e._24fFCharges)
                    .HasColumnName("24F(F)_charges")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24gDaysOrUnits).HasColumnName("24G_Days or Units");

                entity.Property(e => e._24hAEpsdtCode)
                    .HasColumnName("24H-a_EPSDT code")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._24hBYesOrNo)
                    .HasColumnName("24H-b_Yes or no")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._24iQual)
                    .HasColumnName("24I_Qual")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._24jARenderingProviderId)
                    .HasColumnName("24J-a_Rendering provider ID")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._24jBRenderingProviderId)
                    .HasColumnName("24j-b_Rendering provider ID")
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d._24XClaim)
                    .WithMany(p => p.Cms15002)
                    .HasForeignKey(d => d._24XClaimId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("cms1500_2_ibfk_1");
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

            modelBuilder.Entity<Stagingclaim>(entity =>
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
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.ConfidenceLevel)
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IaPayerName)
                    .HasColumnName("ia_PayerName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IbPayerAddress1)
                    .HasColumnName("ib_PayerAddress1")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IcPayerAddress2)
                    .HasColumnName("ic_PayerAddress2")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.IdPayerCityStateZipcode)
                    .HasColumnName("id_Payer_city_state_zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParserErrorCsv).HasColumnType("varchar(2000)");

                entity.Property(e => e.ReviewStatus)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReviewerId).HasColumnType("varchar(50)");

                entity.Property(e => e.SourceId)
                    .HasColumnName("sourceId")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._10aEmployment)
                    .HasColumnName("10a_employment")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10bAAutoAccidentPlace)
                    .HasColumnName("10b-a_Auto_Accident_Place")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._10bAutoAccident)
                    .HasColumnName("10b_Auto_Accident")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10cOtherAccident)
                    .HasColumnName("10c_Other_Accident")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._10dClaimCodes)
                    .HasColumnName("10d_Claim_codes")
                    .HasColumnType("varchar(19)");

                entity.Property(e => e._11InsuredsPolicyNumber)
                    .HasColumnName("11_InsuredsPolicyNumber")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._11aAMm)
                    .HasColumnName("11a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._11aBDd)
                    .HasColumnName("11a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._11aCYyyy)
                    .HasColumnName("11a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._11aDGender)
                    .HasColumnName("11a-d_Gender")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._11bAQualifier)
                    .HasColumnName("11b-a_qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._11bBClaimId)
                    .HasColumnName("11b-b_ClaimID")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._11cInsurancePlanName)
                    .HasColumnName("11c_InsurancePlanName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._11dAnotherHealthBenefitPlan)
                    .HasColumnName("11d_Another_Health_Benefit_Plan")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._12ASignatureUrl)
                    .HasColumnName("12-a_Signature_URL")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._12BAMm)
                    .HasColumnName("12-b-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._12BBDd)
                    .HasColumnName("12-b-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._12BCYyyy)
                    .HasColumnName("12-b-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._13InsuredsAuthorizedSignatureUrl)
                    .HasColumnName("13_InsuredsAuthorizedSignature_URL")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._14AMm)
                    .HasColumnName("14-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._14BDd)
                    .HasColumnName("14-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._14CYyyy)
                    .HasColumnName("14-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._14DQualifier)
                    .HasColumnName("14-d_qualifier")
                    .HasColumnType("int(3)");

                entity.Property(e => e._15AMm)
                    .HasColumnName("15-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._15BDd)
                    .HasColumnName("15-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._15CYyyy)
                    .HasColumnName("15-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._15DQualifier)
                    .HasColumnName("15-d_qualifier")
                    .HasColumnType("int(3)");

                entity.Property(e => e._16AAMm)
                    .HasColumnName("16-a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16ABDd)
                    .HasColumnName("16-a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16ACYyyy)
                    .HasColumnName("16-a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._16AMm)
                    .HasColumnName("16-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16BDd)
                    .HasColumnName("16-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._16CYyyy)
                    .HasColumnName("16-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._17AName)
                    .HasColumnName("17-a_Name")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._17Qualifier)
                    .HasColumnName("17_qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._17aAQualifier)
                    .HasColumnName("17a-a_Qualifier")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._17aBIdNumber)
                    .HasColumnName("17a-b_ID number")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._17bIdNumber)
                    .HasColumnName("17b_ID number")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._18AAMm)
                    .HasColumnName("18-a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18ABDd)
                    .HasColumnName("18-a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18ACYyyy)
                    .HasColumnName("18-a-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._18AMm)
                    .HasColumnName("18-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18BDd)
                    .HasColumnName("18-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._18CYyyy)
                    .HasColumnName("18-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._19AdditionalClaimInformation)
                    .HasColumnName("19_Additional_Claim_Information")
                    .HasColumnType("varchar(71)");

                entity.Property(e => e._1PayerType)
                    .HasColumnName("1_PAYER_TYPE")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e._1aInsuredIdNumber)
                    .HasColumnName("1a_Insured_Id_number")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._20AChargesDollars)
                    .HasColumnName("20-a_Charges_dollars")
                    .HasColumnType("int(8)");

                entity.Property(e => e._20BChargesCents)
                    .HasColumnName("20-b_charges_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._20YesOrNo)
                    .HasColumnName("20_YES OR NO")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._21IcdIndicator)
                    .HasColumnName("21_ICD_Indicator")
                    .HasColumnType("int(1)");

                entity.Property(e => e._21aNatureOfIllnes)
                    .HasColumnName("21A_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21bNatureOfIllnes)
                    .HasColumnName("21B_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21cNatureOfIllnes)
                    .HasColumnName("21C_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21dNatureOfIllnes)
                    .HasColumnName("21D_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21eNatureOfIllnes)
                    .HasColumnName("21E_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21fNatureOfIllnes)
                    .HasColumnName("21F_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21gNatureOfIllnes)
                    .HasColumnName("21G_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21hNatureOfIllnes)
                    .HasColumnName("21H_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21iNatureOfIllnes)
                    .HasColumnName("21I_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21jNatureOfIllnes)
                    .HasColumnName("21J_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21kNatureOfIllnes)
                    .HasColumnName("21K_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._21lNatureOfIllnes)
                    .HasColumnName("21L_Nature_of_Illnes")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._22AReSubmissionCodeQualifier)
                    .HasColumnName("22-a_ReSubmissionCode_qualifier")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e._22BOriginalRefNo)
                    .HasColumnName("22-b_original_ref_No")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e._23PriorAuthorizationNumber)
                    .HasColumnName("23_PriorAuthorizationNumber")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._25AType)
                    .HasColumnName("25-a_type")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._25BIdNumber)
                    .HasColumnName("25-b_ID_Number")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e._26PatientAccNumber)
                    .HasColumnName("26_Patient_Acc_Number")
                    .HasColumnType("int(14)");

                entity.Property(e => e._27AcceptAssignment)
                    .HasColumnName("27_Accept_Assignment")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._28ADollars)
                    .HasColumnName("28-a_dollars")
                    .HasColumnType("int(6)");

                entity.Property(e => e._28BCents)
                    .HasColumnName("28-b_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._29ADollars)
                    .HasColumnName("29-a_dollars")
                    .HasColumnType("int(6)");

                entity.Property(e => e._29BCents)
                    .HasColumnName("29-b_cents")
                    .HasColumnType("int(2)");

                entity.Property(e => e._2aLastName)
                    .HasColumnName("2a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2bSuffix)
                    .HasColumnName("2b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2cFirstName)
                    .HasColumnName("2c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._2dMiddleName)
                    .HasColumnName("2d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._30ACode)
                    .HasColumnName("30-a_code")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._30BQualifier)
                    .HasColumnName("30-b_qualifier")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._31ASignature)
                    .HasColumnName("31-a_Signature")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._31BAMm)
                    .HasColumnName("31-b-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._31BBDd)
                    .HasColumnName("31-b-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._31BCYyyy)
                    .HasColumnName("31-b-c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._32AProviderName)
                    .HasColumnName("32-a_ProviderName")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32BProviderAddress)
                    .HasColumnName("32-b_ProviderAddress")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32CCityStateZipcode)
                    .HasColumnName("32-c_City_State_Zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._32aNationalProviderIdentifierNumber)
                    .HasColumnName("32a_NationalProvider_IdentifierNumber")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._32bPayerAssignedIdentifierOfBillingProvider)
                    .HasColumnName("32b_PayerAssignedIdentifier_of_BillingProvider")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._33AAreaCode)
                    .HasColumnName("33-a_AreaCode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._33BPhoneNumber)
                    .HasColumnName("33-b_PhoneNumber")
                    .HasColumnType("int(10)");

                entity.Property(e => e._33CBillingProviderName)
                    .HasColumnName("33-c_BillingProvider_Name")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33DBillingProviderAddress)
                    .HasColumnName("33-d_BillingProvider_Address")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33EBillingproviderCityStateZipcode)
                    .HasColumnName("33-e_Billingprovider_city_state_zipcode")
                    .HasColumnType("varchar(29)");

                entity.Property(e => e._33aNationalProviderIdentifierNumber)
                    .HasColumnName("33a_NationalProvider_IdentifierNumber")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e._33bPayerAssignedIdentifierOfBillingProvider)
                    .HasColumnName("33b_PayerAssignedIdentifier_of_BillingProvider")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._3aMm)
                    .HasColumnName("3a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._3bDd)
                    .HasColumnName("3b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._3cYyyy)
                    .HasColumnName("3c_YYYY")
                    .HasColumnType("int(4)");

                entity.Property(e => e._3dGender)
                    .HasColumnName("3d_Gender")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._4aLastName)
                    .HasColumnName("4a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4bSuffix)
                    .HasColumnName("4b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4cFirstName)
                    .HasColumnName("4c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._4dMiddleName)
                    .HasColumnName("4d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._5aStreetAddress)
                    .HasColumnName("5a_Street_Address")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._5bCity)
                    .HasColumnName("5b_City")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._5cState)
                    .HasColumnName("5c_State")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._5dZipcode)
                    .HasColumnName("5d_Zipcode")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._5eTelephoneAreacode)
                    .HasColumnName("5e_Telephone_areacode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._5fTelephonePhoneNumber)
                    .HasColumnName("5f_Telephone_phone number")
                    .HasColumnType("int(10)");

                entity.Property(e => e._6PatientRelationshipToInsured)
                    .HasColumnName("6_Patient_Relationship_to_Insured")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e._7aStreetAddress)
                    .HasColumnName("7a_Street_Address")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._7bCity)
                    .HasColumnName("7b_City")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e._7cState)
                    .HasColumnName("7c_State")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e._7dZipCode)
                    .HasColumnName("7d_Zip code")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e._7eTelephoneAreacode)
                    .HasColumnName("7e_Telephone_areacode")
                    .HasColumnType("int(3)");

                entity.Property(e => e._7fTelephonePhonenumber)
                    .HasColumnName("7f_Telephone_phonenumber")
                    .HasColumnType("int(10)");

                entity.Property(e => e._8ReservedForNuccUse)
                    .HasColumnName("8_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e._9ALastName)
                    .HasColumnName("9-a_LastName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9BSuffix)
                    .HasColumnName("9-b_Suffix")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9CFirstName)
                    .HasColumnName("9-c_FirstName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9DMiddleName)
                    .HasColumnName("9-d_MiddleName")
                    .HasColumnType("varchar(14)");

                entity.Property(e => e._9aOtherPoliciesNumber)
                    .HasColumnName("9a_other_policies_number")
                    .HasColumnType("varchar(28)");

                entity.Property(e => e._9bReservedForNuccUse)
                    .HasColumnName("9b_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._9cReservedForNuccUse)
                    .HasColumnName("9c_Reserved_for_NUCC_Use")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e._9dInsuranceplanName)
                    .HasColumnName("9d_InsuranceplanName")
                    .HasColumnType("varchar(28)");
            });

            modelBuilder.Entity<StagingClaimCms1500Detail>(entity =>
            {
                entity.ToTable("stagingclaim_cms1500_detail");

                entity.HasIndex(e => e._24XClaimId)
                    .HasName("fk_claimId");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e._24XClaimId)
                    .HasColumnName("24-X_Claim Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e._24aAMm)
                    .HasColumnName("24a-a_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aBDd)
                    .HasColumnName("24a-b_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aCYyyy)
                    .HasColumnName("24a-c_YYYY")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aDMm)
                    .HasColumnName("24a-d_MM")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aEDd)
                    .HasColumnName("24a-e_DD")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24aFYyyy)
                    .HasColumnName("24a-f_YYYY")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24bPlaceOfService)
                    .HasColumnName("24b_Place of Service")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24cEmg)
                    .HasColumnName("24c_EMG")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._24dACptHcpcs)
                    .HasColumnName("24d-a_CPT/HCPCS")
                    .HasColumnType("int(6)");

                entity.Property(e => e._24dBModifier)
                    .HasColumnName("24d-b_Modifier")
                    .HasColumnType("int(8)");

                entity.Property(e => e._24eDiagnosticPointer)
                    .HasColumnName("24E_Diagnostic Pointer")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e._24fCharges)
                    .HasColumnName("24F_charges")
                    .HasColumnType("int(6)");

                entity.Property(e => e._24fFCharges)
                    .HasColumnName("24F(F)_charges")
                    .HasColumnType("int(2)");

                entity.Property(e => e._24gDaysOrUnits).HasColumnName("24G_Days or Units");

                entity.Property(e => e._24hAEpsdtCode)
                    .HasColumnName("24H-a_EPSDT code")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._24hBYesOrNo)
                    .HasColumnName("24H-b_Yes or no")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e._24iQual)
                    .HasColumnName("24I_Qual")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e._24jARenderingProviderId)
                    .HasColumnName("24J-a_Rendering provider ID")
                    .HasColumnType("varchar(17)");

                entity.Property(e => e._24jBRenderingProviderId)
                    .HasColumnName("24j-b_Rendering provider ID")
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d._24XClaim)
                    .WithMany(p => p.StagingclaimCms1500Detail)
                    .HasForeignKey(d => d._24XClaimId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stagingclaim_cms1500_detail_ibfk_1");
            });
        }
    }
}
