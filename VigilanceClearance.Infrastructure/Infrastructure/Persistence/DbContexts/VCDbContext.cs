using Microsoft.EntityFrameworkCore;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.Models;
using VigilanceClearance.Domain.Model;
namespace VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

public partial class VCDbContext : DbContext
{
    public VCDbContext()
    {
    }

    public VCDbContext(DbContextOptions<VCDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<MasterVcCadre> MasterVcCadres { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<TblMasterVc1OfficerDetail> TblMasterVc1OfficerDetails { get; set; }

    public virtual DbSet<TblMasterVcMinistry> TblMasterVcMinistries { get; set; }

    public virtual DbSet<TblMasterVcMinistryNew> TblMasterVcMinistryNews { get; set; }

    public virtual DbSet<TblMasterVcPost> TblMasterVcPosts { get; set; }

    public virtual DbSet<TblMasterVcPostSubCategory> TblMasterVcPost { get; set; }

    public virtual DbSet<TblMasterVcReference> TblMasterVcReferences { get; set; }

    public virtual DbSet<TblMasterVcReferenceReceivedFor> TblMasterVcReferenceReceivedFor { get; set; }

    public virtual DbSet<TblMasterVcServiceNew> TblMasterVcServiceNews { get; set; }

    public virtual DbSet<TblMasterVcUser> TblMasterVcUsers { get; set; }

    public virtual DbSet<TblTransaction10PunishmentAwarded> TblTransaction10PunishmentAwardeds { get; set; }

    public virtual DbSet<TblTransaction11DisciplinaryCriminalProceeding> TblTransaction11DisciplinaryCriminalProceedings { get; set; }

    public virtual DbSet<TblTransaction12ActionContemplatedAgainstTheOfficerAsOnDate> TblTransaction12ActionContemplatedAgainstTheOfficerAsOnDates { get; set; }

    public virtual DbSet<TblTransaction13ComplaintWithVigilanceAnglePending> TblTransaction13ComplaintWithVigilanceAnglePendings { get; set; }

    public virtual DbSet<TblTransaction8IntegrityAgreedOrDoubtful> TblTransaction8IntegrityAgreedOrDoubtfuls { get; set; }

    public virtual DbSet<TblTransaction9AllegationOfMisconductExamined> TblTransaction9AllegationOfMisconductExamineds { get; set; }

    public virtual DbSet<TblTransactionCommentsOfVigilanceBranch> TblTransactionCommentsOfVigilanceBranches { get; set; }

    public virtual DbSet<TblTransactionFeebbackOfCbi> TblTransactionFeebbackOfCbis { get; set; }

    public virtual DbSet<TblTransactionPdf> TblTransactionPdfs { get; set; }

    public virtual DbSet<TblTransactionVcOfficerPostingDetail> TblTransactionVcOfficerPostingDetails { get; set; }
   
    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.25.34.185;Initial Catalog=VigilanceClearance;User ID=sa;Password=Qpr@2025;Integrated Security=False;TrustServerCertificate=True;");
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetRo__3214EC079521CDEF");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });
        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AspNetUs__3214EC0712FC72B7");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AspNetUse__RoleI__540C7B00"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AspNetUse__UserI__531856C7"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__AspNetUs__AF2760ADCC2C0DB6");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<MasterVcCadre>(entity =>
        {
            entity.ToTable("tbl_Master_Vc_Cadre");

            entity.Property(e => e.CadreDesc).HasMaxLength(255);
            entity.Property(e => e.CadreStateUt)
                .HasMaxLength(255)
                .HasColumnName("CadreState_UT");
            entity.Property(e => e.CadreType).HasMaxLength(255);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MenuItem__3214EC0792813FFA");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RequiredRole).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(255);
        });

        modelBuilder.Entity<TblMasterVc1OfficerDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_Master_Vc_OfficerDetails");

            entity.ToTable("tbl_Master_Vc_1_OfficerDetails");

            entity.Property(e => e.ActionContemplatedAgainstTheOfficerAsOnDate12)
                .HasMaxLength(3)
                .HasColumnName("ActionContemplatedAgainstTheOfficerAsOnDate_12");
            entity.Property(e => e.AllegationOfMisconductExamined9)
                .HasMaxLength(3)
                .HasColumnName("AllegationOfMisconductExamined_9");
            entity.Property(e => e.ComplaintWithVigilanceAnglePending13)
                .HasMaxLength(3)
                .HasColumnName("ComplaintWithVigilanceAnglePending_13");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DisciplinaryCriminalProceedings11)
                .HasMaxLength(3)
                .HasColumnName("DisciplinaryCriminalProceedings_11");
            entity.Property(e => e.IntegrityAgreedOrDoubtful8)
                .HasMaxLength(3)
                .HasColumnName("IntegrityAgreedOrDoubtful_8");
            entity.Property(e => e.OfficerBatchYear).HasColumnName("Officer_Batch_Year");
            entity.Property(e => e.OfficerCadre).HasColumnName("Officer_Cadre");
            entity.Property(e => e.OfficerDateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Officer_DateOfBirth");
            entity.Property(e => e.OfficerFatherName).HasColumnName("Officer_FatherName");
            entity.Property(e => e.OfficerName).HasColumnName("Officer_Name");
            entity.Property(e => e.OfficerRetirementDate)
                .HasColumnType("datetime")
                .HasColumnName("Officer_RetirementDate");
            entity.Property(e => e.OfficerService).HasColumnName("Officer_Service");
            entity.Property(e => e.OfficerServiceEntryDate)
                .HasColumnType("datetime")
                .HasColumnName("Officer_ServiceEntryDate");
            entity.Property(e => e.OrgCode).HasColumnName("orgCode");
            entity.Property(e => e.OthersRemarks).HasColumnName("othersRemarks");
            entity.Property(e => e.PunishmentAwarded10)
                .HasMaxLength(3)
                .HasColumnName("PunishmentAwarded_10");
            entity.Property(e => e.SelectionForThePostCategory).HasColumnName("selectionForThePostCategory");
            entity.Property(e => e.SelectionForThePostSubCategory).HasColumnName("selectionForThePostSubCategory");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblMasterVcMinistry>(entity =>
        {
            entity.ToTable("tbl_Master_Vc_Ministry");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<TblMasterVcMinistryNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_MasterMinistryNew");

            entity.ToTable("tbl_Master_Vc_MinistryNew");

            entity.Property(e => e.AsCode)
                .HasMaxLength(25)
                .HasColumnName("AS_CODE");
            entity.Property(e => e.Bocode).HasColumnName("BOCode");
            entity.Property(e => e.Bocode27022024)
                .HasMaxLength(20)
                .HasColumnName("BOCODE_27022024");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Createdby)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("createdby");
            entity.Property(e => e.CreatedbyIp)
                .HasMaxLength(15)
                .HasColumnName("createdbyIP");
            entity.Property(e => e.Createdon)
                .HasColumnType("smalldatetime")
                .HasColumnName("createdon");
            entity.Property(e => e.OrgCode).HasMaxLength(50);
            entity.Property(e => e.OrgCodeOld).HasColumnName("OrgCode_Old");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("updatedby");
            entity.Property(e => e.UpdatedbyIp)
                .HasMaxLength(15)
                .HasColumnName("updatedbyIP");
            entity.Property(e => e.Updatedon)
                .HasColumnType("smalldatetime")
                .HasColumnName("updatedon");
        });

