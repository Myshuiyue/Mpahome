using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpahome.Domain.Entities;

namespace Mpahome.Domain.Abstract
{
    public interface IBlogsRepository
    {
        IQueryable<Blog> Blogs { get; }
    }
}
