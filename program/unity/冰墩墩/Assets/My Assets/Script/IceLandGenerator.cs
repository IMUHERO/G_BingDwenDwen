using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLandGenerator : MonoBehaviour
{
    // public GameObject iceLandPrefabe;
    public static IceLandGenerator instance { get; private set; }
    public List<GameObject> lands;
    private float totalDistance;
    private int curIndex;
    private List<int> addSpeedRates;
    private List<int> addGenerateRates;
    private AudioSource audioSource;
    private void Awake() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Restart();
    }

    public void Restart()
    {
        addSpeedRates = new List<int>();
        addGenerateRates = new List<int>();
        for (int i = 0; i < lands.Count; i++)
        {
            GameObject land = lands[i];
            Vector2 position = land.transform.position;
            position.y = -i * Globals.LAND_HIGH;
            land.transform.position = position;
        }
        curIndex = 0;
        totalDistance = 0;
        PlaySound();
    }

    public void PlaySound(bool needPlay = true){
        if(needPlay){
            audioSource.Play();
        }
        else{
            audioSource.Stop();
        }
    }

    public void GameOver(){
        PlaySound(false);
    }

    private void MoveLand()
    {
        if (PlayerController.playerStage != Globals.PLAYER_STAGE_MOVING)
        {
            return;
        }
        float distance = GameManager.instance.GetLandSpeed() * Time.deltaTime;
        totalDistance += distance;
        CheckAddRate();
        Globals.totalDistance += distance;
        if (totalDistance > Globals.LAND_HIGH)
        {
            // Debug.Log("........" + totalDistance);
            totalDistance -= Globals.LAND_HIGH;
            GameObject curLand = lands[curIndex];
            Vector3 position = curLand.transform.position;
            position.y = position.y - Globals.LAND_HIGH * (lands.Count);
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

    private void CheckAddRate()
    {
        if(PlayerController.playerStage != Globals.PLAYER_STAGE_MOVING){
            return;
        }
        if(Globals.isPlayerGo){
            return;
        }
        int addSpeedTimes = (int)(Globals.totalDistance / Globals.DIS_ADD_SPEED);
        int addGenTimes = (int)(Globals.totalDistance / Globals.DIS_ADD_GEN);
        // print(">>>>>>>>>>>>>>>>" + addSpeedTimes + ' ' + addGenTimes);
        if (addSpeedTimes > 0 && !addSpeedRates.Contains(addSpeedTimes))
        {
            addSpeedRates.Add(addSpeedTimes);
            Globals.distanceSpeedRate += Globals.DIS_ADD_SPEED_RATE;
            UIController.instance.showTipText(Globals.TIP_SPEED);
        }
        else if (addGenTimes > 0 && !addGenerateRates.Contains(addGenTimes))
        {
            addGenerateRates.Add(addGenTimes);
            Globals.distanceGenerateRate *= Globals.DIS_ADD_GEN_RATE;
            UIController.instance.showTipText(Globals.TIP_GENERATE);
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
