using Microsoft.EntityFrameworkCore;

namespace user-microservice.Src.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
    }

}
