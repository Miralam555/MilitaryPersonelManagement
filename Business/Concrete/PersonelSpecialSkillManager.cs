using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using Entities.DTOs.PersonelSpecialSkillDtos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelSpecialSkillManager:IMilitaryPersonelSpecialSkillService
    {
        private readonly IMilitaryPersonelSpecialSkillDal _skillDal;
        private readonly IMapper _mapper;

        public PersonelSpecialSkillManager(IMilitaryPersonelSpecialSkillDal skillDal, IMapper mapper)
        {
            _skillDal = skillDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelSpecialSkillGetDto>>> GetAllSkillsAsync()
        {
            var list = await _skillDal.GetAllSkillsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelSpecialSkillGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelSpecialSkillGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelSpecialSkillGetDto>>> GetAllSkillsByPersonelIdAsync(int personelId)
        {
            var list = await _skillDal.GetAllSkillsByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelSpecialSkillGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelSpecialSkillGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PersonelSpecialSkillGetDto>> GetSkillByIdAsync(int id)
        {
            var entity = await _skillDal.GetSkillByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<PersonelSpecialSkillGetDto>(Messages.EntityNotFound);
            }
            return new SuccessDataResult<PersonelSpecialSkillGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryPersonelSpecialSkillService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PersonelSpecialSkillValidator))]
        public async Task<IResult> AddSkillAsync(PersonelSpecialSkillAddDto dto)
        {
            var entity = _mapper.Map<MilitaryPersonelSpecialSkill>(dto);
            await _skillDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelSpecialSkillService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(PersonelSpecialSkillValidator))]
        public async Task<IResult> UpdateSkillAsync(PersonelSpecialSkillUpdateDto dto)
        {
            var entity = await _skillDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _skillDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryPersonelSpecialSkillService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteSkillAsync(int id)
        {
            var entity = await _skillDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _skillDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
