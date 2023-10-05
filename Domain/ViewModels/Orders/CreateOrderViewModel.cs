namespace Domain.ViewModels.Orders;
public class CreateOrderViewModel
{
    public long StadiumId { get; set; }
    public long UserId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string OrderDateTime { get; set; }
}
