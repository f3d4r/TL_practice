using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class OrderProcessor
    {
        public static void ConfirmOrder( Order order )
        {
            Console.WriteLine( $"Здравствуйте, {order.UserName}, вы заказали {order.Quantity} " +
                $"{order.ProductName} на адрес {order.Address}, все верно?" );
            Console.WriteLine( "Да - Y/y, нет - любой другой символ" );
            string confirmation = Console.ReadLine();

            switch ( confirmation )
            {
                case string s when s.ToLower() == "y":
                    Console.WriteLine( $"{order.UserName}! Ваш заказ {order.ProductName} в количестве " +
                        $"{order.Quantity} оформлен! Ожидайте доставку по адресу {order.Address} к {order.TodayDate.AddDays( 3 )}" );
                    break;
                default:
                    Console.WriteLine( "Заказ не оформлен" );
                    break;
            }
        }
    }
}
