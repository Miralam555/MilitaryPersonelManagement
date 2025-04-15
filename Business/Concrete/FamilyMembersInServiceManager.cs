using AutoMapper;
using Business.Abstract;
using Business.AutoMapper;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.FamilyMembersInServiceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FamilyMembersInServiceManager : IFamilyMembersInService_Service
    {
        private readonly IFamilyMemberInServiceDal _familyMemberInServiceDal;
        private readonly IMapper _mapper;

        public FamilyMembersInServiceManager(IFamilyMemberInServiceDal familyMemberInServiceDal, IMapper mapper)
        {
            _familyMemberInServiceDal = familyMemberInServiceDal;
            _mapper = mapper;
        }
        
        [CacheAspect]
        [ValidationAspect(typeof(FamilyMembersInServiceValidator))]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMembersInServiceUpdateAndGetDto>>> GetAllFamilyMembersInService()
        {
            List<FamilyMembersInService> services = await _familyMemberInServiceDal.GetAllAsync();
            if (services.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMembersInServiceUpdateAndGetDto>>(_mapper.Map<List<FamilyMembersInServiceUpdateAndGetDto>>(services));
            }
            return new ErrorDataResult<List<FamilyMembersInServiceUpdateAndGetDto>>();
        }
        [PerformanceAspect(3)]
        [CacheAspect]
        [ValidationAspect(typeof(FamilyMembersInServiceValidator))]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<FamilyMembersInServiceUpdateAndGetDto>> GetByIdFamilyMembersInService(int id)
        {
            FamilyMembersInService service = await _familyMemberInServiceDal.GetAsync(p=>p.Id==id);
           
            return new SuccessDataResult<FamilyMembersInServiceUpdateAndGetDto>(_mapper.Map<FamilyMembersInServiceUpdateAndGetDto>(service));
          
        }

        [CacheRemoveAspect("IFamilyMembersInService_Service.Get")]
        [ValidationAspect(typeof(FamilyMembersInServiceValidator))]
        [SecuredOperation("admin,cmd.add")]
        public async Task<IResult> AddFamilyMembersInService(FamilyMembersInServiceAddDto dto)
        {
            FamilyMembersInService service = _mapper.Map<FamilyMembersInService>(dto);
            await _familyMemberInServiceDal.AddAsync(service);

            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IFamilyMembersInService_Service.Get")]
        [ValidationAspect(typeof(FamilyMembersInServiceValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> UpdateFamilyMembersInService(FamilyMembersInServiceUpdateAndGetDto dto)
        {
            FamilyMembersInService entity = await _familyMemberInServiceDal.GetAsync(p => p.Id == dto.Id);
             _mapper.Map(dto,entity);
            await _familyMemberInServiceDal.UpdateAsync(entity);

            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IFamilyMembersInService_Service.Get")]
        [ValidationAspect(typeof(FamilyMembersInServiceValidator))]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteFamilyMembersInService(int id)
        {
            FamilyMembersInService entity = await _familyMemberInServiceDal.GetAsync(p => p.Id == id);
            
            await _familyMemberInServiceDal.DeleteAsync(entity);

            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
