using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product? Product);
    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductByIdQueryHandler called with query: {query}");
            var result = await session.LoadAsync<Product>(query.Id);
            return result is null ? new GetProductByIdResult(null) : new GetProductByIdResult(result);
        }
    }
}
