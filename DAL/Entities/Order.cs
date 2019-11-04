using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartReservation { get; set; }
        public DateTime FinishReservation { get; set; }
        public bool IsClose { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
