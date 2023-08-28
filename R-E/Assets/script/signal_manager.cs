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
        public int hold_time;
        public signal_change_rules(string signal, int hold_time)
        {
            this.signal = signal;
            this.hold_time = hold_time;
        }
    }
    public class linkedList
    {
        public signal_change_rules rule;
        public linkedList next;
        public linkedList(string signal, int hold_time, bool is_first = false)
        {
            signal_change_rules rules = new signal_change_rules(signal, hold_time);
            this.rule = rules;
            if (is_first) this.next = this;
        }
        public linkedList add(signal_change_rules rule)
        {
            linkedList list1 = new linkedList(rule.signal, rule.hold_time);
            list1.next = this.next;
            this.next = list1;
            return list1;
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



                signallight[i].transform.GetChild(j).GetComponent<TrafficSystemTrafficLight>().SetStatus(Status);
            }
        }
    }

    private List<linkedList> rules = new List<linkedList>();
    private List<float> start_time= new List<float>();
    void Start()
    {
        List<List<SignalRules>> signalRules = FileInStream.Instance.GetFile_SignalRules();
        
        for(int i = 0;i < signalRules.Count;i++) {
            rules.Add(new linkedList(signalRules[i][0].signal, signalRules[i][0].hold_time, true));
            start_time.Add(Time.time);
            for(int j = 1;j< signalRules[i].Count; j++)
            {
                rules[i].add(new signal_change_rules(signalRules[i][j].signal, signalRules[i][j].hold_time));
            }


         
            
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < rules.Count; i++)
        {
            if (Time.time-start_time[i] > rules[i].rule.hold_time)
            {
                rules[i] = rules[i].next;
                start_time[i]= Time.time;
            }

            FileOutStream.Instance.setsignal(i, rules[i].rule.signal);
        }
        SetSignal();
    }
}
