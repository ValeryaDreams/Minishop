using WebApi.Models;

namespace WebApi
{
        public class Program
        {
                public static void Main(string[] args)
                {
                        var builder = WebApplication.CreateBuilder(args);

                        builder.Services.AddEndpointsApiExplorer();
                        builder.Services.AddSwaggerGen();

                        builder.Services.AddSingleton<OrderStore>();

                        var app = builder.Build();

                        app.UseSwagger();
                        app.UseSwaggerUI();

                        app.MapPost("/orders", (OrderStore store) =>
                        {
                                var order = store.CreateOrder();
                                return Results.Ok(order);
                        });

                        app.MapPost("/order/{id:int}", (int id, OrderStore store) =>
                        {
                                var order = store.GetOrder(id);
                                return order is null ? Results.NotFound() : Results.Ok(order);
                        });

                        app.Run();
                }
        }
}