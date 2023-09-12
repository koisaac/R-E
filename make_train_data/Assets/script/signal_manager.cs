using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;

public class signal_manager : MonoBehaviour
{
    // Start is called before the first frame update


    public class signal_change_rules
    {
        public string signal;
        public bool is_turn_left;
        public int hold_time;
        public signal_change_rules(string signal, bool is_turn_left ,int hold_time)
        {
            this.signal = signal;
            this.is_turn_left= is_turn_left;
            this.hold_time = hold_time;
        }
    }
    

    public List<GameObject> signallight;

    const int number_of_traffic_lights_per_intersection = 4;


    private List<SignalData> getSignalData()
    {
        return FileInStream.Instance.GetFile_SignalData();
    }





    public void SetSignal()
    {
        List<SignalData> signals = getSignalData();
        for(int i=0;i<signallight.Count;i++)
        {
            for(int j = 0; j < number_of_traffic_lights_per_intersection; j++)
            {
                TrafficSystemTrafficLight.Status Status= TrafficSystemTrafficLight.Status.GREEN;
                switch (signals[i*4 + j].signal) {
                    case "green":
                        Status = TrafficSystemTrafficLight.Status.GREEN;
                        break;
                    case "yellow":
                        Status = TrafficSystemTrafficLight.Status.YELLOW; 
                        break;
                    case "red":
                        Status = TrafficSystemTrafficLight.Status.RED;
                       break;
                    default:
                        Status = TrafficSystemTrafficLight.Status.RED;
                        break;
                }
                
                signallight[i].transform.GetChild(j).GetComponent<TrafficSystemTrafficLight>().SetStatus(Status, signals[i * 4 + j].is_turn_left);
            }
        }
    }
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        
        SetSignal();
    }
}
