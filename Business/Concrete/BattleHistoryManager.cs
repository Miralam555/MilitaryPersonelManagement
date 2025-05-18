using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.DTOs.BattleHistoryDtos;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BattleHistoryManager : IBattleHistoryService
    {

        private readonly IBattleHistoryDal _battleHistoryDal;
        private readonly IMapper _mapper;

        public BattleHistoryManager(IBattleHistoryDal battleHistoryDal, IMapper mapper)
        {
            _battleHistoryDal = battleHistoryDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<BattleHistoryGetDto>>> GetAllBattleHistoryAsync()
        {

            List<BattleHistoryGetDto> histories = await _battleHistoryDal.GetAllHistoriesAsync();

            if (histories != null)
            {
                return new SuccessDataResult<List<BattleHistoryGetDto>>(_mapper.Map<List<BattleHistoryGetDto>>(histories));
            }
            return new ErrorDataResult<List<BattleHistoryGetDto>>();
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<BattleHistoryGetDto>>> GetAllHistoriesByPersonelIdAsync(int personelId)
        {
            List<BattleHistoryGetDto> history = await _battleHistoryDal.GetAllHistoriesByPersonelIdAsync(personelId);

            if (history != null)
            {
                return new SuccessDataResult<List<BattleHistoryGetDto>>(_mapper.Map<List<BattleHistoryGetDto>>(history));
            }
            return new ErrorDataResult<List<BattleHistoryGetDto>>(Messages.EntityNotFound);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<BattleHistoryGetDto>> GetHistoryByIdAsync(int id)
        {
            BattleHistoryGetDto entity = await _battleHistoryDal.GetHistoryByIdAsync( id);
            if (entity != null)
            {
                
                return new SuccessDataResult<BattleHistoryGetDto>(entity);
            }
            return new ErrorDataResult<BattleHistoryGetDto>(Messages.EntityNotFound);
        }

        [ValidationAspect(typeof(BattleHistoryValidator))]
        [CacheRemoveAspect("IBattleHistoryService.Get")]
        [SecuredOperation("admin,cmd.add")]
        public async Task<IResult> AddBattleHistoryAsync(BattleHistoryAddDto dto)
        {
            //burada businessrulesun icine istediyim qeder business qaydalarim nedirse onu elave ede bilerem
            //BusinessRules.Run(//hansisa bir Iresult qaytaran metodlar)

            var entity = _mapper.Map<BattleHistory>(dto);
            await _battleHistoryDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

   
        [CacheRemoveAspect("IBattleHistoryService.Get")]
        [ValidationAspect(typeof(BattleHistoryValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> UpdateHistoryAsync(BattleHistoryUpdateDto dto)
        {
            BattleHistory entity = await _battleHistoryDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _battleHistoryDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [PerformanceAspect(7)]
        [CacheRemoveAspect("IBattleHistoryService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteHistoryAsync(int id)
        {
            BattleHistory entity = await _battleHistoryDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _battleHistoryDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}
