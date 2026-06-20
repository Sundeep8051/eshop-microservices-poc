namespace Catalog.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public Guid Id { get; }

        public NotFoundException(string entityName, Guid id)
            : base($"{entityName} with id '{id}' was not found.")
        {
            Id = id;
        }
    }
}
