using bdDevCRM.FrontEnd.Entities;
using bdDevCRM.FrontEnd.Models.Menu;
using Microsoft.EntityFrameworkCore;

namespace bdDevCRM.FrontEnd.Context;

public partial class CRMContext : DbContext
{
	public CRMContext()
	{
	}

	public CRMContext(DbContextOptions<CRMContext> options)
			: base(options)
	{
	}
	public virtual DbSet<MenuQueryDto> MenuQueryResults { get; set; }

	public virtual DbSet<AboutUsLicense> AboutUsLicense { get; set; }

	public virtual DbSet<AccessControl> AccessControl { get; set; }

	public virtual DbSet<AccessRestriction> AccessRestriction { get; set; }

	public virtual DbSet<ApproverDetails> ApproverDetails { get; set; }

	public virtual DbSet<ApproverHistory> ApproverHistory { get; set; }

	public virtual DbSet<ApproverOrder> ApproverOrder { get; set; }

	public virtual DbSet<ApproverType> ApproverType { get; set; }

	public virtual DbSet<ApproverTypeToGroupMapping> ApproverTypeToGroupMapping { get; set; }

	public virtual DbSet<AppsTokenInfo> AppsTokenInfo { get; set; }

	public virtual DbSet<AppsTransactionLog> AppsTransactionLog { get; set; }

	public virtual DbSet<AssemblyInfo> AssemblyInfo { get; set; }

	public virtual DbSet<AssignApprover> AssignApprover { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }

	public virtual DbSet<AuditTrail> AuditTrail { get; set; }

	public virtual DbSet<AuditType> AuditType { get; set; }

	public virtual DbSet<BoardInstitute> BoardInstitute { get; set; }

	public virtual DbSet<Branch> Branch { get; set; }

	public virtual DbSet<Company> Company { get; set; }

	public virtual DbSet<CompanyDepartmentMap> CompanyDepartmentMap { get; set; }

	public virtual DbSet<CompanyLocationMap> CompanyLocationMap { get; set; }

	public virtual DbSet<Competencies> Competencies { get; set; }

	public virtual DbSet<CompetencyLevel> CompetencyLevel { get; set; }

	public virtual DbSet<CrmAdditionalDocument> CrmAdditionalDocument { get; set; }

	public virtual DbSet<CrmAdditionalInfo> CrmAdditionalInfo { get; set; }

	public virtual DbSet<CrmApplicantCourse> CrmApplicantCourse { get; set; }

	public virtual DbSet<CrmApplicantInfo> CrmApplicantInfo { get; set; }

	public virtual DbSet<CrmApplicantReference> CrmApplicantReference { get; set; }

	public virtual DbSet<CrmApplication> CrmApplication { get; set; }

	public virtual DbSet<CrmCountry> CrmCountry { get; set; }

	public virtual DbSet<CrmCourse> CrmCourse { get; set; }

	public virtual DbSet<CrmCourseIntake> CrmCourseIntake { get; set; }

	public virtual DbSet<CrmCurrencyInfo> CrmCurrencyInfo { get; set; }

	public virtual DbSet<CrmEducationHistory> CrmEducationHistory { get; set; }

	public virtual DbSet<CrmGmatinformation> CrmGmatinformation { get; set; }

	public virtual DbSet<CrmIeltsinformation> CrmIeltsinformation { get; set; }

	public virtual DbSet<CrmInstitute> CrmInstitute { get; set; }

	public virtual DbSet<CrmInstituteType> CrmInstituteType { get; set; }

	public virtual DbSet<CrmIntakeMonth> CrmIntakeMonth { get; set; }

	public virtual DbSet<CrmIntakeYear> CrmIntakeYear { get; set; }

	public virtual DbSet<CrmMonth> CrmMonth { get; set; }

	public virtual DbSet<CrmOthersInformation> CrmOthersInformation { get; set; }

	public virtual DbSet<CrmPaymentMethod> CrmPaymentMethod { get; set; }

	public virtual DbSet<CrmPermanentAddress> CrmPermanentAddress { get; set; }

	public virtual DbSet<CrmPresentAddress> CrmPresentAddress { get; set; }

	public virtual DbSet<CrmPteinformation> CrmPteinformation { get; set; }

	public virtual DbSet<CrmStatementOfPurpose> CrmStatementOfPurpose { get; set; }

	public virtual DbSet<CrmToeflinformation> CrmToeflinformation { get; set; }

	public virtual DbSet<CrmWorkExperience> CrmWorkExperience { get; set; }

	public virtual DbSet<CrmYear> CrmYear { get; set; }

	public virtual DbSet<CurencyRate> CurencyRate { get; set; }

	public virtual DbSet<Currency> Currency { get; set; }

	public virtual DbSet<DeligationInfo> DeligationInfo { get; set; }

	public virtual DbSet<Department> Department { get; set; }

	public virtual DbSet<DmsDocument> DmsDocument { get; set; }

	public virtual DbSet<DmsDocumentAccessLog> DmsDocumentAccessLog { get; set; }

	public virtual DbSet<DmsDocumentFolder> DmsDocumentFolder { get; set; }

	public virtual DbSet<DmsDocumentTag> DmsDocumentTag { get; set; }

	public virtual DbSet<DmsDocumentTagMap> DmsDocumentTagMap { get; set; }

	public virtual DbSet<DmsDocumentType> DmsDocumentType { get; set; }

	public virtual DbSet<DmsDocumentVersion> DmsDocumentVersion { get; set; }

	public virtual DbSet<DmsFileUpdateHistory> DmsFileUpdateHistory { get; set; }

	public virtual DbSet<Docmdetails> Docmdetails { get; set; }

	public virtual DbSet<Docmdetailshistory> Docmdetailshistory { get; set; }

	public virtual DbSet<Documanttype> Documanttype { get; set; }

	public virtual DbSet<Document> Document { get; set; }

	public virtual DbSet<DocumentParameter> DocumentParameter { get; set; }

	public virtual DbSet<DocumentParameterMapping> DocumentParameterMapping { get; set; }

	public virtual DbSet<DocumentQueryMapping> DocumentQueryMapping { get; set; }

	public virtual DbSet<DocumentTemplate> DocumentTemplate { get; set; }

	public virtual DbSet<Employee> Employee { get; set; }

	public virtual DbSet<Employeetype> Employeetype { get; set; }

	public virtual DbSet<Employment> Employment { get; set; }

	public virtual DbSet<GroupMember> GroupMember { get; set; }

	public virtual DbSet<GroupPermission> GroupPermission { get; set; }

	public virtual DbSet<Groups> Groups { get; set; }

	public virtual DbSet<Holiday> Holiday { get; set; }

