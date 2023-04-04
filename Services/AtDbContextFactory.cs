using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AtDbContextFactory : IDesignTimeDbContextFactory<AtDbContext>
    {
        public AtDbContext CreateDbContext(string[] args) 
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\GerenteLivrosAtDB.mdf;Integrated Security=True;Connect Timeout=30");
            return new AtDbContext(optionsBuilder.Options);
        }
    }
}
