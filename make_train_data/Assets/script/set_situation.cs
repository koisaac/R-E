using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;

public class set_situation : MonoBehaviour
{


    public List<GameObject> car_makesr_objects;
    public GameObject car_file;

    void Awake()
    {
        string[,] signal_type = FileInStream.Instance.GetFile_SignalType();
        List<situation> situations = FileInStream.Instance.GetFile_situation();


        
    }

    void start_test()
    {
        
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
