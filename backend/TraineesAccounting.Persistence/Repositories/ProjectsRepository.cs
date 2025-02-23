using Microsoft.EntityFrameworkCore;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Repositories
{
    public class ProjectsRepository(
        DatabaseContext databaseContext
        ) : IProjectsRepository
    {
        public async Task<List<ProjectEntity>> All()
        {
            return await databaseContext.Projects
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProjectEntity?> GetById(Guid id)
        {
            return await databaseContext.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProjectEntity>> GetByPage(int page, int pageSize)
        {
            return await databaseContext.Projects
                .AsNoTracking()
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(ProjectEntity project)
        {
            project.Id = Guid.NewGuid();
            await databaseContext.Projects.AddAsync(project);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(ProjectEntity updatedProject)
        {
            databaseContext.Projects.Update(updatedProject);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await databaseContext.Projects
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            await databaseContext.SaveChangesAsync();
        }
    }
}
