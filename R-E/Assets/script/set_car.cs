using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_car : MonoBehaviour
{
    public List<GameObject> start_point;
    public GameObject car;
    public int number_of_cars;
    public List<GameObject> cars;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<number_of_cars;i++) {
            cars.Add(Instantiate(car));
            cars[i].transform.position = start_point[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
