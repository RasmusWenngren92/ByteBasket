namespace ByteBasket;

public class Amount
{
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }

    public Amount(int quantity, int totalPrice)
    {
        Quantity = quantity;
        TotalPrice = totalPrice;
    }
}