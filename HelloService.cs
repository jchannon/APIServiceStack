using ServiceStack.ServiceInterface;

namespace APIServiceStack
{
    public class HelloService : Service
    {
        public object Get(GetDataRequest request)
        {
            return new GetDataResponse() { LastName = "Smith", Name = "Fred" };
        }
    }
}