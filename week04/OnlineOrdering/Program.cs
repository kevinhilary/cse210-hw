using System;
using System.Collections.Generic;

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address("123 Main St", "Nairobi", "Nairobi", "Kenya");
        Customer customer1 = new Customer("Kevin Hillary", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P001", 1200.00f, 2));
        order1.AddProduct(new Product("Laptop Stand", "P002", 3500.00f, 1));

        // Order 2
        Address address2 = new Address("456 Elm Street", "Salt Lake City", "Utah", "USA");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "P003", 500.00f, 3));
        order2.AddProduct(new Product("Pen Pack", "P004", 150.00f, 2));

        // Display Order 1
        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine($"Total Price: KES {order1.GetTotalPrice()}\n");

        // Display Order 2
        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine($"Total Price: USD {order2.GetTotalPrice()}\n");
    }
}

// ---------------------- Address Class ----------------------
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// ---------------------- Customer Class ----------------------
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetFullAddress()
    {
        return address.GetFullAddress();
    }
}

// ---------------------- Product Class ----------------------
class Product
{
    private string name;
    private string productId;
    private float price;
    private int quantity;

    public Product(string name, string productId, float price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public float GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

// ---------------------- Order Class ----------------------
class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public float GetTotalPrice()
    {
        float total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        if (customer.LivesInUSA())
            total += 5;
        else
            total += 35;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetFullAddress()}";
    }
}
