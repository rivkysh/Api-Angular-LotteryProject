using Microsoft.EntityFrameworkCore;

namespace exe1.data
{
    public class ProductContextFactory
    {


        private const string ConnectionString = "Server=C1;DataBase=329114409_ProductsDB2;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";

        public static ApiContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ApiContext(optionsBuilder.Options);
        }
    }
}
