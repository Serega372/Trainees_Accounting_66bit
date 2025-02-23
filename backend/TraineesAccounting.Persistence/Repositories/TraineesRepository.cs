using Microsoft.EntityFrameworkCore;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Repositories
{
    public class TraineesRepository(
        DatabaseContext databaseContext
        ) : ITraineesRepository
    {
        public async Task<List<TraineeEntity>> All()
        {
            return await databaseContext.Trainees
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TraineeEntity?> GetById(Guid id)
        {
            return await databaseContext.Trainees
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TraineeEntity>> GetByPage(int page, int pageSize)
        {
            return await databaseContext.Trainees
                .AsNoTracking()
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Add(TraineeEntity trainee)
        {
            trainee.Id = Guid.NewGuid();
            await databaseContext.Trainees.AddAsync(trainee);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Update(TraineeEntity upatedTrainee)
        {
            databaseContext.Trainees.Update(upatedTrainee);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await databaseContext.Trainees
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
            await databaseContext.SaveChangesAsync();
        }
    }
}
