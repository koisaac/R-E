using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class set_car : MonoBehaviour
{
    public int number_of_cars;

    // Start is called before the first frame update
    void Start()
    {
        set_car_manager set_Car = set_car_manager.Instance;
        set_Car.SetCar(number_of_cars);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
