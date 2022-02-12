using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : ObstacleController
{
    private bool inSand = false;
    private bool inIce = false;
    private bool inSnow = false;
    private float sandDis = 0;
    private float iceDis = 0;
    private float snowDis = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inSand)
        {
            sandDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.SAND_SPEED_RATE);
        }
        if (inIce){
            iceDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.SAND_SPEED_RATE);
        }
        if (inSnow)
        {
            snowDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.SAND_SPEED_RATE);
        }
    }

    void FixedUpdate()
    {
        base.Moving();
    }

    private void InSand(bool firstIn = true)
    {
        inSand = true;
        Globals.speedRate = Globals.SAND_SPEED_RATE;
        Globals.rotateRate = Globals.SAND_ROTATE_RATE;
    }
    private void InIce(bool firstIn = true)
    {
        inIce = true;
        Globals.speedRate = Globals.ICE_SPEED_RATE;
        Globals.rotateRate = Globals.ICE_ROTATE_RATE;
    }
    private void InSnow(bool firstIn = true)
    {
        inSnow = true;
        Globals.speedRate = Globals.SNOW_SPEED_RATE;
        Globals.rotateRate = Globals.SNOW_ROTATE_RATE;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "sand")
            {
                InSand();
            }
            else if (gameObject.tag == "ice")
            {
                InIce();
            }
            else if (gameObject.tag == "snow")
            {
                InSnow();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (gameObject.tag == "sand")
            {
                ExitSand();
            }
            else if (gameObject.tag == "ice")
            {
                ExitIce();
            }
            else if (gameObject.tag == "snow")
            {
                ExitSnow();
            }
        }

    }


    private void ResetRate()
    {
        Globals.speedRate = 1;
        Globals.rotateRate = 1;
    }
    private void ExitSand()
    {
        if (inSnow)
        {
            InSnow(false);
        }
        else if (inIce)
        {
            InIce(false);
        }
        else
        {
            ResetRate();
        }
        inSand = false;
        IceBornController.iceBornMoveDis += sandDis;
        sandDis = 0.0f;
    }
    private void ExitIce()
    {
        if (inSand)
        {
            InSand(false);
        }
        else if (inSnow)
        {
            InSnow(false);
        }
        else
        {
            ResetRate();
        }
        inIce = false;
        IceBornController.iceBornMoveDis += iceDis;
        iceDis = 0.0f;
    }
    private void ExitSnow()
    {
        if (inSand)
        {
            InSand(false);
        }
        else if (inIce)
        {
            InIce(false);
        }
        else
        {
            ResetRate();
        }
        inSnow = false;
        IceBornController.iceBornMoveDis += snowDis;
        snowDis = 0.0f;
    }
}
