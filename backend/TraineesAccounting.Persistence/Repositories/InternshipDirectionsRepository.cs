using Microsoft.EntityFrameworkCore;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Repositories
{
    public class InternshipDirectionsRepository(
        DatabaseContext databaseContext
        ) : IInternshipDirectionsRepository
    {
        public async Task<List<InternshipDirectionEntity>> All()
        {
            return await databaseContext.InternshipDirections
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<InternshipDirectionEntity?> GetById(Guid id)
        {
            return await databaseContext.InternshipDirections
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<InternshipDirectionEntity>> GetByPage(int page, int pageSize)
        {
            return await databaseContext.InternshipDirections
                .AsNoTracking()
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(InternshipDirectionEntity internshipDirection)
        {
            internshipDirection.Id = Guid.NewGuid();
            await databaseContext.InternshipDirections.AddAsync(internshipDirection);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(InternshipDirectionEntity updatedInternshipDirection)
        {
            databaseContext.InternshipDirections.Update(updatedInternshipDirection);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var internshipDirection = await databaseContext.InternshipDirections
                .Include(i => i.Trainees)
                .FirstOrDefaultAsync(i => i.Id == id);

            foreach (var trainee in internshipDirection.Trainees) trainee.InternshipTitle = "";

            await databaseContext.InternshipDirections
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();
            await databaseContext.SaveChangesAsync();
        }
    }
}
