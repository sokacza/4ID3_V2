using Google.Cloud.Firestore;

public partial class Program {

async Task ReadCollection(CollectionReference q){
    QuerySnapshot snapshot = await q.GetSnapshotAsync();
    foreach(DocumentSnapshot doc in snapshot){
        Dictionary<string, object> dict = doc.ToDictionary();
        Console.WriteLine(doc.Id+ " { ");
        foreach (KeyValuePair<string, object> d in dict){
            Console.WriteLine("     " + d.Key + ": " + d.Value);
        }
        Console.WriteLine(" }, ");
    }
}
  
async Task AddToCollection(CollectionReference q, Dictionary<string, object> d){
    await q.AddAsync(d);
}


    public static async Task Main(string[] args){
        string path = AppDomain.CurrentDomain.BaseDirectory + @"test-67d8c-firebase-adminsdk-ylbeq-e84123180f.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        FirestoreDb db = FirestoreDb.Create("test-67d8c");
        CollectionReference collection = db.Collection("DeviceA");
        
        
        Program p = new Program();
        //await p.parseDB();
        await p.ReadCollection(collection);
        Dictionary<string, object> data = new Dictionary<string, object>(){{"Temperature", 90}, {"Humidity", 200}};
        await p.AddToCollection(collection, data);
        Console.WriteLine("\n\n");
        await p.ReadCollection(collection);
        Console.WriteLine("Hello, World!");
        
    }

    
}