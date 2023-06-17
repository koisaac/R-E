using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAKE : MonoBehaviour
{




    public GameObject pre;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class make_o: MonoBehaviour
{
    int range;
    float splite_size;
    GameObject pre;
    public make_o(int range, float splite_size,GameObject pre)
    {
        this.range = range;
        this.splite_size = splite_size;
        this.pre = pre;
    }

   public void make(Func<float, float, float, float> a)
    {
        GameObject b;
        for (float i = 0; i < range; i = i + splite_size) 
        {
            for(float k=0;k< range; k=k+splite_size) {
            
                for(float j=0;j<range;j=j+splite_size)
                {
                    if (a(i, k, j) >= 90)
                    {
                        b = Instantiate(pre);
                        b.transform.position = new Vector3(i, 50 + (float)Math.Sin(i) * 10, 0);

                    }
                }
            }
        }
    }
}