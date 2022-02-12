using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLandGenerator : MonoBehaviour
{
    // public GameObject iceLandPrefabe;
    public List<GameObject> lands;
    private float totalDistance;
    private int curIndex;
    public static int LAND_HIGH = 15;
    public static int LAND_WIDTH = 16;
    // Start is called before the first frame update
    void Start()
    {
        curIndex = 0;
    }

    private void MoveLand()
    {
        if(PlayerController.playerStage != "moving"){
            return;
        }
        float distance = Globals.LAND_MOVE_SPEED * Time.deltaTime * Globals.speedRate;
        totalDistance += distance;
        Globals.totalDistance += distance;
        if(totalDistance > LAND_HIGH){
            // Debug.Log("........" + totalDistance);
            totalDistance -= LAND_HIGH;
            GameObject curLand = lands[curIndex];
            Vector3 position = curLand.transform.position;
            position.y = position.y - LAND_HIGH * (lands.Count);
            curLand.transform.position = position;
            curIndex = (curIndex + 1) % lands.Count;
        }
        foreach (GameObject land in lands)
        {
            Vector3 position = land.transform.position;
            position.y += distance;
            land.transform.position = position;
            // Debug.Log("........" + transform.position.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        MoveLand();
    
    }
}
