namespace iwant_backend.Endpoints.Products;

public record ProductResponse(Guid Id, string Name, string CategoryName, string Description, int Amount, decimal Price, bool Active, string MainImage);