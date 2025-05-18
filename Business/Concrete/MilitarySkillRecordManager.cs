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
using Entities.DTOs.MilitarySkillRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitarySkillRecordManager:IMilitarySkillRecordService
    {
        private readonly IMilitarySkillRecordDal _recordDal;
        private readonly IMapper _mapper;

        public MilitarySkillRecordManager(IMilitarySkillRecordDal recordDal, IMapper mapper)
        {
            _recordDal = recordDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitarySkillRecordGetDto>>> GetAllRecordsAsync()
        {
            var list = await _recordDal.GetAllSkillRecordsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitarySkillRecordGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitarySkillRecordGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitarySkillRecordGetDto>>> GetAllRecordsByPersonelIdAsync(int personelId)
        {
            var list = await _recordDal.GetAllSkillRecordsByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitarySkillRecordGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitarySkillRecordGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitarySkillRecordGetDto>> GetRecordByIdAsync(int id)
        {
            var entity = await _recordDal.GetSkillRecordByIdAsync(id);
            if (entity == null)
            {
                return new SuccessDataResult<MilitarySkillRecordGetDto>(Messages.EntityNotFound);
            }
            return new ErrorDataResult<MilitarySkillRecordGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitarySkillRecordService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitarySkillRecordValidator))]
        public async Task<IResult> AddSkillRecordAsync(MilitarySkillRecordAddDto dto)
        {
            var entity = _mapper.Map<MilitarySkillRecord>(dto);
            await _recordDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitarySkillRecordService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitarySkillRecordValidator))]
        public async Task<IResult> UpdateSkillRecordAsync(MilitarySkillRecordUpdateDto dto)
        {
            var entity =await _recordDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _recordDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitarySkillRecordService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteSkillRecordAsync(int id)
        {
            var entity =await _recordDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _recordDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
