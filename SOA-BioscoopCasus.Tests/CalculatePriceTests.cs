using SOA_BioscoopCasus.Behaviours;
using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Rules;
using Xunit;

public class CalculatePriceTests
{
    private static readonly IEnumerable<ITicketPriceRule> ticketPriceRules = new List<ITicketPriceRule>
    {
        new TicketFreeRule(),
        new TicketPremiumRule(),
        new TicketBatchDiscountRule()
    };

    [Fact]
    public void Student_With_Uneven_Premium_Tickets()
    {
        // Arrange
        Order order1 = new Order(1, true, ticketPriceRules, new JsonExport());
        order1.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        const decimal expectedResult = 12;

        // Act
        decimal actualResult = order1.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Student_With_Uneven_Normal_Tickets()
    {
        // Arrange
        Order order2 = new Order(1, true, ticketPriceRules, new JsonExport());
        order2.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        const decimal expectedResult = 10;

        // Act
        decimal actualResult = order2.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Student_With_Even_Premium_Tickets()
    {
        // Arrange
        Order order3 = new Order(1, true, ticketPriceRules, new JsonExport());
        order3.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        const decimal expectedResult = 12;

        // Act
        decimal actualResult = order3.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_In_Weekend_With_6_Premium_Tickets()
    {
        // Arrange
        Order order4 = new Order(1, false, ticketPriceRules, new JsonExport()); // 70,2 | Non-student in het weekend met >= 6 premium tickets
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        const decimal expectedResult = 70.2M;

        // Act
        decimal actualResult = order4.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_In_Weekend_With_1_Premium_Ticket()
    {
        // Arrange
        Order order5 = new Order(1, false, ticketPriceRules, new JsonExport());
        order5.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, false));
        const decimal expectedResult = 10;

        // Act
        decimal actualResult = order5.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Uneven_Premium_Tickets()
    {
        // Arrange
        Order order6 = new Order(1, false, ticketPriceRules, new JsonExport());
        order6.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        const decimal expectedResult = 13;

        // Act
        decimal actualResult = order6.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Uneven_Normal_Tickets()
    {
        // Arrange
        Order order7 = new Order(1, false, ticketPriceRules, new JsonExport());
        order7.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, false));
        decimal expectedResult = 10;

        // Act
        decimal actualResult = order7.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Even_Premium_Tickets()
    {
        // Arrange
        Order order8 = new Order(1, false, ticketPriceRules, new JsonExport());
        order8.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        order8.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        order8.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        decimal expectedResult = 26;

        // Act
        decimal actualResult = order8.CalculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}