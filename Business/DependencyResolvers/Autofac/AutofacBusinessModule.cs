﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.AutoMapper;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BattleHistoryManager>().As<IBattleHistoryService>().SingleInstance();
            builder.RegisterType<EfBattleHistoryDal>().As<IBattleHistoryDal>().SingleInstance();

            builder.RegisterType<MilitaryPersonelManager>().As<IMilitaryPersonelService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelDal>().As<IMilitaryPersonelDal>().SingleInstance();


            builder.RegisterType<CrimeRecordManager>().As<ICrimeRecordService>().SingleInstance();
            builder.RegisterType<EfCrimeRecordDal>().As<ICrimeRecordDal>().SingleInstance();

            builder.RegisterType<FamilyMemberManager>().As<IFamilyMemberService>().SingleInstance();
            builder.RegisterType<EfFamilyMemberDal>().As<IFamilyMemberDal>().SingleInstance();


            builder.RegisterType<FamilyMembersInServiceManager>().As<IFamilyMembersInService_Service>().SingleInstance();
            builder.RegisterType<EfFamilyMembersInServiceDal>().As<IFamilyMemberInServiceDal>().SingleInstance();

            builder.RegisterType<InjunctionManager>().As<IInjunctionService>().SingleInstance();
            builder.RegisterType<EfInjunctionDal>().As<IInjunctionDal>().SingleInstance();

            builder.RegisterType<MilitaryMedicalAssessmentManager>().As<IMilitaryMedicalAssessmentService>().SingleInstance();
            builder.RegisterType<EfMilitaryMedicalAssessmentDal>().As<IMilitaryMedicalAssessmentDal>().SingleInstance();


            builder.RegisterType<MilitaryPersonelPenaltyManager>().As<IMilitaryPersonelPenaltyService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelPenaltyDal>().As<IMilitaryPersonelPenaltyDal>().SingleInstance();


            builder.RegisterType<MilitaryPersonelEducationManager>().As<IMilitaryPersonelEducationService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelEducationDal>().As<IMilitaryPersonelEducationDal>().SingleInstance();

            builder.RegisterType<MilitaryPersonelFamilyMemberForeignTravelManager>().As<IMilitaryPersonelFamilyMemberForeignTravelService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelFamilyMemberForeignTravelDal>().As<IMilitaryPersonelFamilyMemberForeignTravelDal>().SingleInstance();


            builder.RegisterType<MilitaryPersonelForeignLanguageLevelManager>().As<IMilitaryPersonelForeignLanguageLevelService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelForeignLanguageLevelDal>().As<IMilitaryPersonelForeignLanguageLevelDal>().SingleInstance();


            builder.RegisterType<PersonelForeignTravelManager>().As<IMilitaryPersonelForeignTravelService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelForeignTravelDal>().As<IMilitaryPersonelForeignTravelDal>().SingleInstance();


            builder.RegisterType<MilitarySkillRecordManager>().As<IMilitarySkillRecordService>().SingleInstance();
            builder.RegisterType<EfMilitarySkillRecordDal>().As<IMilitarySkillRecordDal>().SingleInstance();


            builder.RegisterType<PersonelRecognitionManager>().As<IMilitaryPersonelRecognitionService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelRecognitionDal>().As<IMilitaryPersonelRecognitionDal>().SingleInstance();

            builder.RegisterType<PersonelReputationRiskFindingManager>().As<IMilitaryPersonelReputationRiskFindingService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelReputationRiskFindingDal>().As<IMilitaryPersonelReputationRiskFindingDal>().SingleInstance();


            builder.RegisterType<PersonelSpecialSkillManager>().As<IMilitaryPersonelSpecialSkillService>().SingleInstance();
            builder.RegisterType<EfMilitaryPersonelSpecialSkillDal>().As<IMilitaryPersonelSpecialSkillDal>().SingleInstance();

            builder.RegisterType<MilitaryRankManager>().As<IMilitaryRankService>().SingleInstance();
            builder.RegisterType<EfMilitaryRankDal>().As<IMilitaryRankDal>().SingleInstance();

            builder.RegisterType<MilitaryServiceExtensionManager>().As<IMilitaryServiceExtensionService>().SingleInstance();
            builder.RegisterType<EfMilitaryServiceExtensionDal>().As<IMilitaryServiceExtensionDal>().SingleInstance();

            builder.RegisterType<MilitaryServiceHistoryManager>().As<IMilitaryServiceHistoryService>().SingleInstance();
            builder.RegisterType<EfMilitaryServiceHistoryDal>().As<IMilitaryServiceHistoryDal>().SingleInstance();


            builder.RegisterType<PreMilitaryWorkExperienceManager>().As<IPreMilitaryWorkExperienceService>().SingleInstance();
            builder.RegisterType<EfPreMilitaryWorkExperienceDal>().As<IPreMilitaryWorkExperienceDal>().SingleInstance();


            builder.RegisterType<ProfessionalDevelopmentCourseManager>().As<IProfessionalDevelopomentCourseService>().SingleInstance();
            builder.RegisterType<EfProfessionalDevelopmentCourseDal>().As<IProfessionalDevelopmentCourseDal>().SingleInstance();




            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }

}
