using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class set_road_manager : MonoBehaviour
{
    public GameObject ground;
    public int roads_number;
    private List<GameObject> road = new List<GameObject>();


    public List<GameObject> roads
    {
        get
        {
            return road;
        }
    }


    //教臂沛 备泅
    private static set_road_manager manager = null;
    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            manager.set_road();
        }
        else if (manager != this)
        {
            Debug.Log("destroy");
            Destroy(this);
        }
    }
    public static set_road_manager Instance
    {
        get
        {
            if (manager == null)
            {
                return null;
            }
            return manager;
        }
    }
    //教臂沛 备泅

    public void set_road()
    {
            Debug.Log(roads_number);
            for (int i = 0; i < roads_number; i++)
            {
            Debug.Log(ground.transform.GetChild(i).gameObject);
            this.road.Add(ground.transform.GetChild(i).gameObject) ;
            Debug.Log(road[i].name);
            }
    }

}
