using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallController : ObstacleController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        base.Moving();
    }
}
