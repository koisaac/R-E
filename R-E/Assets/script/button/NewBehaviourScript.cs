using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    public void click()
    {
        string s = File.ReadAllText("Assets\\text\\light_signal.json");//파일 읽기
        JObject j = JObject.Parse(s);
        j["signal"]["0"] = name;

        var sw = new StreamWriter("Assets\\text\\light_signal.json");
        sw.WriteLine(j.ToString());
        sw.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
