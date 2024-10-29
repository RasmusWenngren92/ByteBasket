namespace ByteBasket;

public class Amount
{
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Amount(int quantity, decimal totalPrice)
    {
        Quantity = quantity;
        TotalPrice = totalPrice;
    }
}