using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.ProfessionalDevelopmentCourse;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProfessionalDevelopmentCourseManager:IProfessionalDevelopomentCourseService
    {
        private readonly IProfessionalDevelopmentCourseDal _courseDal;
        private readonly IMapper _mapper;

        public ProfessionalDevelopmentCourseManager(IProfessionalDevelopmentCourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesAsync()
        {
            var list = await _courseDal.GetAllCoursesAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<ProfessionalDevelopmentCourseGetDto>>(list);
            }
            return new ErrorDataResult<List<ProfessionalDevelopmentCourseGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesByPersonelIdAsync(int personelId)
        {
            var list = await _courseDal.GetAllCoursesByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<ProfessionalDevelopmentCourseGetDto>>(list);
            }
            return new ErrorDataResult<List<ProfessionalDevelopmentCourseGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesByInjunctionIdAsync(int injunctionId)
        {
            var list = await _courseDal.GetAllCoursesByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<ProfessionalDevelopmentCourseGetDto>>(list);
            }
            return new ErrorDataResult<List<ProfessionalDevelopmentCourseGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<ProfessionalDevelopmentCourseGetDto>> GetByIdAsync(int id)
        {
            var entity = await _courseDal.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<ProfessionalDevelopmentCourseGetDto>(Messages.EntityNotFound);
            }
            return new SuccessDataResult<ProfessionalDevelopmentCourseGetDto>(entity);
        }
        [CacheRemoveAspect("IProfessionalDevelopomentCourseService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(ProfessionalDevelopmentCourseValidator))]
        public async Task<IResult> AddCourseAsync(ProfessionalDevelopmentCourseAddDto dto)
        {
            var entity = _mapper.Map<ProfessionalDevelopmentCourse>(dto);
            await _courseDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IProfessionalDevelopomentCourseService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(ProfessionalDevelopmentCourseValidator))]
        public async Task<IResult> UpdateCourseAsync(ProfessionalDevelopmentCourseUpdateDto dto)
        {
            var entity = await _courseDal.GetAsync(p=>p.Id==dto.Id);
            _mapper.Map(dto, entity);
            await _courseDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IProfessionalDevelopomentCourseService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteCourseAsync(int id)
        {
            var entity = await _courseDal.GetAsync(p=>p.Id==id);
            await _courseDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
