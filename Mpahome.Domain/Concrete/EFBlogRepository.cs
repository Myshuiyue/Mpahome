using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mpahome.Domain.Abstract;
using Mpahome.Domain.Entities;

namespace Mpahome.Domain.Concrete
{
    public class EFBlogRepository:IBlogsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Blog> Blogs { get { return context.Blogs; } }
    }
}
