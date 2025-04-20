using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryPersonelFamilyMemberForeignTravelManager:IMilitaryPersonelFamilyMemberForeignTravelService
    {
        private readonly IMilitaryPersonelFamilyMemberForeignTravelDal _militaryPersonelFamilyMemberForeignTravelDal;
        private readonly IMapper _mapper;

        public MilitaryPersonelFamilyMemberForeignTravelManager(IMilitaryPersonelFamilyMemberForeignTravelDal militaryPersonelFamilyMemberForeignTravelDal, IMapper mapper)
        {
            _militaryPersonelFamilyMemberForeignTravelDal = militaryPersonelFamilyMemberForeignTravelDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMemberForeignTravelGetDto>>> GetAllTravelsAsync()
        {
            var list=await _militaryPersonelFamilyMemberForeignTravelDal.GetAllTravelsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMemberForeignTravelGetDto>>(list);
            }
            return new ErrorDataResult<List<FamilyMemberForeignTravelGetDto>>(Messages.NoData);

        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMemberForeignTravelGetDto>>> GetAllByMemberIdAsync(int memberId)
        {
            var list = await _militaryPersonelFamilyMemberForeignTravelDal.GetAllTravelsByMemberIdAsync(memberId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMemberForeignTravelGetDto>>(list);
            }
            return new ErrorDataResult<List<FamilyMemberForeignTravelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<FamilyMemberForeignTravelGetDto>> GetByIdAsync(int id)
        {
            var entity = await _militaryPersonelFamilyMemberForeignTravelDal.GetTravelByIdAsync(id);
            if (entity is null)
            {
                return new ErrorDataResult<FamilyMemberForeignTravelGetDto>(Messages.EntityNotFound);
                
            }
            return new SuccessDataResult<FamilyMemberForeignTravelGetDto>(entity);
        }

        [CacheRemoveAspect("IMilitaryPersonelFamilyMemberForeignTravelService.Get")]
        [ValidationAspect(typeof(MilitaryPersonelFamilyMemberForeignTravelValidator))]
        [SecuredOperation("admin,cmd.add")]
        public async Task<IResult> AddTravelAsync(FamilyMemberForeignTravelAddDto dto)
        {
            var entity = _mapper.Map<MilitaryPersonelFamilyMemberForeignTravel>(dto);
            await _militaryPersonelFamilyMemberForeignTravelDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelFamilyMemberForeignTravelService.Get")]
        [ValidationAspect(typeof(MilitaryPersonelFamilyMemberForeignTravelValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> UpdateTravelAsync(FamilyMemberForeignTraveUpdateDto dto)
        {
            var entity=await _militaryPersonelFamilyMemberForeignTravelDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorResult(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _militaryPersonelFamilyMemberForeignTravelDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryPersonelFamilyMemberForeignTravelService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int id)
        {
            var entity=await _militaryPersonelFamilyMemberForeignTravelDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorResult(Messages.EntityNotFound);
            }
           
            await _militaryPersonelFamilyMemberForeignTravelDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }


    }
}
