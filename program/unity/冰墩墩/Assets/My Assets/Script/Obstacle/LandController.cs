using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : ObstacleController
{
    private bool inSand = false;
    private bool inIce = false;
    private bool inSnow = false;
    // private float sandDis = 0;
    // private float iceDis = 0;
    // private float snowDis = 0;
    void Start()
    {
        tagName = Globals.LAND_NAME;
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.isPlayerGo){
            return;
        }
        if (inSand)
        {
            SnowBornController.iceBornMoveDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.SAND_SPEED_RATE) * Globals.SNOW_BORN_MOVE_RATE;
        }
        if (inIce){
            SnowBornController.iceBornMoveDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.ICE_SPEED_RATE) * Globals.SNOW_BORN_MOVE_RATE;
        }
        if (inSnow)
        {
            SnowBornController.iceBornMoveDis += Globals.LAND_MOVE_SPEED * Time.deltaTime * (1 - Globals.SNOW_SPEED_RATE) * Globals.SNOW_BORN_MOVE_RATE;
        }
    }

    void FixedUpdate()
    {
        base.Moving();
    }

    private void InSand(bool firstIn = true)
    {
        inSand = true;
        Globals.speedRate = Globals.SAND_SPEED_RATE * Globals.BASE_SPEED_RATE;
        Globals.rotateRate = Globals.SAND_ROTATE_RATE * Globals.BASE_ROTATE_RATE;
    }
    private void InIce(bool firstIn = true)
    {
        inIce = true;
        Globals.speedRate = Globals.ICE_SPEED_RATE * Globals.BASE_SPEED_RATE;
        Globals.rotateRate = Globals.ICE_ROTATE_RATE * Globals.BASE_ROTATE_RATE;
    }
    private void InSnow(bool firstIn = true)
    {
        inSnow = true;
        Globals.speedRate = Globals.SNOW_SPEED_RATE * Globals.BASE_SPEED_RATE;
        Globals.rotateRate = Globals.SNOW_ROTATE_RATE * Globals.BASE_ROTATE_RATE;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(Globals.isPlayerGo){
            return;
        }
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
        if (Globals.isPlayerGo){
            return;
        }
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
        Globals.speedRate = Globals.BASE_SPEED_RATE;
        Globals.rotateRate = Globals.BASE_ROTATE_RATE;
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
        // SnowBornController.iceBornMoveDis += sandDis;
        // sandDis = 0.0f;
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
        // SnowBornController.iceBornMoveDis += iceDis;
        // iceDis = 0.0f;
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
    }
}
