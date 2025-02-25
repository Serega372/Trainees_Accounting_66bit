using AutoMapper;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Api.Services
{
    public class ProjectsService(
        IProjectsRepository projectsRepository,
        IMapper mapper
        ) : IProjectsService
    {
        public async Task<List<ProjectsResponse>> All()
        {
            var projects = await projectsRepository.All();
            return mapper.Map<List<ProjectsResponse>>(projects);
        }

        public async Task<ProjectsResponse> GetById(Guid id)
        {
            var project = await projectsRepository.GetById(id)
                ?? throw new Exception($"Project with id: {id} not found");
            return mapper.Map<ProjectsResponse>(project);
        }

        public async Task<List<ProjectsResponse>> GetByPage(int page, int pageSize)
        {
            var projects = await projectsRepository.GetByPage(page, pageSize);
            return mapper.Map<List<ProjectsResponse>>(projects);
        }

        public async Task Add(AddProjectRequest projectDto)
        {
            var projectEntity = mapper.Map<ProjectEntity>(projectDto);
            await projectsRepository.Add(projectEntity);
        }

        public async Task Update(Guid id, UpdateProjectRequest updatedProjectDto)
        {
            var currentProject = await projectsRepository.GetById(id)
                ?? throw new Exception($"Project with id: {id} not found");
            currentProject.ProjectTitle = updatedProjectDto.ProjectTitle;
            await projectsRepository.Update(currentProject);
        }

        public async Task Delete(Guid id)
        {
            var project = projectsRepository.GetById(id)
                ?? throw new Exception($"Project with id: {id} not found");
            await projectsRepository.Delete(id);
        }
    }
}
