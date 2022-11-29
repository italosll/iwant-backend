namespace iwant_backend.Endpoints.Orders;

public record OrderRequest(List<Guid> ProductIds, string DeliveryAddress);
