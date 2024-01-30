// See https://aka.ms/new-console-template for more information
using SOA_BioscoopCasus.Domain;

Order order = new Order(1, true);
order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10.0), 1, 1, false));
order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 2"), DateTime.Now, 10.0), 1, 2, false));
order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 3"), DateTime.Now, 10.0), 1, 3, false));
order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 4"), DateTime.Now, 10.0), 1, 4, false));
order.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix 5"), DateTime.Now, 10.0), 1, 5, false));

Console.WriteLine(order.calculatePrice());