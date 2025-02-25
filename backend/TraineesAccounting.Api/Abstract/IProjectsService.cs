using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Abstract
{
    public interface IProjectsService
    {
        Task Add(AddProjectRequest projectDto);
        Task<List<ProjectsResponse>> All();
        Task Delete(Guid id);
        Task<ProjectsResponse> GetById(Guid id);
        Task<List<ProjectsResponse>> GetByPage(int page, int pageSize);
        Task Update(Guid id, UpdateProjectRequest updatedProjectDto);
    }
}