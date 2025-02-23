using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Abstract
{
    public interface IInternshipDirectionsRepository
    {
        Task Add(InternshipDirectionEntity internshipDirection);
        Task<List<InternshipDirectionEntity>> All();
        Task Delete(Guid id);
        Task<InternshipDirectionEntity?> GetById(Guid id);
        Task<List<InternshipDirectionEntity>> GetByPage(int page, int pageSize);
        Task Update(InternshipDirectionEntity updatedInternshipDirection);
    }
}