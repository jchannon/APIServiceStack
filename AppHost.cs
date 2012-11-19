using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace APIServiceStack
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("StarterTemplate HttpListener", typeof(HelloService).Assembly) { }

        public override void Configure(Funq.Container container)
        {
            container.Register<IAuthProvider>((c) => new AuthProvider());

            Routes
                .Add<GetDataRequest>("/GetData");


            this.RequestFilters.Add((req, res, dto) =>
            {
                //if (!req.IsSecureConnection)
                //{
                //    res.StatusCode = 401;
                //    res.Close();
                //}

                if (req.Headers["Authorization"] != null)
                {
                    const string key = "Bearer ";
                    string accessToken = null;

                    var header = req.Headers["Authorization"];
                    if (header.StartsWith(key))
                    {
                        accessToken = header.Substring(key.Length);
                    }

                    if (string.IsNullOrWhiteSpace(accessToken))
                    {
                        res.StatusCode = 401;
                        res.Close();
                    }

                    //Lookup

                    var provider = container.Resolve<IAuthProvider>();

                    if (!provider.UserIsValid(accessToken))
                    {
                        res.StatusCode = 401;
                        res.Close();
                    }

                }
            });
        }
    }
}