﻿using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastucture.Data
{
    public class BlogDbContext: DbContext

    {
        // gunakan snippet ctor untuk membuat constuctor
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions): base(dbContextOptions) { }
        
        public DbSet<Blog> Blogs { get; set; }

    }
}
