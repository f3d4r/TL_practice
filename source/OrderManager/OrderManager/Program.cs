using System.Net;
using OrderManager;

public class Programm
{
    public static void Main()
    {
        Console.WriteLine( "Приветствуем в менеджере заказов" );
        Console.WriteLine( "--------------------------------------------" );

        Order order = new Order
        {
            ProductName = ReadProductName(),
            Quantity = ReadQuantity(),
            UserName = ReadUserName(),
            Address = ReadAddress(),
            TodayDate = DateTime.Now
        };


        OrderProcessor.ConfirmOrder( order );

        Console.WriteLine( "--------------------------------------------" );
        Console.WriteLine( "Спасибо за использование приложения. До свидания!" );
    }

    static string ReadUserName()
    {
        Console.Write( "Введите свое имя: " );
        string userName = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( userName ) )
        {
            Console.WriteLine( "Поле не может быть пустым" );
            Console.Write( "Введите свое имя: " );
            userName = Console.ReadLine();
        }

        return userName;
    }

    static string ReadProductName()
    {
        Console.Write( "Введите название товара: " );
        string productName = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( productName ) )
        {
            Console.WriteLine( "Поле не может быть пустым" );
            Console.Write( "Введите название товара: " );
            productName = Console.ReadLine();
        }

        return productName;
    }

    static int ReadQuantity()
    {
        Console.Write( "Введите количество товара: " );
        int quantity;
        string? input = Console.ReadLine();

        while ( !ValidQuantity( input, out quantity ) )
        {
            Console.Write( "Введите корректное количество товара: " );
            input = Console.ReadLine();
        }

        return quantity;
    }

    static bool ValidQuantity( string? input, out int quantity )
    {
        return int.TryParse( input, out quantity ) && quantity > 0;
    }

    static string ReadAddress()
    {
        Console.Write( "Введите адрес доставки: " );
        string address = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( address ) )
        {
            Console.WriteLine( "Поле не может быть пустым" );
            Console.Write( "Введите адрес доставки: " );
            address = Console.ReadLine();
        }

        return address;
    }
}