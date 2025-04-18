using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger))]
    public class MilitaryMedicalAssessmentManager : IMilitaryMedicalAssessmentService
    {
        private readonly IMilitaryMedicalAssessmentDal _militaryMedicalAssessmentDal;
        private readonly IMapper _mapper;

        public MilitaryMedicalAssessmentManager(IMilitaryMedicalAssessmentDal militaryMedicalAssessmentDal, IMapper mapper)
        {
            _militaryMedicalAssessmentDal = militaryMedicalAssessmentDal;
            _mapper = mapper;
        }
       
        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<MilitaryMedicalAsssessmentGetDto>>> GetAllAsync()
        {
            List<MilitaryMedicalAssessment> entities = await _militaryMedicalAssessmentDal.GetAllAssessmentsAsync();
            if (entities.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryMedicalAsssessmentGetDto>>(_mapper.Map<List<MilitaryMedicalAsssessmentGetDto>>(entities));
            }
            return new ErrorDataResult<List<MilitaryMedicalAsssessmentGetDto>>(Messages.NoData);
        }
        
        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<MilitaryMedicalAsssessmentGetDto>>> GetAllByPersonelIdAsync(int id)
        {
            List<MilitaryMedicalAssessment> entities = await _militaryMedicalAssessmentDal.GetAllAssessmentsByPersonelIdAsync(id);
            if (entities.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryMedicalAsssessmentGetDto>>(_mapper.Map<List<MilitaryMedicalAsssessmentGetDto>>(entities));
            }
            return new ErrorDataResult<List<MilitaryMedicalAsssessmentGetDto>>(Messages.NoData);
        }
        
        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<MilitaryMedicalAssessment>> GetByIdAsync(int id)
        {
            MilitaryMedicalAssessment entity = await _militaryMedicalAssessmentDal.GetByIdAssessmentAsync(id);

            return new SuccessDataResult<MilitaryMedicalAssessment>(_mapper.Map<MilitaryMedicalAssessment>(entity));
        }
        [ValidationAspect(typeof(MilitaryMedicalAssessmentValidator))]
        [SecuredOperation("admin,cmd.add")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        
        public async Task<IResult> AddAsync(MilitaryMedicalAssessmentAddDto dto)
        {
            await _militaryMedicalAssessmentDal.AddAsync(_mapper.Map<MilitaryMedicalAssessment>(dto));
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [ValidationAspect(typeof(MilitaryMedicalAssessment))]
        [SecuredOperation("admin,cmd.update")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        public async Task<IResult> UpdateAsync(MilitaryMedicalAsssessmentGetDto dto)
        {

            MilitaryMedicalAssessment entity = await _militaryMedicalAssessmentDal.GetAsync(p => p.Id == dto.Id);
            await _militaryMedicalAssessmentDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [ValidationAspect(typeof(MilitaryMedicalAssessment))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        public async Task<IResult> DeleteAsync(int id)
        {

            MilitaryMedicalAssessment entity = await _militaryMedicalAssessmentDal.GetAsync(p => p.Id == id);
            await _militaryMedicalAssessmentDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
