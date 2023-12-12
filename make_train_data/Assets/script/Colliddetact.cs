using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliddetact : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsCrashed=false;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IsCrashed = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsCrashed);
    }
}
