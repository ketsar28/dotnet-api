namespace ClassicShopAPI.DTO;

public class PurchaseResponse
{
    public string UserId { get; set;}

    public DateTime TransDate { get; set;}

    public List<PurchaseDetailResponse> PurchaseDetail { get; set;}
}