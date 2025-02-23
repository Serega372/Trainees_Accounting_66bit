namespace TraineesAccounting.Persistence.Entities
{
    public class ProjectEntity
    {
        public required Guid Id { get; set; }
        public required string ProjectTitle { get; set; }
        public virtual List<TraineeEntity>? Trainees { get; set; }
    }
}
