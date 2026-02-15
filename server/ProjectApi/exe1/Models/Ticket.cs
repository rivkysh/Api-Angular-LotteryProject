using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exe1.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public Prize? prize { get; set; }

        public int UserId { get; set; }

        public User? user { get; set; }

        public DateTime OrderDate { get; set; }
    }
}