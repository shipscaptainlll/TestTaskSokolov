using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingInitializator : MonoBehaviour
{
    [SerializeField] Transform startCarExample;
    Transform startCar;

    public event Action<Transform> carInstantiated = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        startCar = Instantiate(startCarExample);
        carInstantiated(startCar);
        //startCar.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
