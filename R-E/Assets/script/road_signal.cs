using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road_signal : MonoBehaviour
{
    public Material set_material;
    public Material red_signal;
    public Material green_signal;
    public Material yellow_signal;
    public Material left_signal_m;

    string[] Signal =  { "red", "green", "yellow" };

    public string signal = "yellow";//신호등 색깔
    public bool left_signal = false;//좌회전 신호

    public int direction;//자동차 이동 방향 설정

    private string change_signal(string signal_e,bool is_it_change)
    {
        MeshRenderer _signal_ = this.transform.Find("check_road").Find("signal_light").gameObject.transform.Find(signal_e).GetComponent<MeshRenderer>();
        
        if (is_it_change)  //신호에 맞추어 신호등의 신호 변경
        {
            Material change_material;

            switch (signal){
                case "red":
                    change_material = red_signal; break;
                case "green":
                    change_material = green_signal; break;
                case "yellow":
                    change_material = yellow_signal; break;
                default:
                    change_material = null;
                    Debug.Log("erro : change_material=null");
                    break;
            }

            _signal_.material = change_material; //신호 켜기
        }
        else
        {
            _signal_.material = set_material; //신호 끄기
        }
        return signal;
    }
    private string change_left_signal(bool is_it_change)
    {
        MeshRenderer _signal_ = this.transform.Find("check_road").Find("signal_light").gameObject.transform.Find("right_signal").GetComponent<MeshRenderer>();
        if (is_it_change)
        {
            _signal_.material = left_signal_m;   
        }
        else
        {
            _signal_.material = set_material;
        }
        return "chage_left_signal";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            change_signal(Signal[i], Signal[i] == signal);
        }
        change_left_signal(left_signal);
    }
}
