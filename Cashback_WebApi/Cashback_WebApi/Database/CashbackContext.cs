using Cashback_WebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback_WebApi.Database
{
    public class CashbackContext : IdentityDbContext<RevendedoraModel>
    {
        public DbSet<CompraModel> Compras { get; set; }

        public CashbackContext(DbContextOptions<CashbackContext> options) : base(options)
        {

        }
    }
}
