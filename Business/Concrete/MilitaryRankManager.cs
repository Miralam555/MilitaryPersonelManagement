using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryRankDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryRankManager:IMilitaryRankService
    {
        private readonly IMilitaryRankDal _rankDal;
        private readonly IMapper _mapper;

        public MilitaryRankManager(IMilitaryRankDal rankDal, IMapper mapper)
        {
            _rankDal = rankDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksAsync()
        {
            var list = await _rankDal.GetAllRanksAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryRankGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryRankGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksByPersonelIdAsync(int personelId)
        {
            var list = await _rankDal.GetAllRanksByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryRankGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryRankGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksByInjunctionIdAsync(int injunctionId)
        {
            var list = await _rankDal.GetAllRanksByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryRankGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryRankGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitaryRankGetDto>> GetRankByIdAsync(int id)
        {
            var entity = await _rankDal.GetRankByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryRankGetDto>(Messages.EntityNotFound);
            }
            return new SuccessDataResult<MilitaryRankGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryRankService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryRankValidator))]
        public async Task<IResult> AddRankAsync(MilitaryRankAddDto dto)
        {
            var entity = _mapper.Map<MilitaryRank>(dto);
            await _rankDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryRankService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(MilitaryRankValidator))]
        public async Task<IResult> UpdateRankAsync(MilitaryRankUpdateDto dto)
        {
            var entity = await _rankDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto, entity);
            await _rankDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryRankService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteRankAsync(int id)
        {
            var entity = await _rankDal.GetAsync(p => p.Id ==id);
            await _rankDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
