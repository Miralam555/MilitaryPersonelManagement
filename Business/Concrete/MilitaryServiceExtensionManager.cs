using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryServiceExtensionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryServiceExtensionManager : IMilitaryServiceExtensionService
    {
        private readonly IMilitaryServiceExtensionDal _extensionDal;
        private readonly IMapper _mapper;

        public MilitaryServiceExtensionManager(IMilitaryServiceExtensionDal extensionDal, IMapper mapper)
        {
            _extensionDal = extensionDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsAsync()
        {
            var list = await _extensionDal.GetAllExtensionsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceExtensionGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceExtensionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsByPersonelIdAsync(int personelId)
        {
            var list = await _extensionDal.GetAllExtensionsByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceExtensionGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceExtensionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsByInjunctionIdAsync(int injunctionId)
        {
            var list = await _extensionDal.GetAllExtensionsByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitaryServiceExtensionGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitaryServiceExtensionGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitaryServiceExtensionGetDto>> GetExtensionByIdAsync(int id)
        {
            var entity = await _extensionDal.GetExtensionByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryServiceExtensionGetDto>(Messages.EntityNotFound);
            }
            return new SuccessDataResult<MilitaryServiceExtensionGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryServiceExtensionService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryServiceExtensionValidator))]
        public async Task<IResult> AddExtensionASync(MilitaryServiceExtensionAddDto dto)
        {
            var entity = _mapper.Map<MilitaryServiceExtension>(dto);
            await _extensionDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryServiceExtensionService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(MilitaryServiceExtensionValidator))]
        public async Task<IResult> UpdateExtensionAsync(MilitaryServiceExtensionUpdateDto dto)
        {
            var entity =await _extensionDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto, entity);
            await _extensionDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryServiceExtensionService.Get")]
        [SecuredOperation("admin,cmd.delete")]
        public async Task<IResult> DeleteExtensionAsync(int id)
        {
            var entity = await _extensionDal.GetAsync(p => p.Id == id);
            await _extensionDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
