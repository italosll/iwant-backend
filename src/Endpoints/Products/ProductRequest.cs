namespace iwant_backend.Endpoints.Products;

public record ProductRequest(string Name, Guid CategoryId, string Description, int Amount, decimal Price, bool Active, string MainImage);