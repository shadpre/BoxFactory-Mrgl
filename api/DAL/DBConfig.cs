using System.Runtime.CompilerServices;

namespace BoxFactory_Mrgl.DAL
{
    public class DBConfig
    {
        private static DBConfig instance;
        public string ConnectionString { get; }

        private DBConfig()
        {
            ConnectionString = GetConfiguration().GetConnectionString("myDb1");
        }

        private static void Init()
        {           
                instance = new DBConfig();            
        }

        public static DBConfig GetInstance()
        {
            if (instance == null)  Init();
            return instance;
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
