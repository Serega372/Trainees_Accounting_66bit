using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Persistence.Abstract
{
    public interface ITraineesRepository
    {
        Task Add(TraineeEntity trainee);
        Task<List<TraineeEntity>> All();
        Task Delete(Guid id);
        Task<TraineeEntity?> GetById(Guid id);
        Task<List<TraineeEntity>> GetByPage(int page, int pageSize);
        Task Update(TraineeEntity upatedTrainee);
    }
}