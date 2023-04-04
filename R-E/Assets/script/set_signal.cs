using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_signal : MonoBehaviour
{
    public string signal = "yellow";
    public bool right_signal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(signal);
    }
}
