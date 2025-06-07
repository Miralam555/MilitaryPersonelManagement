using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InjunctionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InjunctionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjunctionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPenaltyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PenaltyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPenaltyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PersonelSurname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonels", x => x.PersonelID);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleHistory",
                columns: table => new
                {
                    BattleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    BattleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InjuryOrDiseaseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VeteranNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleHistory", x => x.BattleID);
                    table.ForeignKey(
                        name: "FK_BattleHistory_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    RelationShip = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberPatronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "Injunctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InjunctionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InjuctionStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InjunctionIsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    InjunctionTypeId = table.Column<int>(type: "int", nullable: false),
                    IssuedByPersonelId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injunctions_InjunctionTypes_InjunctionTypeId",
                        column: x => x.InjunctionTypeId,
                        principalTable: "InjunctionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Injunctions_MilitaryPersonels_IssuedByPersonelId",
                        column: x => x.IssuedByPersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryMedicalAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    AssesmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryMedicalAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryMedicalAssessments_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelEducation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GraduationYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EducationTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelEducation_EducationTypes_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelEducation_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelInfos_MaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelInfos_MilitaryPersonels_Id",
                        column: x => x.Id,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelReputationRiskFindings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingAgency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelReputationRiskFindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelReputationRiskFindings_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelSpecialSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelSpecialSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelSpecialSkills_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "PreMilitaryWorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    WorkStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMilitaryWorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreMilitaryWorkExperience_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceYearsWithBenefits",
                columns: table => new
                {
                    BenefitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    AppoinmentOrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReleaseOrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitDocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BenefitDocumentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BenefitDocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceYearsWithBenefits", x => x.BenefitID);
                    table.ForeignKey(
                        name: "FK_ServiceYearsWithBenefits_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "SpecialRecords",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilitaryPersonelId = table.Column<int>(type: "int", nullable: false),
                    InformationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRecords", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_SpecialRecords_MilitaryPersonels_MilitaryPersonelId",
                        column: x => x.MilitaryPersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrimeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    ChargeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeDuration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PenalInstitution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrimeRecords_FamilyMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_CrimeRecords_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembersInService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembersInService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembersInService_FamilyMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "MemberID");
                    table.ForeignKey(
                        name: "FK_FamilyMembersInService_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelFamilyMemberForeignTravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TravellingCountryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TravelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelFamilyMemberForeignTravel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelFamilyMemberForeignTravel_FamilyMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "MemberID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelForeignLanguageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LanguageLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowanceInjunctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelForeignLanguageLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelForeignLanguageLevels_Injunctions_AllowanceInjunctionId",
                        column: x => x.AllowanceInjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelForeignLanguageLevels_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelForeignTravels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TravellingCountryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TravelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelForeignTravels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelForeignTravels_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelForeignTravels_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelPenalties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    PenaltyTypeId = table.Column<int>(type: "int", nullable: false),
                    PenaltyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelPenalties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelPenalties_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelPenalties_MilitaryPenaltyTypes_PenaltyTypeId",
                        column: x => x.PenaltyTypeId,
                        principalTable: "MilitaryPenaltyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelPenalties_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryPersonelRecognition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: true),
                    Injunctionİd = table.Column<int>(type: "int", nullable: false),
                    RecognitionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryPersonelRecognition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelRecognition_Injunctions_Injunctionİd",
                        column: x => x.Injunctionİd,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryPersonelRecognition_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    RankName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryRanks_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryRanks_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryServiceExtension",
                columns: table => new
                {
                    ExtensionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryServiceExtension", x => x.ExtensionID);
                    table.ForeignKey(
                        name: "FK_MilitaryServiceExtension_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryServiceExtension_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OfficialRank = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsCurrentMilitary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryServiceHistories_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryServiceHistories_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "MilitarySkillRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    SkillDegree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IssuedByInjunctionId = table.Column<int>(type: "int", nullable: false),
                    ApprovedByInjunctionId = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitarySkillRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitarySkillRecords_Injunctions_ApprovedByInjunctionId",
                        column: x => x.ApprovedByInjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitarySkillRecords_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalDevelopmentCourses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    InjunctionId = table.Column<int>(type: "int", nullable: false),
                    OrganizedLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsCurrentMilitary = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDevelopmentCourses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_ProfessionalDevelopmentCourses_Injunctions_InjunctionId",
                        column: x => x.InjunctionId,
                        principalTable: "Injunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfessionalDevelopmentCourses_MilitaryPersonels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "MilitaryPersonels",
                        principalColumn: "PersonelID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleHistory_PersonelId",
                table: "BattleHistory",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeRecords_MemberId",
                table: "CrimeRecords",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeRecords_PersonelId",
                table: "CrimeRecords",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_PersonelId",
                table: "FamilyMembers",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembersInService_MemberId",
                table: "FamilyMembersInService",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembersInService_PersonelId",
                table: "FamilyMembersInService",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Injunctions_InjunctionTypeId",
                table: "Injunctions",
                column: "InjunctionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Injunctions_IssuedByPersonelId",
                table: "Injunctions",
                column: "IssuedByPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaritalStatus_StatusName",
                table: "MaritalStatus",
                column: "StatusName",
                unique: true,
                filter: "[StatusName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryMedicalAssessments_PersonelId",
                table: "MilitaryMedicalAssessments",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelEducation_EducationTypeId",
                table: "MilitaryPersonelEducation",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelEducation_PersonelId",
                table: "MilitaryPersonelEducation",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelFamilyMemberForeignTravel_MemberId",
                table: "MilitaryPersonelFamilyMemberForeignTravel",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelForeignLanguageLevels_AllowanceInjunctionId",
                table: "MilitaryPersonelForeignLanguageLevels",
                column: "AllowanceInjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelForeignLanguageLevels_PersonelId",
                table: "MilitaryPersonelForeignLanguageLevels",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelForeignTravels_InjunctionId",
                table: "MilitaryPersonelForeignTravels",
                column: "InjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelForeignTravels_PersonelId",
                table: "MilitaryPersonelForeignTravels",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelInfos_IdentityCardNumber",
                table: "MilitaryPersonelInfos",
                column: "IdentityCardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelInfos_MaritalStatusId",
                table: "MilitaryPersonelInfos",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelInfos_PIN",
                table: "MilitaryPersonelInfos",
                column: "PIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelPenalties_InjunctionId",
                table: "MilitaryPersonelPenalties",
                column: "InjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelPenalties_PenaltyTypeId",
                table: "MilitaryPersonelPenalties",
                column: "PenaltyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelPenalties_PersonelId",
                table: "MilitaryPersonelPenalties",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelRecognition_Injunctionİd",
                table: "MilitaryPersonelRecognition",
                column: "Injunctionİd");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelRecognition_PersonelId",
                table: "MilitaryPersonelRecognition",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelReputationRiskFindings_PersonelId",
                table: "MilitaryPersonelReputationRiskFindings",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryPersonelSpecialSkills_PersonelId",
                table: "MilitaryPersonelSpecialSkills",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryRanks_InjunctionId",
                table: "MilitaryRanks",
                column: "InjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryRanks_PersonelId",
                table: "MilitaryRanks",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceExtension_InjunctionId",
                table: "MilitaryServiceExtension",
                column: "InjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceExtension_PersonelId",
                table: "MilitaryServiceExtension",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceHistories_InjunctionId",
                table: "MilitaryServiceHistories",
                column: "InjunctionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryServiceHistories_PersonelId",
                table: "MilitaryServiceHistories",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitarySkillRecords_ApprovedByInjunctionId",
                table: "MilitarySkillRecords",
                column: "ApprovedByInjunctionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitarySkillRecords_PersonelId",
                table: "MilitarySkillRecords",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PreMilitaryWorkExperience_PersonelId",
                table: "PreMilitaryWorkExperience",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDevelopmentCourses_InjunctionId",
                table: "ProfessionalDevelopmentCourses",
                column: "InjunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDevelopmentCourses_PersonelId",
                table: "ProfessionalDevelopmentCourses",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceYearsWithBenefits_PersonelId",
                table: "ServiceYearsWithBenefits",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRecords_MilitaryPersonelId",
                table: "SpecialRecords",
                column: "MilitaryPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleHistory");

            migrationBuilder.DropTable(
                name: "CrimeRecords");

            migrationBuilder.DropTable(
                name: "FamilyMembersInService");

            migrationBuilder.DropTable(
                name: "MilitaryMedicalAssessments");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelEducation");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelFamilyMemberForeignTravel");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelForeignLanguageLevels");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelForeignTravels");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelInfos");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelPenalties");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelRecognition");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelReputationRiskFindings");

            migrationBuilder.DropTable(
                name: "MilitaryPersonelSpecialSkills");

            migrationBuilder.DropTable(
                name: "MilitaryRanks");

            migrationBuilder.DropTable(
                name: "MilitaryServiceExtension");

            migrationBuilder.DropTable(
                name: "MilitaryServiceHistories");

            migrationBuilder.DropTable(
                name: "MilitarySkillRecords");

            migrationBuilder.DropTable(
                name: "PreMilitaryWorkExperience");

            migrationBuilder.DropTable(
                name: "ProfessionalDevelopmentCourses");

            migrationBuilder.DropTable(
                name: "ServiceYearsWithBenefits");

            migrationBuilder.DropTable(
                name: "SpecialRecords");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "MilitaryPenaltyTypes");

            migrationBuilder.DropTable(
                name: "Injunctions");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InjunctionTypes");

            migrationBuilder.DropTable(
                name: "MilitaryPersonels");
        }
    }
}
