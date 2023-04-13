using System;
using Newtonsoft.Json.Linq;

public class File {
    public string newFile(string fileName, string[] keys) {
        // Implementation for creating a new file
        return ""; // Return file ID
    }

    public void editFile(string fileId, string[] keys, JToken value) {
        // Implementation for editing an existing file
    }
}

public class App {
    private File FILE = new File();

    public string id { get; private set; }
    public string jsonLocation { get; private set; }

    public App(string file, string[] keys = null) {
        this.id = FILE.newFile(file, keys);
        this.jsonLocation = file;
    }

    public void editFile(string[] keys = null, JToken value = null) {
        FILE.editFile(this.id, keys, value);
    }
}

class Program {
    static void Main(string[] args) {
        string file = "../DATA/traffic.json";
        App app = new App(file, new string[] { "traffics", "at_road1" });
        app.editFile(new string[] { "CurrentState" }, "red");
    }
}
