namespace proj0.DAL
{
    public class DAL_HELP
    {
        public static string constr = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
    }
}
