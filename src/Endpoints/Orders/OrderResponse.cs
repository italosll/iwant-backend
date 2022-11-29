namespace iwant_backend.Endpoints.Orders;

public record OrderResponse(Guid Id, List<Product> Products, decimal Total, string DeliveryAddress);
