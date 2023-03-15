using MongoDB.Driver;
using MongoDB.Bson;

class Program{

    public class Model{
        public ObjectDisposedException Id {get; set;}
        public double Temperature {get; set;}
        public double Humidity {get; set; }
    }

    public void ListDatabases(){
        MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

        var dbList = dbClient.ListDatabases().ToList();

        Console.WriteLine("The list of databases on this server is: ");

        foreach (var db in dbList)
        {
            Console.WriteLine(db);
        }

    }

    public void ReadDB(){
        var connectionString = "mongodb://localhost:27017";
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
            Environment.Exit(0);
        }
        var client = new MongoClient(connectionString);
        var collection = client.GetDatabase("GroupA").GetCollection<BsonDocument>("DeviceA");
        var document = new Dictionary<string, object>();
        //var filter = Builders<BsonDocument>.Filter.Eq("Temperature", "Humidity");
        //var document = collection.Find(filter).First();
        Console.WriteLine(collection.to_dict());
    }

    public static void Main(string[] args){
        Program p = new Program();
        p.ReadDB();
        Console.WriteLine("HelloWorld");
    }

}

