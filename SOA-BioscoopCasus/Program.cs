using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using SOA_BioscoopCasus.Domain;

namespace SOA_BioscoopCasus
{
    class Program
    {
        static void Main()
        {
            Order order1 = new Order(1, true); // 12 | Student met oneven aantal premium tickets
            order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
            Console.WriteLine(order1.calculatePrice());

            Order order2 = new Order(1, true); // 10 | Student met oneven aantal normale tickets
            order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
            Console.WriteLine(order2.calculatePrice());

            Order order3 = new Order(1, true); // 12 | Student met even aantal premium tickets
            order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
            order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
            Console.WriteLine(order3.calculatePrice());

            Order order4 = new Order(1, false); // 70,2 | Non-student in het weekend met >= 6 premium tickets
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
            Console.WriteLine(order4.calculatePrice());

            Order order5 = new Order(1, false); // 10 | Non-student in het weekend met < 6 normale tickets
            order5.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, false));
            Console.WriteLine(order5.calculatePrice());

            Order order6 = new Order(1, false); // 13 | Non-student buiten het weekend met een oneven aantal premium tickets
            order6.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
            Console.WriteLine(order6.calculatePrice());

            Order order7 = new Order(1, false); // 10 | Non-student buiten het weekend met een oneven aantal normale tickets
            order7.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, false));
            Console.WriteLine(order7.calculatePrice());

            Order order8 = new Order(1, false); // 26 | Non-student buiten het weekend met een even aantal premium tickets
            order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
            order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
            order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
            Console.WriteLine(order8.calculatePrice());
        }
    }
}
