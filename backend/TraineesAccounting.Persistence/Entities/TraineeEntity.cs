namespace TraineesAccounting.Persistence.Entities
{
    public class TraineeEntity
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Gender { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required DateOnly Birthday { get; set; }
        public required string InternshipTitle { get; set; }
        public required string ProjectTitle { get; set; }
        public Guid? InternshipDirectionId { get; set; }
        public InternshipDirectionEntity? InternshipDirection { get; set; }
        public Guid? ProjectId { get; set; }
        public ProjectEntity? Project { get; set; }
    }
}
