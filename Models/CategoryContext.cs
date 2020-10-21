using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Stockpoint.Models
{
public class CategoryContext:DbContext
    {
        
            public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
            {
            }
            public DbSet<Category> category { get; set; }
        
    }
}