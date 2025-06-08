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
        public async Task<IDataResult<List<MilitaryMedicalAssessmentGetDto>>> GetAllAssessmentsAsync()
        {
            List<MilitaryMedicalAssessmentGetDto> list = await _militaryMedicalAssessmentDal.GetAllAssessmentsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryMedicalAssessmentGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryMedicalAssessmentGetDto>>(Messages.NoData);
        }
        
        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<MilitaryMedicalAssessmentGetDto>>> GetAllAssessmentsByPersonelIdAsync(int personelId)
        {
            List<MilitaryMedicalAssessmentGetDto> list = await _militaryMedicalAssessmentDal.GetAllAssessmentsByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryMedicalAssessmentGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryMedicalAssessmentGetDto>>(Messages.NoData);
        }
        
        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<MilitaryMedicalAssessmentGetDto>> GetAssessmentByIdAsync(int id)
        {
            MilitaryMedicalAssessmentGetDto entity = await _militaryMedicalAssessmentDal.GetByIdAssessmentAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }

            return new SuccessDataResult<MilitaryMedicalAssessmentGetDto>(_mapper.Map<MilitaryMedicalAssessmentGetDto>(entity));
        }


        [ValidationAspect(typeof(MilitaryMedicalAssessmentValidator))]
        [SecuredOperation("admin,cmd.add")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        
        public async Task<IResult> AddAssessmentAsync(MilitaryMedicalAssessmentAddDto dto)
        {
            await _militaryMedicalAssessmentDal.AddAsync(_mapper.Map<MilitaryMedicalAssessment>(dto));
            return new SuccessResult(Messages.SuccessfullyAdded);
        }


        [ValidationAspect(typeof(MilitaryMedicalAssessmentValidator))]
        [SecuredOperation("admin,cmd.update")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        public async Task<IResult> UpdateAssesmentAsync(MilitaryMedicalAssessmentUpdateDto dto)
        {

            MilitaryMedicalAssessment entity = await _militaryMedicalAssessmentDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _militaryMedicalAssessmentDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IMilitaryMedicalAssessmentService.Get")]
        public async Task<IResult> DeleteAssesmentAsync(int id)
        {

            MilitaryMedicalAssessment entity = await _militaryMedicalAssessmentDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _militaryMedicalAssessmentDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
