using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class get_award : MonoBehaviour
{
    public float waitTimer;
    private bool check = false;
    private float time_start;
    public float time = 0;
    private float sum_time = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<TrafficSystemVehicle>().StopMoving)
        {
            if (!check)
            {
                time = 0;
            }
            time += Time.deltaTime;
            check = true;
        }
        else
        {
            if (check)
            {
                sum_time += time;
                check = false;
            }
        }
        waitTimer = time;

    }
}
