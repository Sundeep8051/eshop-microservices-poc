using Catalog.API.Exceptions;
using Catalog.API.Products.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product product);
    public class GetProductByIdQueryEndpoint : ICarterModule
    {
        public async void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid Id, ISender sender) => 
            {
                var result = await sender.Send(new GetProductByIdQuery(Id));
                if (result.Product is null)
                {
                    //return Results.NotFound($"Product with Id: {Id} not found");
                    throw new NotFoundException("Product", Id);
                }
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get ProductById")
            .WithDescription("Get ProductById");
        }
    }
}
