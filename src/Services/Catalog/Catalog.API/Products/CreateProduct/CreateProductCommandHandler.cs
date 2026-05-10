using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public CreateProductCommandHandler()
    {

    }

    public async Task<CreateProductResult> HandleAsync(CreateProductCommand command, CancellationToken cancellation)
    {
        // Simulate some processing time
        await Task.Delay(100);
        // In a real application, you would save the product to a database here
        // For this example, we'll just return a new product ID
        return new CreateProductResult(Guid.NewGuid());
    }
}
