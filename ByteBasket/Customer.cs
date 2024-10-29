namespace ByteBasket;

public class Customer
{
    public string FirstName { get; set; }
    public string Adress { get; set; }
    public string Telephone { get; set; }

    public Customer(string firstName, string adress, string telephone)
    {
        FirstName = firstName;
        Adress = adress;
        Telephone = telephone;
    }
}