	public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }

	public virtual DbSet<Menu> Menu { get; set; }

	public virtual DbSet<Module> Module { get; set; }

	public virtual DbSet<PasswordHistory> PasswordHistory { get; set; }

	public virtual DbSet<RefreshTokens> RefreshTokens { get; set; }

	public virtual DbSet<ReportBuilder> ReportBuilder { get; set; }

	public virtual DbSet<SystemSettings> SystemSettings { get; set; }

	public virtual DbSet<Thana> Thana { get; set; }

	public virtual DbSet<Timesheet> Timesheet { get; set; }

	public virtual DbSet<TokenBlacklist> TokenBlacklist { get; set; }

	public virtual DbSet<Users> Users { get; set; }

	public virtual DbSet<WfAction> WfAction { get; set; }

	public virtual DbSet<WfState> WfState { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//			=> optionsBuilder.UseSqlServer("Server=DESKTOP-OMQ8M9P; User ID=sa;password=bdDevs@3011; Database=dbDevCRM;TrustServerCertificate=true;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		modelBuilder.Entity<MenuQueryDto>(entity =>
		{
			entity.HasNoKey();          // Primary key নেই
			//entity.ToView(null);        // কোনো table/view নেই — শুধু query result
		});

		modelBuilder.Entity<AboutUsLicense>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.AboutUsLicenseId)
							.ValueGeneratedOnAdd()
							.HasColumnName("AboutUsLicenseID");
			entity.Property(e => e.CodeBaseVersion).HasMaxLength(50);
			entity.Property(e => e.LicenseFor).HasMaxLength(50);
			entity.Property(e => e.LicenseNumber).HasMaxLength(50);
			entity.Property(e => e.LicenseType).HasMaxLength(50);
			entity.Property(e => e.LocationLicense).HasMaxLength(50);
			entity.Property(e => e.ProductCode).HasMaxLength(50);
			entity.Property(e => e.Sbulicense)
							.HasMaxLength(50)
							.HasColumnName("SBULicense");
			entity.Property(e => e.ServerId)
							.HasMaxLength(50)
							.HasColumnName("ServerID");
			entity.Property(e => e.UserLicense).HasMaxLength(50);
		});

		modelBuilder.Entity<AccessControl>(entity =>
		{
			entity.HasKey(e => e.AccessId).HasName("PK_ACCESSCONTROL");

			entity.Property(e => e.AccessName).HasMaxLength(50);
		});

		modelBuilder.Entity<AccessRestriction>(entity =>
		{
			entity.Property(e => e.AccessDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<ApproverDetails>(entity =>
		{
			entity.HasKey(e => e.RemarksId).HasName("PK_Remarks");

			entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
			entity.Property(e => e.FuncId).HasColumnName("Func_Id");
		});

		modelBuilder.Entity<ApproverHistory>(entity =>
		{
			entity.HasKey(e => e.AssignApproverId);

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DeleteDate).HasColumnType("datetime");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<ApproverOrder>(entity =>
		{
			entity.Property(e => e.ApproverOrderId).ValueGeneratedNever();
			entity.Property(e => e.OrderTitle)
							.HasMaxLength(50)
							.IsUnicode(false);
		});

		modelBuilder.Entity<ApproverType>(entity =>
		{
			entity.Property(e => e.ApproverTypeId).ValueGeneratedNever();
			entity.Property(e => e.ApproverTypeName)
							.HasMaxLength(50)
							.IsUnicode(false);
		});

		modelBuilder.Entity<ApproverTypeToGroupMapping>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.ApproverTypeMapId).ValueGeneratedOnAdd();

			entity.HasOne(d => d.ApproverType).WithMany()
							.HasForeignKey(d => d.ApproverTypeId)
							.HasConstraintName("FK_ApproverTypeToGroupMapping_ApproverType");
		});

		modelBuilder.Entity<AppsTokenInfo>(entity =>
		{
			entity.Property(e => e.AppsUserId)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.EmployeeId)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
			entity.Property(e => e.IssueDate).HasColumnType("datetime");
			entity.Property(e => e.TokenNumber)
							.HasMaxLength(200)
							.IsUnicode(false);
		});

		modelBuilder.Entity<AppsTransactionLog>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.AppsUserId).HasMaxLength(50);
			entity.Property(e => e.EmployeeId).HasMaxLength(100);
			entity.Property(e => e.Remarks).HasMaxLength(1000);
			entity.Property(e => e.Request).HasMaxLength(200);
			entity.Property(e => e.Response).HasMaxLength(2000);
			entity.Property(e => e.TransactionDate).HasColumnType("datetime");
			entity.Property(e => e.TransactionLogId).ValueGeneratedOnAdd();
			entity.Property(e => e.TransactionType).HasMaxLength(100);
		});

		modelBuilder.Entity<AssemblyInfo>(entity =>
		{
			entity.Property(e => e.AssemblyInfoId)
							.ValueGeneratedNever()
							.HasComment("");
			entity.Property(e => e.AssemblyCompany)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.AssemblyCopyright)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.AssemblyDescription)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.AssemblyProduct)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.AssemblyTitle)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.AssemblyVersion)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.CvBankPath).HasMaxLength(250);
			entity.Property(e => e.IsAttendanceByLogin).HasComment("false=Attedance by login inactive feature");
			entity.Property(e => e.PoweredBy)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.PoweredByUrl)
							.HasMaxLength(250)
							.IsUnicode(false);
			entity.Property(e => e.ProductBanner)
							.HasMaxLength(250)
							.IsUnicode(false);
			entity.Property(e => e.ProductStyleSheet)
							.HasMaxLength(250)
							.IsUnicode(false);
		});

		modelBuilder.Entity<AssignApprover>(entity =>
		{
			entity.HasNoKey();

			entity.HasIndex(e => new { e.HrRecordId, e.ModuleId, e.SortOrder, e.Type }, "IX_DuplicateApprover").IsUnique();

			entity.Property(e => e.AssignApproverId).ValueGeneratedOnAdd();
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<AuditLog>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.ActionName)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.AuditDate).HasColumnType("datetime");
			entity.Property(e => e.AuditId).ValueGeneratedOnAdd();
			entity.Property(e => e.AuditStatus)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.BrowserInfo)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.ClientIp)
							.HasMaxLength(50)
							.HasColumnName("ClientIP");
			entity.Property(e => e.ClientUser).HasMaxLength(500);
			entity.Property(e => e.ControllerName)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.DomainName)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.ExceptionLog).IsUnicode(false);
			entity.Property(e => e.MacAddress).HasMaxLength(500);
			entity.Property(e => e.ReferrerUrl)
							.HasMaxLength(250)
							.IsUnicode(false);
			entity.Property(e => e.RequestedParams).IsUnicode(false);
			entity.Property(e => e.RequestedUrl).IsUnicode(false);
			entity.Property(e => e.TableName)
							.HasMaxLength(50)
							.IsUnicode(false);
		});

		modelBuilder.Entity<AuditTrail>(entity =>
		{
			entity
							.HasNoKey()
							.ToTable("AUDIT_TRAIL");

			entity.Property(e => e.ActionDate)
							.HasColumnType("datetime")
							.HasColumnName("ACTION_DATE");
			entity.Property(e => e.AuditDescription).HasColumnName("AUDIT_DESCRIPTION");
			entity.Property(e => e.AuditId)
							.ValueGeneratedOnAdd()
							.HasColumnName("AUDIT_ID");
			entity.Property(e => e.AuditStatus)
							.HasMaxLength(50)
							.HasColumnName("Audit_Status");
			entity.Property(e => e.AuditType)
							.HasMaxLength(500)
							.HasColumnName("AUDIT_TYPE");
			entity.Property(e => e.ClientIp)
							.HasMaxLength(50)
							.HasColumnName("CLIENT_IP");
			entity.Property(e => e.ClientUser)
							.HasMaxLength(500)
							.HasColumnName("CLIENT_USER");
			entity.Property(e => e.RequestedUrl).HasColumnName("Requested_Url");
			entity.Property(e => e.Shortdescription).HasColumnName("SHORTDESCRIPTION");
			entity.Property(e => e.UserId).HasColumnName("USER_ID");
		});

		modelBuilder.Entity<AuditType>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.AuditType1)
							.HasMaxLength(250)
							.IsUnicode(false)
							.HasColumnName("AuditType");
		});

		modelBuilder.Entity<BoardInstitute>(entity =>
		{
			entity.Property(e => e.BoardInstituteName)
							.HasMaxLength(500)
							.IsUnicode(false);
		});

		modelBuilder.Entity<Branch>(entity =>
		{
			entity.Property(e => e.Branchid).HasColumnName("BRANCHID");
			entity.Property(e => e.BranchAddress)
							.HasMaxLength(250)
							.IsUnicode(false);
			entity.Property(e => e.Branchcode)
							.HasMaxLength(50)
							.HasColumnName("BRANCHCODE");
			entity.Property(e => e.Branchdescription)
							.HasMaxLength(2000)
							.HasColumnName("BRANCHDESCRIPTION");
			entity.Property(e => e.Branchname)
							.HasMaxLength(100)
							.HasColumnName("BRANCHNAME");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<Company>(entity =>
		{
			entity.Property(e => e.Address).HasMaxLength(1000);
			entity.Property(e => e.CompanyAlias).HasMaxLength(50);
			entity.Property(e => e.CompanyCircle).HasMaxLength(200);
			entity.Property(e => e.CompanyCode).HasMaxLength(50);
			entity.Property(e => e.CompanyName).HasMaxLength(50);
			entity.Property(e => e.CompanyRegisterNo).HasMaxLength(250);
			entity.Property(e => e.CompanyTin).HasMaxLength(50);
			entity.Property(e => e.CompanyZone).HasMaxLength(200);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.Fax).HasMaxLength(50);
			entity.Property(e => e.FullLogoPath).HasMaxLength(1000);
			entity.Property(e => e.FullLogoPathForReport).HasMaxLength(1000);
			entity.Property(e => e.IsElautoAddedForCurrentYear).HasColumnName("IsELAutoAddedForCurrentYear");
			entity.Property(e => e.LetterFooter).HasMaxLength(1000);
			entity.Property(e => e.LetterHeader).HasMaxLength(1000);
			entity.Property(e => e.Phone).HasMaxLength(50);
			entity.Property(e => e.PrimaryContact).HasMaxLength(50);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CompanyDepartmentMap>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.SbuDepartmentMapId).ValueGeneratedOnAdd();
		});

		modelBuilder.Entity<CompanyLocationMap>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.SbuLocationMapId).ValueGeneratedOnAdd();
		});

		modelBuilder.Entity<Competencies>(entity =>
		{
			entity.Property(e => e.CompetencyName).HasMaxLength(50);
		});

		modelBuilder.Entity<CompetencyLevel>(entity =>
		{
			entity.HasKey(e => e.LevelId);

			entity.Property(e => e.LevelTitle).HasMaxLength(50);
			entity.Property(e => e.Remarks)
							.HasMaxLength(150)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmAdditionalDocument>(entity =>
		{
			entity.HasKey(e => e.AdditionalDocumentId);

			entity.Property(e => e.AdditionalDocumentId).ValueGeneratedNever();
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DocumentName)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.DocumentPath).HasMaxLength(350);
			entity.Property(e => e.DocumentTitle)
							.HasMaxLength(350)
							.IsUnicode(false);
			entity.Property(e => e.RecordType)
							.HasMaxLength(150)
							.IsUnicode(false);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmAdditionalInfo>(entity =>
		{
			entity.HasKey(e => e.AdditionalInfoId).HasName("PK__Addition__2C4B5286CA6080E2");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.HealthNmedicalNeeds).HasColumnName("HealthNMedicalNeeds");
			entity.Property(e => e.HealthNmedicalNeedsRemarks).HasColumnName("HealthNMedicalNeedsRemarks");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmAdditionalInfo)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Additiona__Appli__7A3223E8");
		});

		modelBuilder.Entity<CrmApplicantCourse>(entity =>
		{
			entity.HasKey(e => e.ApplicantCourseId).HasName("PK__Applican__32CD933295321BBB");

			entity.Property(e => e.ApplicationFee).HasMaxLength(50);
			entity.Property(e => e.CountryName).HasMaxLength(100);
			entity.Property(e => e.CourseTitle).HasMaxLength(255);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.IntakeMonth).HasMaxLength(50);
			entity.Property(e => e.IntakeYear).HasMaxLength(50);
			entity.Property(e => e.PaymentDate).HasColumnType("datetime");
			entity.Property(e => e.PaymentMethod).HasMaxLength(50);
			entity.Property(e => e.PaymentReferenceNumber).HasMaxLength(100);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmApplicantCourse)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Applicant__Appli__7D0E9093");
		});

		modelBuilder.Entity<CrmApplicantInfo>(entity =>
		{
			entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE91A8F9CF4ED3");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
			entity.Property(e => e.EmailAddress).HasMaxLength(150);
			entity.Property(e => e.FirstName).HasMaxLength(100);
			entity.Property(e => e.LastName).HasMaxLength(100);
			entity.Property(e => e.Mobile).HasMaxLength(20);
			entity.Property(e => e.Nationality).HasMaxLength(100);
			entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");
			entity.Property(e => e.PassportIssueDate).HasColumnType("datetime");
			entity.Property(e => e.PassportNumber).HasMaxLength(50);
			entity.Property(e => e.PhoneAreaCode).HasMaxLength(10);
			entity.Property(e => e.PhoneCountryCode).HasMaxLength(10);
			entity.Property(e => e.PhoneNumber).HasMaxLength(25);
			entity.Property(e => e.SkypeId).HasMaxLength(100);
			entity.Property(e => e.TitleText).HasMaxLength(50);
			entity.Property(e => e.TitleValue).HasMaxLength(50);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Application).WithMany(p => p.CrmApplicantInfo)
							.HasForeignKey(d => d.ApplicationId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Applicant__Appli__7755B73D");
		});

		modelBuilder.Entity<CrmApplicantReference>(entity =>
		{
			entity.HasKey(e => e.ApplicantReferenceId).HasName("PK__Applican__8C380D2828FDEB18");

			entity.Property(e => e.Address).HasMaxLength(255);
			entity.Property(e => e.City).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.Designation).HasMaxLength(255);
			entity.Property(e => e.EmailId)
							.HasMaxLength(150)
							.HasColumnName("EmailID");
			entity.Property(e => e.FaxNo).HasMaxLength(50);
			entity.Property(e => e.Institution).HasMaxLength(255);
			entity.Property(e => e.Name).HasMaxLength(255);
			entity.Property(e => e.PhoneNo).HasMaxLength(50);
			entity.Property(e => e.PostOrZipCode).HasMaxLength(20);
			entity.Property(e => e.State).HasMaxLength(100);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmApplicantReference)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Applicant__Appli__7FEAFD3E");
		});

		modelBuilder.Entity<CrmApplication>(entity =>
		{
			entity.HasKey(e => e.ApplicationId).HasName("PK__CrmAppli__C93A4C99E0194183");

			entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmCountry>(entity =>
		{
			entity.HasKey(e => e.CountryId).HasName("PK_Country");

			entity.Property(e => e.CountryCode).HasMaxLength(50);
			entity.Property(e => e.CountryName).HasMaxLength(100);
		});

		modelBuilder.Entity<CrmCourse>(entity =>
		{
			entity.HasKey(e => e.CourseId);

			entity.Property(e => e.AdditionalInformationOfCourse)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.After2YearsPswcompletingCourse)
							.HasMaxLength(300)
							.IsUnicode(false)
							.HasColumnName("After2YearsPSWCompletingCourse");
			entity.Property(e => e.ApplicationFee).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.AwardingBody)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.CountryBenefits)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.CourseBenefits)
							.HasMaxLength(200)
							.IsUnicode(false);
			entity.Property(e => e.CourseCategory)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.CourseDuration)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.CourseFee).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.CourseLevel)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.CourseTitle)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.DocumentId)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.EndDate).HasColumnType("datetime");
			entity.Property(e => e.FundsRequirementforVisa)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.GeneralEligibility)
							.HasMaxLength(200)
							.IsUnicode(false);
			entity.Property(e => e.InstitutionalBenefits)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.KeyModules)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.LanguagesRequirement)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.MonthlyLivingCost).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.PartTimeWorkDetails)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.StartDate).HasColumnType("datetime");
			entity.Property(e => e.VisaRequirement)
							.HasMaxLength(500)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmCourseIntake>(entity =>
		{
			entity.HasKey(e => e.CourseIntakeId);

			entity.Property(e => e.IntakeTitile)
							.HasMaxLength(100)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmCurrencyInfo>(entity =>
		{
			entity.HasKey(e => e.CurrencyId).HasName("PK_CurrencyInfo");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.CurrencyName).HasMaxLength(50);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmEducationHistory>(entity =>
		{
			entity.HasKey(e => e.EducationHistoryId).HasName("PK__Educatio__576CCA0DF8920341");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DocumentName).HasMaxLength(255);
			entity.Property(e => e.DocumentPath).HasMaxLength(255);
			entity.Property(e => e.Grade).HasMaxLength(50);
			entity.Property(e => e.Institution).HasMaxLength(255);
			entity.Property(e => e.Qualification).HasMaxLength(100);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmEducationHistory)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Education__Appli__02C769E9");
		});

		modelBuilder.Entity<CrmGmatinformation>(entity =>
		{
			entity.HasKey(e => e.GmatinformationId).HasName("PK__GMATInfo__511C53ECA7E93B59");

			entity.ToTable("CrmGMATInformation");

			entity.Property(e => e.GmatinformationId).HasColumnName("GMATInformationId");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.GmatadditionalInformation).HasColumnName("GMATAdditionalInformation");
			entity.Property(e => e.Gmatdate)
							.HasColumnType("datetime")
							.HasColumnName("GMATDate");
			entity.Property(e => e.Gmatlistening)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("GMATListening");
			entity.Property(e => e.GmatoverallScore)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("GMATOverallScore");
			entity.Property(e => e.Gmatreading)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("GMATReading");
			entity.Property(e => e.GmatscannedCopyPath)
							.HasMaxLength(350)
							.HasColumnName("GMATScannedCopyPath");
			entity.Property(e => e.Gmatspeaking)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("GMATSpeaking");
			entity.Property(e => e.Gmatwriting)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("GMATWriting");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmGmatinformation)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__GMATInfor__Appli__05A3D694");
		});

		modelBuilder.Entity<CrmIeltsinformation>(entity =>
		{
			entity.HasKey(e => e.IeltsinformationId).HasName("PK__IELTSInf__F3D98972BEA5442E");

			entity.ToTable("CrmIELTSInformation");

			entity.Property(e => e.IeltsinformationId).HasColumnName("IELTSInformationId");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.IeltsadditionalInformation)
							.IsUnicode(false)
							.HasColumnName("IELTSAdditionalInformation");
			entity.Property(e => e.Ieltsdate)
							.HasColumnType("datetime")
							.HasColumnName("IELTSDate");
			entity.Property(e => e.Ieltslistening)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("IELTSListening");
			entity.Property(e => e.IeltsoverallScore)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("IELTSOverallScore");
			entity.Property(e => e.Ieltsreading)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("IELTSReading");
			entity.Property(e => e.IeltsscannedCopyPath)
							.HasMaxLength(350)
							.HasColumnName("IELTSScannedCopyPath");
			entity.Property(e => e.Ieltsspeaking)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("IELTSSpeaking");
			entity.Property(e => e.Ieltswriting)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("IELTSWriting");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmIeltsinformation)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__IELTSInfo__Appli__0880433F");
		});

		modelBuilder.Entity<CrmInstitute>(entity =>
		{
			entity.HasKey(e => e.InstituteId).HasName("PK_CRMInstitute");

			entity.Property(e => e.ApplicationFee).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.Campus)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.FundsRequirementforVisa)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.InstituteAddress)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.InstituteCode)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.InstituteEmail)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.InstituteMobileNo)
							.HasMaxLength(20)
							.IsUnicode(false);
			entity.Property(e => e.InstituteName)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.InstitutePhoneNo)
							.HasMaxLength(20)
							.IsUnicode(false)
							.HasColumnName("InstitutePhoneNO");
			entity.Property(e => e.InstitutionLogo)
							.HasMaxLength(200)
							.IsUnicode(false);
			entity.Property(e => e.InstitutionProspectus)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.InstitutionStatusNotes)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.InstitutionalBenefits)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.LanguagesRequirement)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.MonthlyLivingCost).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.PartTimeWorkDetails)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.ScholarshipsPolicy)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.Website)
							.HasMaxLength(100)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmInstituteType>(entity =>
		{
			entity.HasKey(e => e.InstituteTypeId).HasName("PK_CRMInstituteType");

			entity.Property(e => e.InstituteTypeName)
							.HasMaxLength(150)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmIntakeMonth>(entity =>
		{
			entity.HasKey(e => e.IntakeMonthId);

			entity.ToTable(tb => tb.HasComment("Stores intake months for CRM applications"));

			entity.HasIndex(e => e.MonthNumber, "IX_CrmIntakeMonth_MonthNumber");

			entity.HasIndex(e => e.IsActive, "IX_CrmIntakeMonth_Status");

			entity.Property(e => e.CreatedDate)
							.HasDefaultValueSql("(getdate())")
							.HasColumnType("datetime");
			entity.Property(e => e.Description)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.IsActive).HasDefaultValue(true);
			entity.Property(e => e.MonthCode)
							.HasMaxLength(10)
							.IsUnicode(false);
			entity.Property(e => e.MonthName)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmIntakeYear>(entity =>
		{
			entity.HasKey(e => e.IntakeYearId);

			entity.ToTable(tb => tb.HasComment("Stores intake years for CRM applications"));

			entity.HasIndex(e => e.IsActive, "IX_CrmIntakeYear_Status");

			entity.HasIndex(e => e.YearValue, "IX_CrmIntakeYear_YearValue");

			entity.Property(e => e.CreatedDate)
							.HasDefaultValueSql("(getdate())")
							.HasColumnType("datetime");
			entity.Property(e => e.Description)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.IsActive).HasDefaultValue(true);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
			entity.Property(e => e.YearCode)
							.HasMaxLength(10)
							.IsUnicode(false);
			entity.Property(e => e.YearName)
							.HasMaxLength(10)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmMonth>(entity =>
		{
			entity.HasKey(e => e.MonthId);

			entity.Property(e => e.MonthCode)
							.HasMaxLength(10)
							.IsUnicode(false);
			entity.Property(e => e.MonthName)
							.HasMaxLength(10)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CrmOthersInformation>(entity =>
		{
			entity.HasKey(e => e.OthersInformationId).HasName("PK__OTHERSIn__213F3EE456434251");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.OthersScannedCopyPath).HasMaxLength(255);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmOthersInformation)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__OTHERSInf__Appli__0B5CAFEA");
		});

		modelBuilder.Entity<CrmPaymentMethod>(entity =>
		{
			entity.HasKey(e => e.PaymentMethodId);

			entity.ToTable(tb => tb.HasComment("Stores payment methods available in CRM system"));

			entity.HasIndex(e => e.IsOnlinePayment, "IX_CrmPaymentMethod_IsOnlinePayment");

			entity.HasIndex(e => e.IsActive, "IX_CrmPaymentMethod_Status");

			entity.Property(e => e.CreatedDate)
							.HasDefaultValueSql("(getdate())")
							.HasColumnType("datetime");
			entity.Property(e => e.Description)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.IsActive).HasDefaultValue(true);
			entity.Property(e => e.PaymentMethodCode)
							.HasMaxLength(20)
							.IsUnicode(false);
			entity.Property(e => e.PaymentMethodName)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.ProcessingFee).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.ProcessingFeeType)
							.HasMaxLength(20)
							.IsUnicode(false);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmPermanentAddress>(entity =>
		{
			entity.HasKey(e => e.PermanentAddressId).HasName("PK__Permanen__3288F26856B2B9D9");

			entity.Property(e => e.Address).HasMaxLength(255);
			entity.Property(e => e.City).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.PostalCode).HasMaxLength(20);
			entity.Property(e => e.State).HasMaxLength(100);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmPermanentAddress)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Permanent__Appli__11158940");
		});

		modelBuilder.Entity<CrmPresentAddress>(entity =>
		{
			entity.HasKey(e => e.PresentAddressId).HasName("PK__PresentA__C0BAC2A24C5CA74C");

			entity.Property(e => e.Address).HasMaxLength(255);
			entity.Property(e => e.City).HasMaxLength(100);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.PostalCode).HasMaxLength(20);
			entity.Property(e => e.State).HasMaxLength(100);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmPresentAddress)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__PresentAd__Appli__13F1F5EB");
		});

		modelBuilder.Entity<CrmPteinformation>(entity =>
		{
			entity.HasKey(e => e.PteinformationId).HasName("PK__PTEInfor__1D54A2410A53FFCD");

			entity.ToTable("CrmPTEInformation");

			entity.Property(e => e.PteinformationId).HasColumnName("PTEInformationId");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.PteadditionalInformation).HasColumnName("PTEAdditionalInformation");
			entity.Property(e => e.Ptedate)
							.HasColumnType("datetime")
							.HasColumnName("PTEDate");
			entity.Property(e => e.Ptelistening)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("PTEListening");
			entity.Property(e => e.PteoverallScore)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("PTEOverallScore");
			entity.Property(e => e.Ptereading)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("PTEReading");
			entity.Property(e => e.PtescannedCopyPath)
							.HasMaxLength(350)
							.HasColumnName("PTEScannedCopyPath");
			entity.Property(e => e.Ptespeaking)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("PTESpeaking");
			entity.Property(e => e.Ptewriting)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("PTEWriting");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmPteinformation)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__PTEInform__Appli__0E391C95");
		});

		modelBuilder.Entity<CrmStatementOfPurpose>(entity =>
		{
			entity.HasKey(e => e.StatementOfPurposeId).HasName("PK__Statemen__88D17C3D66DAD506");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.StatementOfPurposeFilePath).HasMaxLength(255);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<CrmToeflinformation>(entity =>
		{
			entity.HasKey(e => e.ToeflinformationId).HasName("PK__TOEFLInf__BD367513B8466628");

			entity.ToTable("CrmTOEFLInformation");

			entity.Property(e => e.ToeflinformationId).HasColumnName("TOEFLInformationId");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.ToefladditionalInformation)
							.IsUnicode(false)
							.HasColumnName("TOEFLAdditionalInformation");
			entity.Property(e => e.Toefldate)
							.HasColumnType("datetime")
							.HasColumnName("TOEFLDate");
			entity.Property(e => e.Toefllistening)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("TOEFLListening");
			entity.Property(e => e.ToefloverallScore)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("TOEFLOverallScore");
			entity.Property(e => e.Toeflreading)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("TOEFLReading");
			entity.Property(e => e.ToeflscannedCopyPath)
							.HasMaxLength(350)
							.HasColumnName("TOEFLScannedCopyPath");
			entity.Property(e => e.Toeflspeaking)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("TOEFLSpeaking");
			entity.Property(e => e.Toeflwriting)
							.HasColumnType("decimal(18, 2)")
							.HasColumnName("TOEFLWriting");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmToeflinformation)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__TOEFLInfo__Appli__19AACF41");
		});

		modelBuilder.Entity<CrmWorkExperience>(entity =>
		{
			entity.HasKey(e => e.WorkExperienceId).HasName("PK__WorkExpe__55A2B889125C12F5");

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DocumentName).HasMaxLength(255);
			entity.Property(e => e.EndDate).HasColumnType("datetime");
			entity.Property(e => e.NameOfEmployer).HasMaxLength(255);
			entity.Property(e => e.Period).HasColumnType("decimal(18, 2)");
			entity.Property(e => e.Position).HasMaxLength(100);
			entity.Property(e => e.ScannedCopyPath).HasMaxLength(350);
			entity.Property(e => e.StartDate).HasColumnType("datetime");
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

			entity.HasOne(d => d.Applicant).WithMany(p => p.CrmWorkExperience)
							.HasForeignKey(d => d.ApplicantId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__WorkExper__Appli__1C873BEC");
		});

		modelBuilder.Entity<CrmYear>(entity =>
		{
			entity.HasKey(e => e.YearId);

			entity.Property(e => e.YearCode)
							.HasMaxLength(10)
							.IsUnicode(false);
			entity.Property(e => e.YearName)
							.HasMaxLength(10)
							.IsUnicode(false);
		});

		modelBuilder.Entity<CurencyRate>(entity =>
		{
			entity.Property(e => e.CreateDate).HasColumnType("datetime");
			entity.Property(e => e.CurrencyMonth).HasColumnType("datetime");
			entity.Property(e => e.CurrencyRateRation).HasColumnType("decimal(18, 2)");
		});

		modelBuilder.Entity<Currency>(entity =>
		{
			entity.Property(e => e.CurrencyCode)
							.HasMaxLength(5)
							.IsUnicode(false);
			entity.Property(e => e.CurrencyName)
							.HasMaxLength(50)
							.IsUnicode(false);
		});

		modelBuilder.Entity<DeligationInfo>(entity =>
		{
			entity.HasKey(e => e.DeligationId).HasName("PK_Deligation");
		});

		modelBuilder.Entity<Department>(entity =>
		{
			entity.Property(e => e.DepartmentId).ValueGeneratedNever();
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DepartmentCode).HasMaxLength(50);
			entity.Property(e => e.DepartmentName).HasMaxLength(250);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<DmsDocument>(entity =>
		{
			entity.HasKey(e => e.DocumentId).HasName("PK__DMSDocum__1ABEEF0FA80AC05E");

			entity.Property(e => e.FileExtension).HasMaxLength(10);
			entity.Property(e => e.FileName).HasMaxLength(255);
			entity.Property(e => e.ReferenceEntityId).HasMaxLength(50);
			entity.Property(e => e.ReferenceEntityType).HasMaxLength(50);
			entity.Property(e => e.SystemTag)
							.HasMaxLength(200)
							.IsUnicode(false);
			entity.Property(e => e.Title).HasMaxLength(255);
			entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())", "DF__DMSDocume__Uploa__02D3ED8F");
			entity.Property(e => e.UploadedByUserId)
							.HasMaxLength(50)
							.IsUnicode(false);

			entity.HasOne(d => d.DocumentType).WithMany(p => p.DmsDocument)
							.HasForeignKey(d => d.DocumentTypeId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_Dmsdocument_DmsdocumentType");
		});

		modelBuilder.Entity<DmsDocumentAccessLog>(entity =>
		{
			entity.HasKey(e => e.LogId).HasName("PK__DMSDocum__5E548648EC7B75AF");

			entity.Property(e => e.AccessDateTime).HasDefaultValueSql("(getdate())", "DF__DMSDocume__Acces__1216311F");
			entity.Property(e => e.AccessedByUserId)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.Action).HasMaxLength(50);
			entity.Property(e => e.DeviceInfo)
							.HasMaxLength(200)
							.IsUnicode(false);
			entity.Property(e => e.IpAddress)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.MacAddress)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.Notes)
							.HasMaxLength(150)
							.IsUnicode(false);

			entity.HasOne(d => d.Document).WithMany(p => p.DmsDocumentAccessLog)
							.HasForeignKey(d => d.DocumentId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_DmsdocumentAccessLog_Dmsdocument");
		});

		modelBuilder.Entity<DmsDocumentFolder>(entity =>
		{
			entity.HasKey(e => e.FolderId).HasName("PK__DMSDocum__ACD7107FD7A53641");

			entity.Property(e => e.FolderName).HasMaxLength(255);
			entity.Property(e => e.OwnerId)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.ReferenceEntityId).HasMaxLength(50);
			entity.Property(e => e.ReferenceEntityType).HasMaxLength(150);

			entity.HasOne(d => d.ParentFolder).WithMany(p => p.InverseParentFolder)
							.HasForeignKey(d => d.ParentFolderId)
							.HasConstraintName("FK_DocumentFolder_ParentFolder");
		});

		modelBuilder.Entity<DmsDocumentTag>(entity =>
		{
			entity.HasKey(e => e.TagId).HasName("PK__DMSDocum__657CF9AC43C5B9E0");

			entity.HasIndex(e => e.DocumentTagName, "UQ__DMSDocum__737584F60E3D41BA").IsUnique();

			entity.Property(e => e.DocumentTagName).HasMaxLength(200);
		});

		modelBuilder.Entity<DmsDocumentTagMap>(entity =>
		{
			entity.HasKey(e => e.TagMapId).HasName("PK_DMSDocumentTagMap");

			entity.HasOne(d => d.Document).WithMany(p => p.DmsDocumentTagMap)
							.HasForeignKey(d => d.DocumentId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_DmsdocumentTagMap_Dmsdocument");

			entity.HasOne(d => d.Tag).WithMany(p => p.DmsDocumentTagMap)
							.HasForeignKey(d => d.TagId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_DmsdocumentTagMap_DmsdocumentTag");
		});

		modelBuilder.Entity<DmsDocumentType>(entity =>
		{
			entity.HasKey(e => e.DocumentTypeId).HasName("PK__DMSDocum__DBA390E192D25821");

			entity.Property(e => e.AcceptedExtensions).HasMaxLength(255);
			entity.Property(e => e.DocumentType).HasMaxLength(100);
			entity.Property(e => e.MaxFileSizeMb).HasColumnName("MaxFileSizeMB");
			entity.Property(e => e.Name).HasMaxLength(100);
		});

		modelBuilder.Entity<DmsDocumentVersion>(entity =>
		{
			entity.HasKey(e => e.VersionId).HasName("PK__DMSDocum__16C6400F35C8BCE0");

			entity.HasIndex(e => new { e.DocumentId, e.VersionNumber }, "UQ_DocumentVersion_DocumentId_VersionNumber").IsUnique();

			entity.Property(e => e.FileName).HasMaxLength(255);
			entity.Property(e => e.UploadedBy)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.UploadedDate).HasDefaultValueSql("(getdate())", "DF__DMSDocume__Uploa__0E45A03B");

			entity.HasOne(d => d.Document).WithMany(p => p.DmsDocumentVersion)
							.HasForeignKey(d => d.DocumentId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_DmsdocumentVersion_Dmsdocument");
		});

		modelBuilder.Entity<DmsFileUpdateHistory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__DmsFileU__3214EC070B58ED2A");

			entity.Property(e => e.DocumentType).HasMaxLength(255);
			entity.Property(e => e.EntityId).HasMaxLength(255);
			entity.Property(e => e.EntityType).HasMaxLength(255);
			entity.Property(e => e.UpdateReason).HasMaxLength(500);
			entity.Property(e => e.UpdatedBy).HasMaxLength(255);
		});

		modelBuilder.Entity<Docmdetails>(entity =>
		{
			entity.HasKey(e => e.DocumentId);

			entity.ToTable("DOCMDETAILS");

			entity.Property(e => e.DocumentId).HasColumnName("DOCUMENT_ID");
			entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
			entity.Property(e => e.Filedescription)
							.HasMaxLength(500)
							.HasColumnName("FILEDESCRIPTION");
			entity.Property(e => e.Filename)
							.HasMaxLength(500)
							.HasColumnName("FILENAME");
			entity.Property(e => e.Fullpath)
							.HasMaxLength(1000)
							.HasColumnName("FULLPATH");
			entity.Property(e => e.Lastopenorclosebyid).HasColumnName("LASTOPENORCLOSEBYID");
			entity.Property(e => e.Lastupdate)
							.HasColumnType("datetime")
							.HasColumnName("LASTUPDATE");
			entity.Property(e => e.Remarks)
							.HasMaxLength(1000)
							.HasColumnName("REMARKS");
			entity.Property(e => e.Responsiblepersonto).HasColumnName("RESPONSIBLEPERSONTO");
			entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
			entity.Property(e => e.Subject)
							.HasMaxLength(500)
							.HasColumnName("SUBJECT");
			entity.Property(e => e.UploadedBy).HasColumnName("UPLOADED_BY");
			entity.Property(e => e.UploadedDate)
							.HasColumnType("datetime")
							.HasColumnName("UPLOADED_DATE");
		});

		modelBuilder.Entity<Docmdetailshistory>(entity =>
		{
			entity.HasKey(e => e.DocumentHistoryId);

			entity.ToTable("DOCMDETAILSHISTORY");

			entity.Property(e => e.DocumentHistoryId).HasColumnName("DOCUMENT_HISTORY_ID");
			entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
			entity.Property(e => e.DocumentId).HasColumnName("DOCUMENT_ID");
			entity.Property(e => e.Filedescription)
							.HasMaxLength(500)
							.HasColumnName("FILEDESCRIPTION");
			entity.Property(e => e.Filename)
							.HasMaxLength(500)
							.HasColumnName("FILENAME");
			entity.Property(e => e.Fullpath)
							.HasMaxLength(1000)
							.HasColumnName("FULLPATH");
			entity.Property(e => e.Lastopenorclosebyid).HasColumnName("LASTOPENORCLOSEBYID");
			entity.Property(e => e.Lastupdate)
							.HasDefaultValueSql("(getdate())", "DF__DOCMDETAI__LASTU__2EA5EC27")
							.HasColumnType("datetime")
							.HasColumnName("LASTUPDATE");
			entity.Property(e => e.Remarks)
							.HasMaxLength(1000)
							.HasColumnName("REMARKS");
			entity.Property(e => e.Responsiblepersonto).HasColumnName("RESPONSIBLEPERSONTO");
			entity.Property(e => e.Status).HasColumnName("STATUS");
			entity.Property(e => e.Subject)
							.HasMaxLength(500)
							.HasColumnName("SUBJECT");
			entity.Property(e => e.UploadedBy).HasColumnName("UPLOADED_BY");
			entity.Property(e => e.UploadedDate)
							.HasColumnType("datetime")
							.HasColumnName("UPLOADED_DATE");
		});

		modelBuilder.Entity<Documanttype>(entity =>
		{
			entity.HasKey(e => e.Documenttypeid);

			entity.ToTable("DOCUMANTTYPE");

			entity.Property(e => e.Documenttypeid).HasColumnName("DOCUMENTTYPEID");
			entity.Property(e => e.Description)
							.HasColumnType("text")
							.HasColumnName("DESCRIPTION");
			entity.Property(e => e.Documentname)
							.HasMaxLength(100)
							.HasColumnName("DOCUMENTNAME");
			entity.Property(e => e.Initiationdate)
							.HasColumnType("datetime")
							.HasColumnName("INITIATIONDATE");
			entity.Property(e => e.UseType)
							.HasComment("1=Personal Document,2=Applicant Document")
							.HasDefaultValue(1, "DF_DOCUMANTTYPE_UseType");
		});

		modelBuilder.Entity<Document>(entity =>
		{
			entity.ToTable("DOCUMENT");

			entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");
			entity.Property(e => e.Attacheddocument)
							.HasMaxLength(200)
							.HasColumnName("ATTACHEDDOCUMENT");
			entity.Property(e => e.Documenttypeid).HasColumnName("DOCUMENTTYPEID");
			entity.Property(e => e.Hrrecordid).HasColumnName("HRRECORDID");
			entity.Property(e => e.Summary)
							.HasMaxLength(2000)
							.HasColumnName("SUMMARY");
			entity.Property(e => e.Titleofdocument)
							.HasMaxLength(200)
							.HasColumnName("TITLEOFDOCUMENT");
		});

		modelBuilder.Entity<DocumentParameter>(entity =>
		{
			entity.HasKey(e => e.ParameterId);

			entity.Property(e => e.CaseCading)
							.HasMaxLength(100)
							.IsUnicode(false);
			entity.Property(e => e.ControlRole)
							.HasMaxLength(50)
							.IsUnicode(false)
							.HasColumnName("Control_Role");
			entity.Property(e => e.DataSource)
							.HasMaxLength(250)
							.IsUnicode(false);
			entity.Property(e => e.DataTextField)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.DataValueField)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.ParameterKey)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.ParameterName)
							.HasMaxLength(100)
							.IsUnicode(false);
		});

		modelBuilder.Entity<DocumentParameterMapping>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.IsVisible).HasDefaultValue(true);
			entity.Property(e => e.MappingId).ValueGeneratedOnAdd();

			entity.HasOne(d => d.DocumentType).WithMany()
							.HasForeignKey(d => d.DocumentTypeId)
							.HasConstraintName("FK_DocumentParameterMapping_DOCUMANTTYPE");

			entity.HasOne(d => d.Parameter).WithMany()
							.HasForeignKey(d => d.ParameterId)
							.HasConstraintName("FK_DocumentParameterMapping_DocumentParameter");
		});

		modelBuilder.Entity<DocumentQueryMapping>(entity =>
		{
			entity.HasKey(e => e.DocumentQueryId);

			entity.HasIndex(e => new { e.DocumentTypeId, e.ReportHeaderId }, "IX_DocumentQueryMapping").IsUnique();

			entity.Property(e => e.ParameterDefination)
							.HasMaxLength(1000)
							.IsUnicode(false);
		});

		modelBuilder.Entity<DocumentTemplate>(entity =>
		{
			entity.HasKey(e => e.DocumentId);

			entity.HasIndex(e => e.TemplateName, "IX_DocumentTemplate").IsUnique();

			entity.Property(e => e.DocumentText).IsUnicode(false);
			entity.Property(e => e.DocumentTitle).HasMaxLength(200);
			entity.Property(e => e.TemplateName).HasMaxLength(100);
		});

		modelBuilder.Entity<Employee>(entity =>
		{
			entity.HasKey(e => e.HrrecordId);

			entity.Property(e => e.HrrecordId).HasColumnName("HRRecordId");
			entity.Property(e => e.AdditionalInfo).HasMaxLength(50);
			entity.Property(e => e.ApproveDate).HasColumnType("smalldatetime");
			entity.Property(e => e.Birthidentification)
							.HasMaxLength(100)
							.HasColumnName("BIRTHIDENTIFICATION");
			entity.Property(e => e.BloodGroup).HasMaxLength(50);
			entity.Property(e => e.DateofBirth).HasColumnType("datetime");
			entity.Property(e => e.DateofMarriage).HasColumnType("datetime");
			entity.Property(e => e.FatherName).HasMaxLength(500);
			entity.Property(e => e.FullName).HasMaxLength(500);
			entity.Property(e => e.Height)
							.HasMaxLength(50)
							.HasColumnName("HEIGHT");
			entity.Property(e => e.Hobby)
							.HasMaxLength(2000)
							.HasColumnName("HOBBY");
			entity.Property(e => e.HomePhone).HasMaxLength(50);
			entity.Property(e => e.Identificationmark)
							.HasMaxLength(1000)
							.HasColumnName("IDENTIFICATIONMARK");
			entity.Property(e => e.Investmentamount).HasColumnName("INVESTMENTAMOUNT");
			entity.Property(e => e.LastUpdatedDate).HasColumnType("smalldatetime");
			entity.Property(e => e.Meritialstatus).HasColumnName("MERITIALSTATUS");
			entity.Property(e => e.MobileNo).HasMaxLength(500);
			entity.Property(e => e.MotherName).HasMaxLength(500);
			entity.Property(e => e.NationalId)
							.HasMaxLength(250)
							.HasColumnName("NationalID");
			entity.Property(e => e.OriginalBirthDay).HasMaxLength(50);
			entity.Property(e => e.PassportNo).HasMaxLength(250);
			entity.Property(e => e.Passportexpiredate)
							.HasColumnType("datetime")
							.HasColumnName("PASSPORTEXPIREDATE");
			entity.Property(e => e.Passportissuedate)
							.HasColumnType("datetime")
							.HasColumnName("PASSPORTISSUEDATE");
			entity.Property(e => e.PermanentPostCode).HasMaxLength(50);
			entity.Property(e => e.PersonalEmail).HasMaxLength(250);
			entity.Property(e => e.Placeofpassportissue).HasColumnName("PLACEOFPASSPORTISSUE");
			entity.Property(e => e.PresentPostCode).HasMaxLength(50);
			entity.Property(e => e.Profilepicture)
							.HasMaxLength(2000)
							.HasColumnName("PROFILEPICTURE");
			entity.Property(e => e.Refempid)
							.HasMaxLength(50)
							.HasColumnName("REFEMPID");
			entity.Property(e => e.ShortName).HasMaxLength(50);
			entity.Property(e => e.Signature)
							.HasMaxLength(2000)
							.HasColumnName("SIGNATURE");
			entity.Property(e => e.SpouseName).HasMaxLength(500);
			entity.Property(e => e.Taxexamption).HasColumnName("TAXEXAMPTION");
			entity.Property(e => e.Weight)
							.HasMaxLength(50)
							.HasColumnName("WEIGHT");
		});

		modelBuilder.Entity<Employeetype>(entity =>
		{
			entity.ToTable("EMPLOYEETYPE");

			entity.Property(e => e.Employeetypeid).HasColumnName("EMPLOYEETYPEID");
			entity.Property(e => e.EmployeeTypeCode).HasMaxLength(50);
			entity.Property(e => e.Employeetypename)
							.HasMaxLength(50)
							.HasColumnName("EMPLOYEETYPENAME");
			entity.Property(e => e.IsContract).HasDefaultValue(false);
		});

		modelBuilder.Entity<Employment>(entity =>
		{
			entity.HasKey(e => e.HrrecordId);

			entity.Property(e => e.HrrecordId)
							.ValueGeneratedNever()
							.HasColumnName("HRRecordId");
			entity.Property(e => e.AttendanceCardNo).HasMaxLength(50);
			entity.Property(e => e.BankAccountNo).HasMaxLength(50);
			entity.Property(e => e.Branchid).HasColumnName("BRANCHID");
			entity.Property(e => e.ContactAddress)
							.HasMaxLength(300)
							.IsUnicode(false);
			entity.Property(e => e.Designationid).HasColumnName("DESIGNATIONID");
			entity.Property(e => e.EmergencyContactName).HasMaxLength(250);
			entity.Property(e => e.EmergencyContactNo).HasMaxLength(250);
			entity.Property(e => e.EmployeeId).HasMaxLength(50);
			entity.Property(e => e.Experience)
							.HasMaxLength(2000)
							.HasColumnName("EXPERIENCE");
			entity.Property(e => e.FuncId).HasColumnName("Func_Id");
			entity.Property(e => e.Gpfno)
							.HasMaxLength(100)
							.HasColumnName("GPFNO");
			entity.Property(e => e.IsOteligible).HasColumnName("IsOTEligible");
			entity.Property(e => e.Joiningpost).HasColumnName("JOININGPOST");
			entity.Property(e => e.LastUpdatedDate).HasColumnType("smalldatetime");
			entity.Property(e => e.OfficialEmail).HasMaxLength(250);
			entity.Property(e => e.Reportdepid).HasColumnName("REPORTDEPID");
			entity.Property(e => e.SeparationRemarks).HasMaxLength(250);
			entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");
			entity.Property(e => e.StartDate).HasColumnType("datetime");
			entity.Property(e => e.TelephoneExtension).HasMaxLength(50);
			entity.Property(e => e.TinNumber).HasMaxLength(50);
		});

		modelBuilder.Entity<GroupMember>(entity =>
		{
			entity.HasKey(e => new { e.GroupId, e.UserId });

			entity.Property(e => e.GroupOption).HasMaxLength(50);
		});

		modelBuilder.Entity<GroupPermission>(entity =>
		{
			entity.HasKey(e => e.PermissionId);

			entity.Property(e => e.Groupid).HasColumnName("GROUPID");
			entity.Property(e => e.Parentpermission).HasColumnName("PARENTPERMISSION");
			entity.Property(e => e.Permissiontablename)
							.HasMaxLength(50)
							.HasColumnName("PERMISSIONTABLENAME");
			entity.Property(e => e.Referenceid).HasColumnName("REFERENCEID");
		});

		modelBuilder.Entity<Groups>(entity =>
		{
			entity.HasKey(e => e.GroupId);

			entity.Property(e => e.GroupName).HasMaxLength(100);
		});

		modelBuilder.Entity<Holiday>(entity =>
		{
			entity.Property(e => e.HolidayId).HasColumnName("HolidayID");
			entity.Property(e => e.DayName)
							.HasMaxLength(20)
							.IsUnicode(false);
			entity.Property(e => e.Description).HasMaxLength(500);
			entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
			entity.Property(e => e.MonthName)
							.HasMaxLength(50)
							.IsUnicode(false);
			entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");
		});

		modelBuilder.Entity<MaritalStatus>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.MaritalStatusId).ValueGeneratedOnAdd();
			entity.Property(e => e.MaritalStatusName).HasMaxLength(250);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<Menu>(entity =>
		{
			entity.Property(e => e.MenuId).HasColumnName("MenuID");
			entity.Property(e => e.MenuName).HasMaxLength(50);
			entity.Property(e => e.MenuPath).HasMaxLength(200);
			entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
			entity.Property(e => e.Sororder).HasColumnName("SORORDER");
			entity.Property(e => e.Todo).HasColumnName("TODO");
		});

		modelBuilder.Entity<Module>(entity =>
		{
			entity.Property(e => e.ModuleName).HasMaxLength(50);
		});

		modelBuilder.Entity<PasswordHistory>(entity =>
		{
			entity.HasKey(e => e.HistoryId);

			entity.Property(e => e.OldPassword).HasMaxLength(50);
			entity.Property(e => e.PasswordChangeDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<RefreshTokens>(entity =>
		{
			entity.HasKey(e => e.RefreshTokenId).HasName("PK__RefreshT__F5845E3997C19564");

			entity.Property(e => e.CreatedByIp).HasMaxLength(100);
			entity.Property(e => e.ReplacedByToken).HasMaxLength(500);
			entity.Property(e => e.Token).HasMaxLength(500);
		});

		modelBuilder.Entity<ReportBuilder>(entity =>
		{
			entity.HasKey(e => e.ReportHeaderId);

			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.OrderByColumn)
							.HasMaxLength(500)
							.IsUnicode(false);
			entity.Property(e => e.ReportHeader).HasMaxLength(250);
			entity.Property(e => e.ReportTitle).HasMaxLength(250);
			entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<SystemSettings>(entity =>
		{
			entity.HasKey(e => e.SettingsId);

			entity.Property(e => e.CasualWorkerAmount).HasColumnType("decimal(18, 0)");
			entity.Property(e => e.CustomStatusForNoOutPunch).HasMaxLength(250);
			entity.Property(e => e.IsOtcalculateOnHolidayWekend).HasColumnName("IsOTCalculateOnHolidayWekend");
			entity.Property(e => e.IsWebLoginEnable)
							.HasComment("0=Disable,1=Enable")
							.HasDefaultValue(0, "DF__SystemSet__IsWeb__2B9F624A");
			entity.Property(e => e.Language).HasMaxLength(50);
			entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
			entity.Property(e => e.OdbcClientList).HasComment("0=Native SQL, 1=ODBC");
			entity.Property(e => e.PassResetBy).HasComment("1=SysAdmin, 2=User");
			entity.Property(e => e.PassType).HasComment("1=Alphanumeric, 2=Alphabetic, 3=Numeric");
			entity.Property(e => e.ResetPass).HasMaxLength(100);
			entity.Property(e => e.Theme).HasMaxLength(50);
		});

		modelBuilder.Entity<Thana>(entity =>
		{
			entity.Property(e => e.ThanaCode).HasMaxLength(50);
			entity.Property(e => e.ThanaName).HasMaxLength(100);
			entity.Property(e => e.ThanaNameBn)
							.HasMaxLength(100)
							.HasColumnName("ThanaName_bn");
		});

		modelBuilder.Entity<Timesheet>(entity =>
		{
			entity.ToTable("TIMESHEET");

			entity.Property(e => e.Timesheetid).HasColumnName("TIMESHEETID");
			entity.Property(e => e.ApproveDate)
							.HasColumnType("datetime")
							.HasColumnName("APPROVE_DATE");
			entity.Property(e => e.ApproveRhRrecordid).HasColumnName("APPROVE_RH_RRECORDID");
			entity.Property(e => e.BillStatus).HasColumnName("BILL_STATUS");
			entity.Property(e => e.BillableLogHour).HasColumnName("BILLABLE_LOG_HOUR");
			entity.Property(e => e.Hrrecordid).HasColumnName("HRRECORDID");
			entity.Property(e => e.Isapprove).HasColumnName("ISAPPROVE");
			entity.Property(e => e.LogEntryDate)
							.HasColumnType("datetime")
							.HasColumnName("LOG_ENTRY_DATE");
			entity.Property(e => e.NoBillableLogHour).HasColumnName("NO_BILLABLE_LOG_HOUR");
			entity.Property(e => e.Projectid).HasColumnName("PROJECTID");
			entity.Property(e => e.Taskid).HasColumnName("TASKID");
			entity.Property(e => e.WorkedLogHour).HasColumnName("WORKED_LOG_HOUR");
			entity.Property(e => e.WorkingLogDate)
							.HasColumnType("datetime")
							.HasColumnName("WORKING_LOG_DATE");
		});

		modelBuilder.Entity<TokenBlacklist>(entity =>
		{
			entity.HasNoKey();

			entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
		});

		modelBuilder.Entity<Users>(entity =>
		{
			entity.HasKey(e => e.UserId).HasName("PK_User");

			entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.EmployeeId).HasComment("EmployeeId As HrRecordId");
			entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
			entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
			entity.Property(e => e.LoginId).HasMaxLength(50);
			entity.Property(e => e.Password).HasMaxLength(100);
			entity.Property(e => e.Theme)
							.HasMaxLength(100)
							.HasColumnName("THEME");
			entity.Property(e => e.UserName).HasMaxLength(500);
		});

		modelBuilder.Entity<WfAction>(entity =>
		{
			entity.HasKey(e => e.WfactionId).HasName("PK_WFAction");

			entity.Property(e => e.WfactionId).HasColumnName("WFActionId");
			entity.Property(e => e.ActionName).HasMaxLength(50);
			entity.Property(e => e.EmailAlert).HasColumnName("EMAIL_ALERT");
			entity.Property(e => e.SmsAlert).HasColumnName("SMS_ALERT");
			entity.Property(e => e.WfstateId).HasColumnName("WFStateId");
		});

		modelBuilder.Entity<WfState>(entity =>
		{
			entity.HasKey(e => e.WfstateId).HasName("PK_WFState");

			entity.Property(e => e.WfstateId).HasColumnName("WFStateId");
			entity.Property(e => e.Sequence).HasColumnName("sequence");
			entity.Property(e => e.StateName).HasMaxLength(50);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
