public class Programm
{
    public static void Main()
    {

        string productName = ReadProductName();
        int quantity = ReadQuantity();
        string userName = ReadUserName();
        string address = ReadAddress();
        DateTime todayDate = new DateTime( 2025, 4, 1 );
        ConfirmOrder( productName, quantity, userName, address, todayDate );
    }

    static string ReadUserName()
    {
        Console.Write( "Введите свое имя: " );
        string userName = Console.ReadLine();
        while ( string.IsNullOrWhiteSpace( userName ) )
        {
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
            productName = Console.ReadLine();
        }

        return productName;
    }

    static int ReadQuantity()
    {
        Console.Write( "Введите количество товара: " );
        int quantity;
        while ( !int.TryParse( Console.ReadLine(), out quantity ) || ( quantity == 0 ) )
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
            address = Console.ReadLine();
        }

        return address;
    }

    static void ConfirmOrder( string productName, int quantity, string userName, string address, DateTime todayDate )
    {
        string confirmation;

        Console.WriteLine( $"Здравствуйте, {userName}, вы заказали {quantity} {productName} на адрес {address}, все верно?" );
        Console.WriteLine( "Да - Y, нет - N" );
        confirmation = Console.ReadLine();
        while ( ( confirmation != "Y" ) & ( confirmation != "N" ) )
        {
            Console.WriteLine( "Введите Y или N: " );
            confirmation = Console.ReadLine();
        }

        if ( confirmation == "Y" )
        {
            Console.WriteLine( $"{userName}! Ваш заказ {productName} в количестве {quantity} оформлен! Ожидайте доставку по адресу {address} к {todayDate.AddDays( 3 )}" );
        }
        else if ( confirmation == "N" )
        {
            Console.WriteLine( "Заказ не оформлен" );
        }
    }
}