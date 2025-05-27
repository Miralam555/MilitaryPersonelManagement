using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MilitaryBaseContext>, IUserDal
    {
        public EfUserDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public Task<List<OperationClaim>> GetClaimsAsync(User user)
        {
           
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToListAsync();
        }
        
    }
}
