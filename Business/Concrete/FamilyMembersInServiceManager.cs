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
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInService()
        {
            List<FamilyMembersInServiceGetDto> services = await _familyMemberInServiceDal.GetAllFamilyMembersInServiceAsync();
            if (services.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMembersInServiceGetDto>>(services);
            }
            return new ErrorDataResult<List<FamilyMembersInServiceGetDto>>();
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInServiceByPersonelId(int personelId)
        {
            List<FamilyMembersInServiceGetDto> services = await _familyMemberInServiceDal.GetAllFamilyMembersInServiceByPersonelIdAsync(personelId);
            if (services.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMembersInServiceGetDto>>(services);
            }
            return new ErrorDataResult<List<FamilyMembersInServiceGetDto>>();
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInServiceByMemberId(int memberId)
        {
            List<FamilyMembersInServiceGetDto> services = await _familyMemberInServiceDal.GetAllFamilyMembersInServiceByMemberIdAsync(memberId);
            if (services.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMembersInServiceGetDto>>(services);
            }
            return new ErrorDataResult<List<FamilyMembersInServiceGetDto>>();
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<FamilyMembersInServiceGetDto>> GetByIdFamilyMemberInService(int id)
        {
            FamilyMembersInServiceGetDto entity = await _familyMemberInServiceDal.GetFamilyMemberInServiceByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<FamilyMembersInServiceGetDto>(Messages.EntityNotFound);
            }
           
            return new SuccessDataResult<FamilyMembersInServiceGetDto>(entity);
          
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
        public async Task<IResult> UpdateFamilyMembersInService(FamilyMembersInServiceUpdateDto dto)
        {
            FamilyMembersInService entity = await _familyMemberInServiceDal.GetAsync(p => p.Id == dto.Id);
             _mapper.Map(dto,entity);
            await _familyMemberInServiceDal.UpdateAsync(entity);

            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IFamilyMembersInService_Service.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteFamilyMembersInService(int id)
        {
            FamilyMembersInService entity = await _familyMemberInServiceDal.GetAsync(p => p.Id == id);
            
            await _familyMemberInServiceDal.DeleteAsync(entity);

            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
