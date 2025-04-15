using Core.DataAccess;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInjunctionDal : IEntityRepository<Injunction>
    {
        Task<List<Injunction>> GetAllInjunctionWithDetailsAsync();
        Task<Injunction> GetByIdInjunctionWithDetailsAsync(int id);
        Task<List<Injunction>> GetAllInjunctionsByIssuedPersonelIdWithDetailsAsync(int id);
    }

}
