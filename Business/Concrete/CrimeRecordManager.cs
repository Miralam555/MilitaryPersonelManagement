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
using Entities.DTOs.CrimeRecordDtos;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CrimeRecordManager : ICrimeRecordService
    {
        private readonly ICrimeRecordDal _crimeRecordDal;
        private readonly IMapper _mapper;


        public CrimeRecordManager(ICrimeRecordDal crimeRecordDal, IMapper mapper)
        {
            _crimeRecordDal = crimeRecordDal;
            _mapper = mapper;
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<CrimeRecordGetDto>>> GetAllCrimeRecordsAsync()
        {
            List<CrimeRecordGetDto> records = await _crimeRecordDal.GetAllCrimeRecordsAsync();

            if (records.Count > 0)
            {
                return new SuccessDataResult<List<CrimeRecordGetDto>>(records);
            }
            return new ErrorDataResult<List<CrimeRecordGetDto>>(Messages.NoData);
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<CrimeRecordGetDto>>> GetCrimeRecordsByPersonelIdAsync(int personelId)
        {
            List<CrimeRecordGetDto> records = await _crimeRecordDal.GetAllCrimeRecordsByPersonelIdAsync(personelId);
            if (records.Count > 0)
            {
                return new SuccessDataResult<List<CrimeRecordGetDto>>(records);
            }
            return new ErrorDataResult<List<CrimeRecordGetDto>>(Messages.NoData);
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<CrimeRecordGetDto>>> GetCrimeRecordsByMemberIdAsync(int memberId)
        {
            List<CrimeRecordGetDto> records = await _crimeRecordDal.GetAllCrimeRecordsByMemberIdAsync(memberId);
            if (records.Count > 0)
            {
                return new SuccessDataResult<List<CrimeRecordGetDto>>(records);
            }
            return new ErrorDataResult<List<CrimeRecordGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<CrimeRecordGetDto>> GetCrimeRecordByIdAsync(int id)
        {
            CrimeRecordGetDto entity = await _crimeRecordDal.GetCrimeRecordByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<CrimeRecordGetDto>(Messages.EntityNotFound);
            }

            return new SuccessDataResult<CrimeRecordGetDto>(entity);
        }


        [CacheRemoveAspect("ICrimeRecordService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(CrimeRecordValidator))]
        public async Task<IResult> AddCrimeRecordAsync(CrimeRecordAddDto dto)
        {
            CrimeRecord record = _mapper.Map<CrimeRecord>(dto);
            await _crimeRecordDal.AddAsync(record);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        [CacheRemoveAspect("ICrimeRecordService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(CrimeRecordValidator))]
        public async Task<IResult> UpdateCrimeRecordAsync(CrimeRecordUpdateDto dto)
        {
            CrimeRecord entity = await _crimeRecordDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto, entity);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _crimeRecordDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("ICrimeRecordService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteCrimeRecordAsync(int id)
        {
            CrimeRecord entity = await _crimeRecordDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _crimeRecordDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}
