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
using Entities.DTOs.InjunctionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InjunctionManager : IInjunctionService
    {
        private readonly IInjunctionDal _injunctionDal;
        private readonly IMapper _mapper;

        public InjunctionManager(IInjunctionDal injunctionDal, IMapper mapper)
        {
            _injunctionDal = injunctionDal;
            _mapper = mapper;
        }
        
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<InjunctionUpdateAndGetDto>>> GetAllInjunctionsAsync()
        {
            List<Injunction> injunctions = await _injunctionDal.GetAllInjunctionWithDetailsAsync();
            if (injunctions.Count > 0)
            {
                return new SuccessDataResult<List<InjunctionUpdateAndGetDto>>(_mapper.Map<List<InjunctionUpdateAndGetDto>>(injunctions));
            }
            return new ErrorDataResult<List<InjunctionUpdateAndGetDto>>(Messages.NoData);
        }
        
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<InjunctionUpdateAndGetDto>>> GetAllInjunctionsByIssuedPersonelIdAsync(int id)
        {
            List<Injunction> injunctions = await _injunctionDal.GetAllInjunctionsByIssuedPersonelIdWithDetailsAsync(id);
            if (injunctions.Count > 0)
            {
                return new SuccessDataResult<List<InjunctionUpdateAndGetDto>>(_mapper.Map<List<InjunctionUpdateAndGetDto>>(injunctions));
            }
            return new ErrorDataResult<List<InjunctionUpdateAndGetDto>>(Messages.NoData);
        }


        
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<InjunctionUpdateAndGetDto>> GetByIdInjunctionsAsync(int id)
        {
            Injunction injunction = await _injunctionDal.GetByIdInjunctionWithDetailsAsync(id);

            return new SuccessDataResult<InjunctionUpdateAndGetDto>(_mapper.Map<InjunctionUpdateAndGetDto>(injunction));

        }
        [CacheRemoveAspect("IInjunctionService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(InjunctionValidator))]
        public async Task<IResult> AddInjunctionAsync(InjunctionAddDto dto)
        {
            await _injunctionDal.AddAsync(_mapper.Map<Injunction>(dto));
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IInjunctionService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(InjunctionValidator))]
        public async Task<IResult> UpdateInjunctionAsync(InjunctionUpdateAndGetDto dto)
        {
            Injunction entity= await _injunctionDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto,entity);
            await _injunctionDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IInjunctionService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteInjunctionAsync(int id)
        {
            Injunction entity= await _injunctionDal.GetAsync(p => p.Id == id);
           
            await _injunctionDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
