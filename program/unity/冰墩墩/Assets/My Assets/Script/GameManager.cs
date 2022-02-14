using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance { get; private set; }
    public GameObject snowBorn;
    private AudioSource audioSource;
    // 'snowBorn', 'small', 'big', 'land'
    public static Dictionary<string, List<GameObject>> gameObjects;

    private float playerGoCd = 0;

    private void Awake()
    {
        instance = this;
        gameObjects = new Dictionary<string, List<GameObject>>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // GameRestart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.isPlayerGo)
        {
            playerGoCd += Time.deltaTime;
            if (playerGoCd >= 5)
            {
                playerGoCd = 0;
                GameManager.instance.OnGo(false);
            }
        }
    }
    public void OnCanGo(bool canGo)
    {
        Globals.canGo = canGo;
        UIController.instance.onCanGo(canGo);
    }
    public void OnGo(bool isGo)
    {
        if (isGo)
        {
            Globals.speedRate = Globals.BASE_SPEED_RATE;
            Globals.canGo = false;
            Globals.collectNum = 0;
            SnowBornController.iceBornMoveDis -= 1;
        }
        Globals.isPlayerGo = isGo;
        UIController.instance.OnGo(isGo);
        PlayerController.instance.OnGo(isGo);
        CheckObTrigger();
    }

    private void CheckObTrigger(string obKey= "", GameObject ob = null)
    {
        if (obKey != "" && ob != null)
        {
            if(obKey == Globals.SMALL_NAME || obKey == Globals.BIG_NAME){
                ob.GetComponent<BoxCollider2D>().isTrigger = Globals.isPlayerGo;
            }
            return;
        }
        foreach (var gob in gameObjects)
        {
            string key = gob.Key;
            // print("11111111" + key + ": " + gob.Value);
            if (key != Globals.SMALL_NAME && key != Globals.BIG_NAME)
            {
                continue;
            }
            List<GameObject> objects = gob.Value;
            // print("22222222" + objects);
            foreach (GameObject item in objects)
            {
                print("33333333" + item);
                if (item != null)
                {
                    item.GetComponent<BoxCollider2D>().isTrigger = Globals.isPlayerGo;
                }
            }
            print("innnnnnnnnnnnnnnnnnnnn: " + gob);
        }
    }

    public float GetObstacleSpeed()
    {
        return getSpeed();
    }

    public float GetLandSpeed()
    {
        return getSpeed();
    }

    public float getSpeed()
    {
        if (Globals.isPlayerGo)
        {
            return Globals.PLAYER_GO_SPEED;
        }
        return Globals.LAND_MOVE_SPEED * Globals.speedRate * Globals.distanceSpeedRate;

    }

    public void addObject(string keyName, GameObject ob)
    {
        if (GameManager.gameObjects.ContainsKey(keyName))
        {
            GameManager.gameObjects[keyName].Add(ob);
        }
        else
        {
            GameManager.gameObjects[keyName] = new List<GameObject> { ob };
        }
        CheckObTrigger(keyName, ob);
    }

    public void removeObject(string keyName, GameObject ob)
    {
        if (GameManager.gameObjects.ContainsKey(keyName))
        {
            GameManager.gameObjects[keyName].Remove(ob);
        }
    }

    public void GameOver()
    {
        PlayerController.instance.GameOver();
        IceLandGenerator.instance.GameOver();
        audioSource.Stop();

    }
    public void GameRestart()
    {
        // destory
        foreach (var gob in gameObjects)
        {
            string key = gob.Key;
            List<GameObject> objects = gob.Value;
            foreach (GameObject item in objects)
            {
                if (item != null)
                {
                    Destroy(item);
                }
            }
        }
        // reset
        gameObjects = new Dictionary<string, List<GameObject>>();
        // generate
        GameObject snowB = Instantiate(snowBorn, Vector3.zero, Quaternion.identity);
        SnowBornController snowBornController = snowB.GetComponent<SnowBornController>();
        snowBornController.Restart();
        List<GameObject> snows = new List<GameObject> { snowB };
        gameObjects.Add(Globals.SNOW_BORN_NAME, snows);
        // restart
        Globals.Restart();
        IceLandGenerator.instance.Restart();
        UIController.instance.Restart();
        PlayerController.instance.Restart();

        audioSource.Play();

    }
}
