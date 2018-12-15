using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class Rqt_SQL
    {

        public static string ListeClients(int IDStratégie)
        {
            return "SELECT TypeBook,IDBook,Number,Book.IDBooking,NbrBooker,Time FROM dbo.Booking, dbo.Book WHERE Book.IDBooking = Booking.IDBooking AND Booking.IDScenario = " + IDStratégie;
        }

        public static string Commandes(int IDBooking)
        {
            return "SELECT TypeBook,IDBook,Number FROM dbo.Book WHERE Book.IDBooking = " + IDBooking;
        }


    }
}