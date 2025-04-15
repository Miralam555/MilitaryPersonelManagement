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
        public async Task<IDataResult<List<BattleHistoryUpdateAndGetDto>>> GetAllBattleHistoryAsync()
        {

            List<BattleHistory> histories = await _battleHistoryDal.GetAllAsync();

            if (histories != null)
            {
                return new SuccessDataResult<List<BattleHistoryUpdateAndGetDto>>(_mapper.Map<List<BattleHistoryUpdateAndGetDto>>(histories));
            }
            return new ErrorDataResult<List<BattleHistoryUpdateAndGetDto>>();
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<BattleHistoryUpdateAndGetDto>>> GetAllHistoryByPersonelIdAsync(int id)
        {
            List<BattleHistory> history = await _battleHistoryDal.GetAllAsync(p => p.PersonelId == id);
            if (history != null)
            {
                return new SuccessDataResult<List<BattleHistoryUpdateAndGetDto>>(_mapper.Map<List<BattleHistoryUpdateAndGetDto>>(history));
            }
            return new ErrorDataResult<List<BattleHistoryUpdateAndGetDto>>(Messages.EntityNotFound);
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

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IResult> GetByIdAsync(int id)
        {
            BattleHistory entity = await _battleHistoryDal.GetAsync(p => p.Id == id);
            if (entity != null)
            {
                var result = _mapper.Map<BattleHistoryAddDto>(entity);
                return new SuccessDataResult<BattleHistoryAddDto>(result);
            }
            return new ErrorDataResult<BattleHistoryAddDto>("Bele isci yoxdur");
        }
      
        [CacheRemoveAspect("IBattleHistoryService.Get")]
        [ValidationAspect(typeof(BattleHistoryValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> UpdateHistoryAsync(BattleHistoryUpdateAndGetDto dto)
        {
            BattleHistory entity = await _battleHistoryDal.GetAsync(p => p.Id == dto.Id);
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
            await _battleHistoryDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}
