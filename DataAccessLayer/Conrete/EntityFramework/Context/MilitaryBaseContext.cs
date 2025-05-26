using Core.Entities;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyMilitaryFinalProject.Entities.Concrete;
using MyMilitaryFinalProject.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework.Context
{
    public class MilitaryBaseContext:DbContext
    {
        readonly IConfiguration _configuration;
       
        public MilitaryBaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetSection("ConnectionString")["SqlServer"];
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BattleHistoryConfiguration).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<IEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    EntityState.Deleted => data.Entity.UpdatedDate = null
                };


            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<BattleHistory> BattleHistories { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<CrimeRecord> CrimeRecords { get; set; }

        public DbSet<EducationType> EducationTypes { get; set; }

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        public DbSet<FamilyMembersInService> FamilyMembersInServices { get; set; }

        public DbSet<Injunction> Injunctions { get; set; }

        public DbSet<InjunctionType> InjunctionTypes { get; set; }

        public DbSet<MaritalStatus> MaritalStatuses { get; set; }

        public DbSet<MilitaryMedicalAssessment> MilitaryMedicalAssessments { get; set; }

        public DbSet<MilitaryPenaltyType> MilitaryPenaltyTypes { get; set; }

        public DbSet<MilitaryPersonel> MilitaryPersonels { get; set; }

        public DbSet<MilitaryPersonelEducation> MilitaryPersonelEducations { get; set; }

        public DbSet<MilitaryPersonelFamilyMemberForeignTravel> MilitaryPersonelFamilyMemberForeignTravels { get; set; }

        public DbSet<MilitaryPersonelForeignLanguageLevel> MilitaryPersonelForeignLanguageLevels { get; set; }

        public DbSet<MilitaryPersonelForeignTravel> MilitaryPersonelForeignTravels { get; set; }

        public DbSet<MilitaryPersonelInfo> MilitaryPersonelInfos { get; set; }

        public DbSet<MilitaryPersonelPenalty> MilitaryPersonelPenalties { get; set; }

        public DbSet<MilitaryPersonelRecognition> MilitaryPersonelRecognitions { get; set; }

        public DbSet<MilitaryPersonelReputationRiskFinding> MilitaryPersonelReputationRiskFindings { get; set; }

        public DbSet<MilitaryPersonelSpecialSkill> MilitaryPersonelSpecialSkills { get; set; }

        public DbSet<MilitaryRank> MilitaryRanks { get; set; }

        public DbSet<MilitaryServiceExtension> MilitaryServiceExtensions { get; set; }

        public DbSet<MilitaryServiceHistory> MilitaryServiceHistories { get; set; }

        public DbSet<MilitarySkillRecord> MilitarySkillRecords { get; set; }

        public DbSet<PreMilitaryWorkExperience> PreMilitaryWorkExperiences { get; set; }

        public DbSet<ProfessionalDevelopmentCourse> ProfessionalDevelopmentCourses { get; set; }

        public DbSet<ServiceYearsWithBenefit> ServiceYearsWithBenefits { get; set; }

        public DbSet<SpecialRecord> SpecialRecords { get; set; }


    }
}
