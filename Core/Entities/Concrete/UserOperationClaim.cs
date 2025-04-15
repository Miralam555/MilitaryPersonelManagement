namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}
