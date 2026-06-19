namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> category, string description, string imagefile, decimal price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Category = request.category, Description = request.description,
                Name = request.name, ImageFile = request.imagefile, Price = request.price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
