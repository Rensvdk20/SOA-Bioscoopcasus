using Xunit;
using SOA_BioscoopCasus.Domain;

public class CalculatePriceTests
{
    [Fact]
    public void Student_With_Uneven_Premium_Tickets()
    {
        // Arrange
        Order order1 = new Order(1, true);
        order1.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        decimal expectedResult = 12;

        // Act
        decimal actualResult = order1.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Student_With_Uneven_Normal_Tickets()
    {
        // Arrange
        Order order2 = new Order(1, true);
        order2.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, false));
        decimal expectedResult = 10;

        // Act
        decimal actualResult = order2.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Student_With_Even_Premium_Tickets()
    {
        // Arrange
        Order order3 = new Order(1, true);
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        order3.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));
        decimal expectedResult = 12;

        // Act
        decimal actualResult = order3.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_In_Weekend_With_6_Premium_Tickets()
    {
        // Arrange
        Order order4 = new Order(1, false); // 70,2 | Non-student in het weekend met >= 6 premium tickets
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        order4.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, true));
        decimal expectedResult = 70.2M;

        // Act
        decimal actualResult = order4.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_In_Weekend_With_1_Premium_Ticket()
    {
        // Arrange
        Order order5 = new Order(1, false);
        order5.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 2), 10), 1, 1, false));
        decimal expectedResult = 10;

        // Act
        decimal actualResult = order5.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Uneven_Premium_Tickets()
    {
        // Arrange
        Order order6 = new Order(1, false);
        order6.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        decimal expectedResult = 13;

        // Act
        decimal actualResult = order6.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Uneven_Normal_Tickets()
    {
        // Arrange
        Order order7 = new Order(1, false);
        order7.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, false));
        decimal expectedResult = 10;

        // Act
        decimal actualResult = order7.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Non_Student_On_Workday_With_Even_Premium_Tickets()
    {
        // Arrange
        Order order8 = new Order(1, false); // 26 | Non-student buiten het weekend met een even aantal premium tickets
        order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        order8.addSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), new DateTime(2024, 2, 1), 10), 1, 1, true));
        decimal expectedResult = 26;

        // Act
        decimal actualResult = order8.calculatePrice();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}