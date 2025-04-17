using System.Net;

public class Programm
{
    public static void Main()
    {
        Console.WriteLine( "Приветствуем в менеджере заказов" );
        Console.WriteLine( "--------------------------------------------" );

        var order = new Order
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
        while ( !int.TryParse( Console.ReadLine(), out quantity ) || ( quantity == 0 ) || ( quantity < 0 ) )
        {
            Console.Write( "Введите корректное количество товара: " );
        }

        return quantity;
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

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string UserName { get; set; }
    public string Address { get; set; }
    public DateTime TodayDate { get; set; }
}

public static class OrderProcessor
{
    public static void ConfirmOrder( Order order )
    {
        Console.WriteLine( $"Здравствуйте, {order.UserName}, вы заказали {order.Quantity} " +
            $"{order.ProductName} на адрес {order.Address}, все верно?" );
        Console.WriteLine( "Да - Y/y, нет - любой другой символ" );
        string confirmation = Console.ReadLine();

        switch ( confirmation )
        {
            case var s when s == "Y" || s == "y":
                Console.WriteLine( $"{order.UserName}! Ваш заказ {order.ProductName} в количестве " +
                    $"{order.Quantity} оформлен! Ожидайте доставку по адресу {order.Address} к {order.TodayDate.AddDays( 3 )}" );
                break;
            default:
                Console.WriteLine( "Заказ не оформлен" );
                break;
        }
    }
}