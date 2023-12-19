using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OnlineRandevuDBContext : DbContext
    {
        public OnlineRandevuDBContext()
        {

        }

        public OnlineRandevuDBContext(DbContextOptions<OnlineRandevuDBContext> options) : base(options) { }


    }
}
