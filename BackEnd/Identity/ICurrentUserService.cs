namespace Identity
{
    public interface ICurrentUserService
    {
        Guid? GetCurrentUserId();
    }
}