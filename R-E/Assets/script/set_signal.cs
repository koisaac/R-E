using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_signal : MonoBehaviour
{
    public string signal = "yellow";//신호등 색깔
    public bool left_signal = false;//좌회전 신호
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
