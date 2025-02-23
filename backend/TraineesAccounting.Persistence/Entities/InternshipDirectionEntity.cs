namespace TraineesAccounting.Persistence.Entities
{
    public class InternshipDirectionEntity
    {
        public required Guid Id { get; set; }
        public required string InternshipTitle { get; set; }
        public virtual List<TraineeEntity>? Trainees { get; set; }
    }
}
