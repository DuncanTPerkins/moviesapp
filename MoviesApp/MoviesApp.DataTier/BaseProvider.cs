using System.Configuration;
using MoviesApp.Models;
using System.Data.SqlClient;

namespace MoviesApp.DataTier
{
    public abstract class BaseProvider
    {
        protected string ConnectionString =
            ConfigurationManager.ConnectionStrings["MovieDb"].ConnectionString;
        protected DbUtils _utils;
        protected BaseProvider()
        {
            _utils = new DbUtils();
        }
    }
}
