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
using Entities.DTOs.MilitaryServiceHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryServiceHistoryManager:IMilitaryServiceHistoryService
    {
        private readonly IMilitaryServiceHistoryDal _historyDal;
        private readonly IMapper _mapper;

        public MilitaryServiceHistoryManager(IMilitaryServiceHistoryDal historyDal, IMapper mapper)
        {
            _historyDal = historyDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesAsync()
        {
            var list = await _historyDal.GetAllServiceHistoryAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceHistoryGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceHistoryGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesByPersonelIdAsync(int personelId)
        {
            var list = await _historyDal.GetAllServiceHistoryByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceHistoryGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceHistoryGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesByInjunctionIdAsync(int injunctionId)
        {
            var list = await _historyDal.GetAllServiceHistoryByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceHistoryGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceHistoryGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitaryServiceHistoryGetDto>> GetServiceHistoryByIdAsync(int id)
        {
            var entity = await _historyDal.GetServiceHistoryByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryServiceHistoryGetDto>(Messages.NoData);
            }
            return new SuccessDataResult<MilitaryServiceHistoryGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryServiceHistoryService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryServiceHistoryValidator))]
        public async Task<IResult> AddHistoryAsync(MilitaryServiceHistoryAddDto dto)
        {
            var entity = _mapper.Map<MilitaryServiceHistory>(dto);
            await _historyDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryServiceHistoryService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(MilitaryServiceHistoryValidator))]
        public async Task<IResult> UpdateHistoryAsync(MilitaryServiceHistoryUpdateDto dto)
        {
            var entity = await _historyDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _historyDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryServiceHistoryService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteHistoryAsync(int id)
        {
            var entity = await _historyDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _historyDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
