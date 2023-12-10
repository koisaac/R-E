using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class get_award : MonoBehaviour
{
    public float waitTimer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer = gameObject.GetComponent<TrafficSystemVehicle>().m_waitTimer;

    }
}
