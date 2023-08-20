/*
    Software Responsibility (SR) : &BlightStds
    Software Latest Editor (SLE) : WDWIZ from Blight Stdudios
    Software Administrator (SA) : WDWIZ
    Software Copyright Owner (SCO) : copyright (c) 2023 WDWIZ
    Software Version (SV) : alpha 0.2, released on May 10th, 2023
    Software Project Information (SPI) : Project "TopDown#1" (Version alpha 0.1), by WDWIZ

    Final Approval
        2023 Jun 18 WDIWZ
*/

using System;
using System.IO;
using Newtonsoft.Json.Linq;

class FileManager{
    private string filePath = "";
    private string json = "";
    public JObject JSON = JObject.Parse("{}");
    private int AccessCount = 0;

    private struct Access{
        public int id;
        public string[] address;
        public JSONManager jsonManager;
    }

    private List<Access> AccessList = new List<Access>();

    public FileManager(string _path, bool init = false){
        if (_path == null){
            throw new ArgumentException($"ERROR\nYou cannot call a file Path : \"null\"");
        }

        filePath = _path;
        json = File.ReadAllText(filePath);
        JSON = JObject.Parse(json);

        if (init){
            JSON = JObject.Parse("{}");
            ApplyToFile();
        }
    }

    public void ApplyToFile(){
        json = JSON.ToString();
        File.WriteAllText(filePath, json);
    }

    public JSONManager newAccess(string[] address){
        Access access;

        if (address is null) throw new ArgumentException($"ERROR\nAddress is null\nAdvice : []");
        access.id = AccessCount++;
        access.address = address;
        access.jsonManager = new JSONManager(access.id, address, JTokenToString(AddressTracker(address)), ref JSON);

        AccessList.Add(access);

        return access.jsonManager;
    }

    private JToken AddressTracker(string[] keys){
        JToken token = JSON;

        foreach (string key in keys){
            if (token is JObject obj && obj.ContainsKey(key) && token is not null) token = obj[key];
            else throw new ArgumentException($"Key '{key}' not found.");
        }

        return token;
    }

    private string JTokenToString(JToken _token){
        return _token.ToString();
    }
}

class JSONManager{
    private int AccessId = 0;
    private string[] FAddress;
    private JObject FullJSON = JObject.Parse("{}");
    private JObject JSON = JObject.Parse("{}");
    private string json = "";

    public JSONManager(int _id, string[] fAdrress, string _json, ref JObject fullJSON){
        AccessId = _id;
        FAddress = fAdrress;
        json = _json;
        JSON = JObject.Parse(json);
        FullJSON = fullJSON;
    }

    public void editData(string[] _address, dynamic data){
        Stack<String> address = new Stack<string>();
        for (int i = 0; i < _address.Length - 1; i++) address.Push(_address[i]);

        JObject _json = AddressTracker(ref FullJSON, address) as JObject;

        if (_address.Length > 0) _json[_address[_address.Length - 1]] = data;
    }

    public void addData(string[] _address, string key, dynamic data){
        Stack<String> address = new Stack<string>();
        for (int i = 0; i < _address.Length - 1; i++) address.Push(_address[i]);

        JObject _json = AddressTracker(ref FullJSON, address) as JObject;

        _json.Add(new JProperty(key, data));
    }

    private JToken AddressTracker(ref JObject _JSON, Stack<String> keys){
        JToken token = _JSON;

        foreach (string key in FAddress.Concat(keys).ToArray()){
            if (token is JObject obj && obj.ContainsKey(key) && token is not null) token = obj[key];
            else throw new ArgumentException($"Key '{key}' not found.");
        }

        return token;
    }
}