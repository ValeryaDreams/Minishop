
namespace Worker
{
        public class Program
        {
                public static void Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);
                        builder.Services.AddHostedService<Worker>();

                        var app = builder.Build();

                        app.Run();
                }
        }
}
