using System;
using SOA_BioscoopCasus.Domain;

class Program
{
    static void Main()
    {
        // Student order
        Order order1 = new Order(1, true);
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10.0), 1, 1, false));
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10.0), 1, 2, true)); // Premium ticket
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10.0), 1, 3, false));
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10.0), 1, 4, true)); // Premium ticket
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10.0), 1, 5, false));

        Console.WriteLine(order1.calculatePrice());

        order1.export(TicketExportFormat.PLAINTEXT);

        // Non-student order
        Order order2 = new Order(2, false);
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10.0), 1, 1, false));
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10.0), 1, 2, true)); // Premium ticket
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10.0), 1, 3, false));
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10.0), 1, 4, true)); // Premium ticket
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10.0), 1, 5, false));

        Console.WriteLine(order2.calculatePrice());

        order2.export(TicketExportFormat.PLAINTEXT);

        // Non-student group order (werkt alleen in het weekend)
        Order order3 = new Order(3, false);
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10.0), 1, 1, false));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10.0), 1, 2, true)); // Premium ticket
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10.0), 1, 3, false));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10.0), 1, 4, true)); // Premium ticket
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10.0), 1, 5, false));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 6"), DateTime.Now, 10.0), 1, 6, true)); // Premium ticket

        Console.WriteLine(order3.calculatePrice());

        order3.export(TicketExportFormat.PLAINTEXT);
    }
}
