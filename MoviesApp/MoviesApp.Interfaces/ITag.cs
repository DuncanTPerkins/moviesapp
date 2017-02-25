using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public interface ITag
    {
        int TagId { get; set; }
        string TagDescription { get; set; }
    }
}