namespace APIServiceStack
{
    public interface IAuthProvider
    {
        bool UserIsValid(string token);
    }
}