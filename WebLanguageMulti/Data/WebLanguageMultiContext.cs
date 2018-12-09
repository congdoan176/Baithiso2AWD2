using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebLanguageMulti.Models
{
    public class WebLanguageMultiContext : DbContext
    {
        public WebLanguageMultiContext (DbContextOptions<WebLanguageMultiContext> options)
            : base(options)
        {
        }

        public DbSet<WebLanguageMulti.Models.RegisterViews> RegisterViews { get; set; }
    }
}
