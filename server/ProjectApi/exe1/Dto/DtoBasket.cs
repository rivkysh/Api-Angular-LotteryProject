using exe1.Models;

namespace exe1.Dto
{
    public class DtoListOrders
    {
        public Prize prize { get; set; }
        public User user { get; set; }
        public int ticketsAmaunt { get; set; }
        public DateTime date { get; set; }

    }
}
