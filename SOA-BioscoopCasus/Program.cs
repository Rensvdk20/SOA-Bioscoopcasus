using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using SOA_BioscoopCasus.Domain;

class Program
{
    static void Main()
    {
        //// Student order
        //Order order1 = new Order(1, true);
        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10), 1, 2, true)); // Premium ticket
        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10), 1, 3, false));
        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10), 1, 4, true)); // Premium ticket
        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10), 1, 5, false));

        //Console.WriteLine(order1.calculatePrice());

        //order1.export(TicketExportFormat.PLAINTEXT);
        //order1.export(TicketExportFormat.JSON);

        //Console.WriteLine("______________________________________________________________");

        //// Non-student order
        //Order order2 = new Order(2, false);
        //order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        //order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10), 1, 2, true)); // Premium ticket
        //order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10), 1, 3, false));
        //order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10), 1, 4, true)); // Premium ticket
        //order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10), 1, 5, false));

        //Console.WriteLine(order2.calculatePrice());

        //order2.export(TicketExportFormat.PLAINTEXT);
        //order2.export(TicketExportFormat.JSON);

        //Console.WriteLine("______________________________________________________________");

        //// Non-student group order (werkt alleen in het weekend)
        //Order order3 = new Order(3, false);
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10), 1, 2, true)); // Premium ticket
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10), 1, 3, false));
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10), 1, 4, true)); // Premium ticket
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10), 1, 5, false));
        //order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 6"), DateTime.Now, 10), 1, 6, true)); // Premium ticket

        //Console.WriteLine(order3.calculatePrice());

        //order3.export(TicketExportFormat.PLAINTEXT);
        //order3.export(TicketExportFormat.JSON);

        //Console.WriteLine("______________________________________________________________");

        //order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, [premium]));

        Order order1 = new Order(1, true); // 12 | Student met even aantal premium tickets
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        Console.WriteLine(order1.calculatePrice());

        Order order2 = new Order(1, true); // 10 | Student met oneven aantal normale tickets
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        Console.WriteLine(order2.calculatePrice());

        Order order3 = new Order(1, false); // 70,2 | Non-student in het weekend met >= 6 premium tickets
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        Console.WriteLine(order3.calculatePrice());

        Order order4 = new Order(1, false); // 13 | Non-student in het weekend met < 6 premium tickets
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        Console.WriteLine(order4.calculatePrice());

        Order order5 = new Order(1, false); // 10 | Non-student buiten het weekend met een even aantal tickets
        order5.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        order5.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        Console.WriteLine(order5.calculatePrice());

        Order order6 = new Order(1, false); // 10 | Non-student buiten het weekend met een oneven aantal tickets
        order6.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        Console.WriteLine(order6.calculatePrice());
    }
}
