using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class OrderViewModel
    {
        public DateTime StartReservation { get; set; }
        public DateTime FinishReservation { get; set; }
        public BookModel OrderBook { get; set; }
    }
}
