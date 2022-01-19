using MySql.Data.MySqlClient;

using MySql.Data.MySqlClient;

namespace DAL
{



    public sealed class DataBaseConnection
    {


        public MySqlConnection connection { get; }
        private static readonly object _lock = new object();
        private static DataBaseConnection instance = null;

        DataBaseConnection()
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=root;database=banksystem";
                using var con = new MySqlConnection(cs);
                this.connection = con;

            }
            catch (MySqlException ex) { throw ex; }
            openConnection();   
        }
        public static DataBaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new DataBaseConnection();
                        }
                    }
                }
                return instance;
            }
        }

        private void openConnection()
        {
            try
            {
                this.connection.Open();
            }
            catch (Exception ex) { throw ex; }
        }


     
    }

}

