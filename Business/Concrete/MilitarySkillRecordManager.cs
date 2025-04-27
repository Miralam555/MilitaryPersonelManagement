using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitarySkillRecordDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitarySkillRecordManager:IMilitarySkillRecordService
    {
        private readonly IMilitarySkillRecordDal _recordDal;
        private readonly IMapper _mapper;

        public MilitarySkillRecordManager(IMilitarySkillRecordDal recordDal, IMapper mapper)
        {
            _recordDal = recordDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitarySkillRecordGetDto>>> GetAllRecordsAsync()
        {
            var list = await _recordDal.GetAllSkillRecordsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<MilitarySkillRecordGetDto>>(list);
            }
            return new ErrorDataResult<List<MilitarySkillRecordGetDto>>(Messages.NoData);
        }
    }
}
