using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webformulario.Models;

namespace webformulario.Data
{
    public class webformularioContext : DbContext
    {
        public webformularioContext (DbContextOptions<webformularioContext> options)
            : base(options)
        {
        }

        public DbSet<webformulario.Models.filiacao> filiacao { get; set; } = default!;
    }
}
