using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Abstract
{
    public interface IProjectsRepository
    {
        Task Add(ProjectEntity project);
        Task<List<ProjectEntity>> All();
        Task Delete(Guid id);
        Task<ProjectEntity?> GetById(Guid id);
        Task<List<ProjectEntity>> GetByPage(int page, int pageSize);
        Task Update(ProjectEntity updatedProject);
    }
}