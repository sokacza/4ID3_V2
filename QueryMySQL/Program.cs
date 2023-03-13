using MySql.Data;
using MySql.Data.MySqlClient;

public class Program{

    public void ReadDB(){
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=localhost;uid=root;" +
            "pwd=9055259140;database=GroupA";

        try
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            var query = "SELECT * FROM `DeviceA`";
            var cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                if(reader.GetString(2) == "Potentiometer"){
                    Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), 
                    reader.GetString(2), reader.GetString(0));
                
                }

            }
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public void InsertIntoDB(){
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=localhost;uid=root;" +
            "pwd=9055259140;database=GroupA";

        try
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            var query = "INSERT INTO `DeviceA` (`id`, `Time`, `Sensor`, `Value`) VALUES ('721', 'test', 'test', 'test');";
            var cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                Console.WriteLine(reader);

            }
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public static void Main(string[] args){
        Program p = new Program();
        //p.ReadDB();
        p.InsertIntoDB();

    }
    
}