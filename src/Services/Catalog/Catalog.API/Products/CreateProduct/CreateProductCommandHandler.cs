using Catalog.API.Dtos;
using Catalog.API.Models;
using Common.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> category, string description, string imagefile, decimal price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Category = request.category, Description = request.description,
                Name = request.name, ImageFile = request.imagefile, Price = request.price
            };
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
