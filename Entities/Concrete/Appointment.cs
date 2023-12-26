using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //randevu
    public class Appointment:IEntity
    {
        [Key]
        public int ID { get; set; }
        public int BusinessID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
        public int Status { get; set; } = 0;
    }
}
