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
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelRecognitionManager:IMilitaryPersonelRecognitionService
    {
        private readonly IMilitaryPersonelRecognitionDal _recognitionDal;
        private readonly IMapper _mapper;

        public PersonelRecognitionManager(IMilitaryPersonelRecognitionDal recognitionDal, IMapper mapper)
        {
            _recognitionDal = recognitionDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsAsync()
        {
            List<PersonelRecognitionGetDto> list = await _recognitionDal.GetAllRecognitionsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelRecognitionGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelRecognitionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsByInjunctionIdAsync(int injunctionID)
        {
            List<PersonelRecognitionGetDto> list = await _recognitionDal.GetAllRecognitionsByInjunctionIdAsync(injunctionID);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelRecognitionGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelRecognitionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsByPersonelIdAsync(int personelId)
        {
            List<PersonelRecognitionGetDto> list = await _recognitionDal.GetAllRecognitionsByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelRecognitionGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelRecognitionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PersonelRecognitionGetDto>> GetRecognitionByIdAsync(int id)
        {
            PersonelRecognitionGetDto entity = await _recognitionDal.GetRecognitionByIdAsync(id);
            if (entity==null)
            {
                return new ErrorDataResult<PersonelRecognitionGetDto>(Messages.EntityNotFound);
                
            }
            return new SuccessDataResult<PersonelRecognitionGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryPersonelRecognitionService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PersonelRecognitionValidator))]
        public async Task<IResult> AddRecognitionAsync(PersonelRecognitionAddDto dto)
        {
            var entity = _mapper.Map<MilitaryPersonelRecognition>(dto);
            await _recognitionDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelRecognitionService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(PersonelRecognitionValidator))]
        public async Task<IResult> UpdateRecognitionAsync(PersonelRecognitionUpdateDto dto)
        {
            var entity = await _recognitionDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _recognitionDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryPersonelRecognitionService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteRecognitionAsync(int id)
        {
            var entity = await _recognitionDal.GetAsync(p => p.Id ==id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _recognitionDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
