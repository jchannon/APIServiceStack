namespace APIServiceStack
{
    public class AuthProvider : IAuthProvider
    {
        public bool UserIsValid(string token)
        {
            return token == "fred";
        }
    }
}