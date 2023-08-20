using System;
using System.IO;
using FileManager;
using Newtonsoft.Json.Linq;

class App(){
    private struct Data{
        JSONManager access;
        int id;
    }

    static void Main(strineg[] __dir__,string[] __path__){
        FileManager fileManager = new FileManager(__dir__ + __path__, true);

        List<Data> list = new List<Data>();

        int listCount = 0;
    }

    static int addData(string key){
        Data dt = new Data();
        WholeFile.addData(new string[] {}, key, JObject.Parse("{}"));
        dt.access = fileManager.newAccess(new string[] {key});
        list.Add(dt);

        id++;

        fileManager.ApplyToFile();

        return id;
    }

    static void editData(int id, string[] keys, dynamic data){
        list[id].editData(keys, data);

        fileManager.ApplyToFile();
    }
}

class File(){
    static void Main(){
        const string __dir__ = dir;
        const string path = _path;
        
        FileManager fileManager = new FileManager(__dir__ + path, true);
        JSONManager WholeFile = fileManager.newAccess(new string[] {});

        WholeFile.addData(new string[] {}, "traffics", JObject.Parse("{}"));
        
        JSONManager traffics = fileManager.newAccess(new string[] {"traffics"});

        traffics.addData(new string[] {}, "at_road1", JObject.Parse(@"{CurrentState : ""red"", InChanging : 0}"));

        fileManager.ApplyToFile();
    }
}