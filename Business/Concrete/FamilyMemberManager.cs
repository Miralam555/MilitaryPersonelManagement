using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.FamilyMemberDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FamilyMemberManager : IFamilyMemberService
    {

        private readonly IFamilyMemberDal _familyMemberDal;
        private readonly IMapper _mapper;


        public FamilyMemberManager(IFamilyMemberDal familyMemberDal, IMapper mapper)
        {
            _familyMemberDal = familyMemberDal;
            _mapper = mapper;
        }



        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMemberGetDto>>> GetAllFamilyMembersByPersonelIdAsync(int personelId)
        {
            List<FamilyMemberGetDto> familyMembers = await _familyMemberDal.GetAllMembersByPersonelIdAsync(personelId);
            if (familyMembers.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMemberGetDto>>(familyMembers);
            }
            return new ErrorDataResult<List<FamilyMemberGetDto>>(Messages.NoData);
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<FamilyMemberGetDto>>> GetAllFamilyMembersAsync()
        {

            List<FamilyMemberGetDto> familyMembers = await _familyMemberDal.GetAllMembersAsync();
            if (familyMembers.Count > 0)
            {
                return new SuccessDataResult<List<FamilyMemberGetDto>>(familyMembers);
            }
            return new ErrorDataResult<List<FamilyMemberGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<FamilyMemberGetDto>> GetMemberByIdAsync(int id)
        {

            FamilyMemberGetDto entity = await _familyMemberDal.GetMemberByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<FamilyMemberGetDto>(Messages.EntityNotFound);

            }
            return new SuccessDataResult<FamilyMemberGetDto>(entity);
        }


        [CacheRemoveAspect("IFamilyMemberService.Get")]
        [ValidationAspect(typeof(FamilyMemberValidator))]
        [SecuredOperation("admin,cmd.add")]
        public async Task<IResult> AddFamilyMemberAsync(FamilyMemberAddDto dto)
        {
            FamilyMember entity = _mapper.Map<FamilyMember>(dto);
            await _familyMemberDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        [CacheRemoveAspect("IFamilyMemberService.Get")]
        [ValidationAspect(typeof(FamilyMemberValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> UpdateFamilyMemberAsync(FamilyMemberUpdateDto dto)
        {
            FamilyMember entity = await _familyMemberDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto, entity);
            await _familyMemberDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IFamilyMemberService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteFamilyMemberAsync(int id)
        {
            FamilyMember entity = await _familyMemberDal.GetAsync(p => p.Id == id);
            await _familyMemberDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}