        modelBuilder.Entity<TblMasterVcPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_MasterPost");

            entity.ToTable("tbl_Master_Vc_Post");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_Ip");
            entity.Property(e => e.CreatedBySession)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_Session");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblMasterVcPostSubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_Master_vc_postCategory");

            entity.ToTable("tbl_Master_Vc_Post_SubCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SelectionForThePostCategory).HasColumnName("selectionForThePostCategory");
            entity.Property(e => e.SelectionForThePostCategorySubCode).HasColumnName("selectionForThePostCategory_SubCode");
            entity.Property(e => e.SelectionForThePostCategorySubCodeDesc).HasColumnName("selectionForThePostCategory_SubCodeDesc");
        });

        modelBuilder.Entity<TblMasterVcReference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Mast__3213E83FC25E289A");

            entity.ToTable("tbl_Master_Vc_Reference");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceCode).HasMaxLength(50);
            entity.Property(e => e.ReferenceDesc).HasMaxLength(50);
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });
        modelBuilder.Entity<TblMasterVcReferenceReceivedFor>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__tbl_Mast__3213E83FF4BDCE1A"); // Use actual PK name from DB

            entity.ToTable("tbl_Master_Vc_ReferenceReceivedFor");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ReferenceReceivedFor).HasColumnName("ReferenceReceivedFor");
            entity.Property(e => e.ReferenceReceivedFrom).HasColumnName("ReferenceReceivedFrom");
            entity.Property(e => e.ReferenceReceivedFromCode).HasColumnName("ReferenceReceivedFromCode");
            entity.Property(e => e.SelectionForThePostCategory).HasColumnName("selectionForThePostCategory");
            entity.Property(e => e.SelectionForThePostSubCategory).HasColumnName("selectionForThePostSubCategory");
            entity.Property(e => e.OrgCode).HasColumnName("OrgCode");
            entity.Property(e => e.OrgName).HasColumnName("OrgName");
            entity.Property(e => e.MinCode).HasColumnName("MinCode");
            entity.Property(e => e.MinDesc).HasColumnName("MinDesc");
            entity.Property(e => e.ReferenceNoFileNo).HasColumnName("ReferenceNo_FileNo");
            entity.Property(e => e.ReferenceOrSubmissionToCvcDate)
                .HasColumnName("ReferenceOrSubmissionToCvcDate")
                .HasColumnType("datetime");
            entity.Property(e => e.CvcReferenceIdFileNo).HasColumnName("CVC_ReferenceID_FileNo");

            entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy");
            entity.Property(e => e.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedByIp)
                .HasColumnName("CreatedBy_IP")
                .HasMaxLength(50);

            entity.Property(e => e.UpdateBy).HasColumnName("UpdateBy");
            entity.Property(e => e.UpdatedOn)
                .HasColumnName("UpdatedOn")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");

            entity.Property(e => e.PendingWith).HasColumnName("PendingWith");

            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
        });

        modelBuilder.Entity<TblMasterVcServiceNew>(entity =>
        {
            entity.HasKey(e => e.ServiceCodeId);

            entity.ToTable("tbl_Master_Vc_ServiceNew");

            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.CreatedbyIp)
                .HasMaxLength(50)
                .HasColumnName("createdbyIP");
            entity.Property(e => e.Createdon)
                .HasColumnType("smalldatetime")
                .HasColumnName("createdon");
            entity.Property(e => e.ServiceCode).HasMaxLength(50);
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .HasColumnName("SessionID");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.UpdatedbyIp)
                .HasMaxLength(50)
                .HasColumnName("updatedbyIP");
            entity.Property(e => e.Updatedon)
                .HasColumnType("smalldatetime")
                .HasColumnName("updatedon");
        });

        modelBuilder.Entity<TblMasterVcUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tbl_Master_VC_User");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.FilledOtp).HasColumnName("FilledOTP");
            entity.Property(e => e.GeneratedOtp).HasColumnName("GeneratedOTP");
            entity.Property(e => e.MappedSection).HasMaxLength(50);
            entity.Property(e => e.OrgCode).HasMaxLength(50);
            entity.Property(e => e.OtpgenerateTime)
                .HasColumnType("datetime")
                .HasColumnName("OTPGenerateTime");
            entity.Property(e => e.UserActiveStatus).HasColumnName("userActiveStatus");
            entity.Property(e => e.UserBranchOffices).HasColumnName("userBranchOffices");
            entity.Property(e => e.UserDesignation).HasColumnName("userDesignation");
            entity.Property(e => e.UserEmail).HasColumnName("userEmail");
            entity.Property(e => e.UserLogin).HasColumnName("userLogin");
            entity.Property(e => e.UserMobile).HasColumnName("userMobile");
            entity.Property(e => e.UserName).HasColumnName("userName");
            entity.Property(e => e.UserPassword).HasColumnName("userPassword");
            entity.Property(e => e.UserPasswordHashed).HasColumnName("userPasswordHashed");
            entity.Property(e => e.UserProfile).HasColumnName("userProfile");
        });

        modelBuilder.Entity<TblTransaction10PunishmentAwarded>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83F785F7BDB");

            entity.ToTable("tbl_Transaction_10_PunishmentAwarded");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalRemarksIfAny)
                .HasMaxLength(30)
                .HasColumnName("additionalRemarks_IfAny");
            entity.Property(e => e.CheckNameFromDate)
                .HasColumnType("datetime")
                .HasColumnName("checkName_FromDate");
            entity.Property(e => e.CheckNameToDate)
                .HasColumnType("datetime")
                .HasColumnName("checkName_ToDate");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.PunishmentAwarded)
                .HasMaxLength(3)
                .HasColumnName("punishmentAwarded");
            entity.Property(e => e.PunishmentDetails).HasColumnName("punishmentDetails");
            entity.Property(e => e.PunishmentFromDate)
                .HasColumnType("datetime")
                .HasColumnName("punishmentFromDate");
            entity.Property(e => e.PunishmentToDate)
                .HasColumnType("datetime")
                .HasColumnName("punishmentToDate");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransaction11DisciplinaryCriminalProceeding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83FD16CF506");

            entity.ToTable("tbl_Transaction_11_DisciplinaryCriminalProceedings");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DetailsOfCase).HasColumnName("detailsOf_Case");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.PresentStatusOftheCase).HasColumnName("presentStatusOftheCase");
            entity.Property(e => e.RevocationDate)
                .HasColumnType("datetime")
                .HasColumnName("revocationDate");
            entity.Property(e => e.SuspensionDate).HasColumnName("suspensionDate");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.WhetherDisciplinaryCriminalProceedingsPending)
                .HasMaxLength(3)
                .HasColumnName("whether_DisciplinaryCriminalProceedingsPending");
            entity.Property(e => e.WhetherRevoked).HasColumnName("whetherRevoked");
            entity.Property(e => e.WhetherSuspended)
                .HasMaxLength(3)
                .HasColumnName("whether_Suspended");
        });

        modelBuilder.Entity<TblTransaction12ActionContemplatedAgainstTheOfficerAsOnDate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83FFF548DC5");

            entity.ToTable("tbl_Transaction_12_ActionContemplatedAgainstTheOfficerAsOnDate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DetailsOfTheCase).HasColumnName("detailsOfTheCase");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.PresentStatusOftheCase).HasColumnName("presentStatusOftheCase");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.WhetherCaseContemplated)
                .HasMaxLength(3)
                .HasColumnName("whether_CaseContemplated");
        });

        modelBuilder.Entity<TblTransaction13ComplaintWithVigilanceAnglePending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83F0B4C7712");

            entity.ToTable("tbl_Transaction_13_ComplaintWithVigilanceAnglePending");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddtionalRemarks).HasColumnName("addtionalRemarks");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DetailsOfTheCase).HasColumnName("detailsOfTheCase");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.PresentStatusOftheCase).HasColumnName("presentStatusOftheCase");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.WhetherVigilanceAngelPending)
                .HasMaxLength(3)
                .HasColumnName("whether_vigilanceAngelPending");
        });

        modelBuilder.Entity<TblTransaction8IntegrityAgreedOrDoubtful>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83F1C26AA31");

            entity.ToTable("tbl_Transaction_8_IntegrityAgreedOrDoubtful");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateOfEntryInTheList)
                .HasColumnType("datetime")
                .HasColumnName("dateOfEntryInTheList");
            entity.Property(e => e.DateOfRemovalFromTheList).HasMaxLength(3);
            entity.Property(e => e.EnteredInTheList)
                .HasMaxLength(3)
                .HasColumnName("enteredInTheList");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.RemovedFromTheList)
                .HasMaxLength(3)
                .HasColumnName("removedFromTheList");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransaction9AllegationOfMisconductExamined>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83F4E235A13");

            entity.ToTable("tbl_Transaction_9_AllegationOfMisconductExamined");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionRecommendedDetails).HasColumnName("actionRecommendedDetails");
            entity.Property(e => e.ActionrecommendedOptions)
                .HasMaxLength(30)
                .HasColumnName("actionrecommendedOptions");
            entity.Property(e => e.CaseDetails).HasColumnName("caseDetails");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.PresentStatusOfTheCase)
                .HasMaxLength(30)
                .HasColumnName("presentStatusOfTheCase");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VigilanceAngleExamined)
                .HasMaxLength(3)
                .HasColumnName("vigilanceAngleExamined");
        });

        modelBuilder.Entity<TblTransactionCommentsOfVigilanceBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83FFFEFF74D");

            entity.ToTable("tbl_Transaction_CommentsOf_VigilanceBranch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentsOfVigilanceBranch).HasColumnName("CommentsOf_VigilanceBranch");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransactionFeebbackOfCbi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Tran__3213E83F2EF1FCE7");

            entity.ToTable("tbl_Transaction_FeebbackOf_CBI");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FeebbackOfCbi).HasColumnName("FeebbackOf_CBI");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransactionPdf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_tran__3213E83FA2F56938");

            entity.ToTable("tbl_transaction_PDF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DocumentCode).HasColumnName("documentCode");
            entity.Property(e => e.DocumentId).HasColumnName("documentId");
            entity.Property(e => e.OfficerId).HasColumnName("officerId");
        });

        modelBuilder.Entity<TblTransactionVcOfficerPostingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Vc_O__3213E83FFC46D473");

            entity.ToTable("tbl_Transaction_Vc_OfficerPostingDetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedByIp)
                .HasMaxLength(50)
                .HasColumnName("CreatedBy_IP");
            entity.Property(e => e.CreatedBySessionId).HasColumnName("CreatedBy_SessionId");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasColumnName("designation");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("fromDate");
            entity.Property(e => e.OrgCode).HasColumnName("orgCode");
            entity.Property(e => e.OrgMinistry).HasColumnName("orgMinistry");
            entity.Property(e => e.PlaceOfPosting).HasColumnName("placeOfPosting");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("toDate");
            entity.Property(e => e.UpdatedByIp).HasColumnName("UpdatedBy_IP");
            entity.Property(e => e.UpdatedBySessionId).HasColumnName("UpdatedBy_SessionId");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VcOfficerId).HasColumnName("Vc_Officer_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
