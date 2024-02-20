using SOA_BioscoopCasus.Behaviours;
using SOA_BioscoopCasus.Domain;
using SOA_BioscoopCasus.Interfaces;
using SOA_BioscoopCasus.Rules;
using SOA_BioscoopCasus.States;
using Xunit;

namespace SOA_BioscoopCasus
{
    public class StateTests
    {
        private StringWriter writer = new StringWriter();
        private static readonly IEnumerable<ITicketPriceRule> ticketPriceRules = new List<ITicketPriceRule>
        {
            new TicketFreeRule(),
            new TicketPremiumRule(),
            new TicketBatchDiscountRule()
        };

        public StateTests()
        {
            Console.SetOut(writer);
        }

        // Created
        [Fact]
        public void State_Created_Add_Seat()
        {
            var order = GetFakeOrder();
            var seatCount = order.GetTickets().Count;
            order.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 2, true));
            Assert.Equal(seatCount + 1, order.GetTickets().Count);
        }

        [Fact]
        public void State_Created_Submit()
        {
            var order = GetFakeOrder();
            order.SubmitOrder();
            Assert.IsType<ReservedState>(order.GetCurrentState());
        }

        [Fact]
        public void State_Created_Pay_Order()
        {
            var order = GetFakeOrder();
            order.PayOrder();
            Assert.Equal("Order moet eerst worden ingediend voordat er betaald kan worden.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Created_Cancel_Order()
        {
            var order = GetFakeOrder();
            order.CancelOrder();
            Assert.IsType<CancelledState>(order.GetCurrentState());
        }

        // Reserved
        [Fact]
        public void State_Reserved_Add_Seat()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetReservedState());
            order.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 2, true));
            Assert.Equal("Order kan niet worden aangepast als deze al is gereserveerd.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Reserved_Submit()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetReservedState());
            order.SubmitOrder();
            Assert.Equal("Order is al gereserveerd.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Reserved_Pay_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetReservedState());
            order.PayOrder();
            Assert.IsType<PaidState>(order.GetCurrentState());
        }

        [Fact]
        public void State_Reserved_Cancel_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetReservedState());
            order.CancelOrder();
            Assert.IsType<CancelledState>(order.GetCurrentState());
        }

        // Paid
        [Fact]
        public void State_Paid_Add_Seat()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetPaidState());
            order.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 2, true));
            Assert.Equal("Order kan niet worden aangepast nadat deze is betaald.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Paid_Submit()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetPaidState());
            order.SubmitOrder();
            Assert.Equal("Order is al betaald.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Paid_Pay_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetPaidState());
            order.PayOrder();
            Assert.Equal("Order is al betaald.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Paid_Cancel_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetPaidState());
            order.CancelOrder();
            Assert.Equal("Order kan niet worden geannuleerd nadat deze is betaald.", writer.ToString().Trim());
        }

        // Cancelled
        [Fact]
        public void State_Cancelled_Add_Seat()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetCancelledState());
            order.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 2, true));
            Assert.Equal("Geannuleerde order kan niet worden aangepast.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Cancelled_Submit()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetCancelledState());
            order.SubmitOrder();
            Assert.Equal("Geannuleerde order kan niet worden ingediend.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Cancelled_Pay_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetCancelledState());
            order.PayOrder();
            Assert.Equal("Geannuleerde order kan niet worden betaald.", writer.ToString().Trim());
        }

        [Fact]
        public void State_Cancelled_Cancel_Order()
        {
            var order = GetFakeOrder();
            order.SetState(order.GetCancelledState());
            order.CancelOrder();
            Assert.Equal("Order is al geannuleerd.", writer.ToString().Trim());
        }

        public IOrder GetFakeOrder()
        {
            IOrder order = new Order(1, true, ticketPriceRules, new JsonExport());
            order.AddSeatReservation(new MovieTicket(new MovieScreening(new Movie("The Matrix"), DateTime.Now, 10), 1, 1, true));

            return order;
        }
    }
}
