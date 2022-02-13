using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public ObstacleGenerator instance { get; private set; }
    public List<GameObject> smalls;
    public List<GameObject> bigs;
    public GameObject lanterns;
    public List<GameObject> lands;
    public GameObject player;
    // 主角下方多远距离生成物体
    public const int GEN_HEIGHT = 15;
    public const int MAX_GEN_HEIGHT = 35;
    private float smallcd = 0.0f;
    public const int SMALL_CD = 2;
    private float bigcd = 0.0f;
    public const int BIG_CD = 2;
    private float landcd = 0.0f;
    public const int LAND_CD = 3;
    private float lanterncd = 0.0f;
    public const int LANTERN_CD = 3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.playerStage != "moving")
        {
            return;
        }
        genSmall();
        genBig();
        genlantern();
        genLand();
    }

    private Vector2 getRandomPos()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 xRange = new Vector2(-Globals.LAND_WIDTH / 2.0f, Globals.LAND_WIDTH / 2.0f);
        Vector2 yRange = new Vector2(playerPos.y - GEN_HEIGHT, playerPos.y - MAX_GEN_HEIGHT);
        float x = Random.Range(xRange.x, xRange.y);
        float y = Random.Range(yRange.x, yRange.y);
        return new Vector2(x, y);
    }

    private GameObject genObject(string obName, GameObject ob)
    {
        GameObject newOb = Instantiate(ob, getRandomPos(), Quaternion.identity);
        GameManager.instance.addObject(obName, newOb);
        return newOb;
    }

    private void genSmall()
    {
        smallcd += Time.deltaTime;
        if (smallcd < SMALL_CD)
        {
            return;
        }
        smallcd = 0;
        int index = Random.Range(0, smalls.Count - 1);
        GameObject ob = genObject(Globals.SMALL_NAME, smalls[index]);
    }

    private void genBig()
    {
        bigcd += Time.deltaTime;
        if (bigcd < BIG_CD)
        {
            return;
        }
        bigcd = 0;
        int index = Random.Range(0, bigs.Count - 1);
        GameObject ob = genObject(Globals.BIG_NAME, bigs[index]);
    }


    private void genlantern()
    {
        lanterncd += Time.deltaTime;
        if (lanterncd < LANTERN_CD)
        {
            return;
        }
        lanterncd = 0;
        GameObject ob = genObject(Globals.LAND_NAME, lanterns);

    }

    private void genLand()
    {
        landcd += Time.deltaTime;
        if (landcd < LAND_CD)
        {
            return;
        }
        landcd = 0;
        int index = Random.Range(0, lands.Count - 1);
        GameObject ob = genObject(Globals.LAND_NAME, lands[index]);
    }
}
