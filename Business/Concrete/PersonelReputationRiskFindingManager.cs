using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using Entities.DTOs.PersonelReputationRiskFindingDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelReputationRiskFindingManager:IMilitaryPersonelReputationRiskFindingService
    {
        private readonly IMilitaryPersonelReputationRiskFindingDal _riskFindingDal;
        private readonly IMapper _mapper;

        public PersonelReputationRiskFindingManager(IMilitaryPersonelReputationRiskFindingDal riskFindingDal, IMapper mapper)
        {
            _riskFindingDal = riskFindingDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelReputationRiskFindingGetDto>>> GetAllRisksAsync()
        {
            var list = await _riskFindingDal.GetAllReportsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelReputationRiskFindingGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelReputationRiskFindingGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelReputationRiskFindingGetDto>>> GetAllRisksByPersonelIdAsync(int personelId)
        {
            var list = await _riskFindingDal.GetAllReportsByPerosnelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelReputationRiskFindingGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelReputationRiskFindingGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PersonelReputationRiskFindingGetDto>> GetRiskByIdAsync(int id)
        {
            var entity = await _riskFindingDal.GetReportAsync(id);
            if (entity==null)
            {
                return new ErrorDataResult<PersonelReputationRiskFindingGetDto>(Messages.EntityNotFound);
                
            }
            return new SuccessDataResult<PersonelReputationRiskFindingGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryPersonelReputationRiskFindingService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PersonelReputationRiskFindingValidator))]
        public async Task<IResult> AddRiskAsync(PersonelReputationRiskFindingAddDto dto)
        {
            var entity = _mapper.Map<MilitaryPersonelReputationRiskFinding>(dto);
            await _riskFindingDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelReputationRiskFindingService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(PersonelReputationRiskFindingValidator))]
        public async Task<IResult> UpdateRiskAsync(PersonelReputationRiskFindingUpdateDto dto)
        {
            var entity = await _riskFindingDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _riskFindingDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryPersonelReputationRiskFindingService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PersonelReputationRiskFindingValidator))]
        public async Task<IResult> DeleteRiskAsync(int id)
        {
            var entity = await _riskFindingDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _riskFindingDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
