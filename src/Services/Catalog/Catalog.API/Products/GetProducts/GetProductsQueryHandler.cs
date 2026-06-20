namespace Catalog.API.Products.GetProducts
{
    public record GetProductQuery() : IQuery<GetProductQueryResult>;
    public record GetProductQueryResult(IEnumerable<Product> Products);
    public class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductsQueryHandler called with query: {query}");
            var products = await session.Query<Product>().ToListAsync();
            return new GetProductQueryResult(products);
        }
    }
}
