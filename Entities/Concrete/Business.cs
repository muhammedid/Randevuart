using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Business:IEntity
    {

        [Key]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string VKN { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int CityCode { get; set; }        
        public int DistrictCode { get; set; }
    }
}
