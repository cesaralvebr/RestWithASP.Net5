using Microsoft.EntityFrameworkCore;
using RestWithASP.Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Context
{
    public class MySQLContext:DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options):base(options) {}

        public DbSet<Person> People { get; set; }
    }
}
