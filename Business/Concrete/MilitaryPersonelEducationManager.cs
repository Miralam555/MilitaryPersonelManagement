using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.EducationDtos;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   
   
    public class MilitaryPersonelEducationManager : IMilitaryPersonelEducationService
    {
        private readonly IMilitaryPersonelEducationDal _militaryPersonelEducationDal;
        private readonly IMapper _mapper;

        public MilitaryPersonelEducationManager(IMilitaryPersonelEducationDal militaryPersonelEducationDal, IMapper mapper)
        {
            _militaryPersonelEducationDal = militaryPersonelEducationDal;
            _mapper = mapper;
        }


        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<EducationGetDto>>> GetAllEducationAsync()
        {
            List<EducationGetDto> list = await _militaryPersonelEducationDal.GetAllEducationsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<EducationGetDto>>(list);
            }
            return new ErrorDataResult<List<EducationGetDto>>(Messages.NoData);
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<EducationGetDto>>> GetAllByPersonelIdAsync(int personelId)
        {
            List<EducationGetDto> list = await _militaryPersonelEducationDal.GetAllEducationByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<EducationGetDto>>(list);
            }
            return new ErrorDataResult<List<EducationGetDto>>(Messages.NoData);
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<EducationGetDto>> GetByIdAsync(int id)
        {
            EducationGetDto list = await _militaryPersonelEducationDal.GetEducationByIdAsync(id);
            if (list == null)
            {
                return new ErrorDataResult<EducationGetDto>(Messages.NoData);

            }
            return new SuccessDataResult<EducationGetDto>();
        }

        [CacheRemoveAspect("IMilitaryPersonelEducationService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryPersonelEducationValidator))]
        public async Task<IResult> AddAsync(EducationAddDto dto)
        {
            var entity=_mapper.Map<MilitaryPersonelEducation>(dto);
            await _militaryPersonelEducationDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelEducationService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(MilitaryPersonelEducationValidator))]
        public async Task<IResult> UpdateAsync(EducationUpdateDto dto)
        {
            
            var entity=await _militaryPersonelEducationDal.GetAsync(p=>p.Id==dto.Id);
            if (entity == null)
            {
                return new ErrorResult(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _militaryPersonelEducationDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
         [CacheRemoveAspect("IMilitaryPersonelEducationService.Get")]
        [SecuredOperation("admin")]
        
        public async Task<IResult> DeleteAsync(int id)
        {
            var entity = await _militaryPersonelEducationDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _militaryPersonelEducationDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
