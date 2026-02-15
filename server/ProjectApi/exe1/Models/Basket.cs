using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace exe1.Models;

public partial class Basket
{
    public int Id { get; set; }

   [ForeignKey("User")]
    public int UserId { get; set; }

    public  virtual User? User { get; set; }

    public ICollection<Ticket>? YourTickets { get; set; }
 
    
}
