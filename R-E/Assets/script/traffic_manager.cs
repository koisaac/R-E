using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class traffic_manager : MonoBehaviour
{
    //ΩÃ±€≈Ê
    private static traffic_manager Traffic_manager = null;
    void Awake()
    {
        if (Traffic_manager == null)
        {
            Traffic_manager = this;
        }
        else if (Traffic_manager != this)
        {
            Destroy(this);
        }
    }
    public static traffic_manager Instance
    {
        get
        {
            if (Traffic_manager == null)
            {
                return null;
            }
            return Traffic_manager;
        }
    }
    //ΩÃ±€≈Ê


    private 






    // Start is called before the first frame update
    filestream f;
    void Start()
    {
        f = filestream.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
