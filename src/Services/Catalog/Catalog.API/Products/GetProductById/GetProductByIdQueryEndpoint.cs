using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product product);
    public class GetProductByIdQueryEndpoint : ICarterModule
    {
        public async void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async ([AsParameters] GetProductByIdRequest request, ISender sender) => 
            {
                var query = request.Adapt<GetProductByIdQuery>();
                var result = await sender.Send(query);
                if (result.Product is null)
                {
                    //return Results.NotFound($"Product with Id: {Id} not found");
                    throw new NotFoundException("Product", request.Id);
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
