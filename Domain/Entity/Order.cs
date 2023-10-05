namespace Domain.Entity;
public class Order
{
    public long Id { get; set; }
    public long StadiumId { get; set; }
    public long UserId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string OrderDateTime { get; set; }
}
