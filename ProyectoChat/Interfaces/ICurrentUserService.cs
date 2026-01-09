namespace ProyectoChat.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        // Can add more properties like Role, Email, etc. if needed
        bool IsAuthenticated { get; }
    }
}
