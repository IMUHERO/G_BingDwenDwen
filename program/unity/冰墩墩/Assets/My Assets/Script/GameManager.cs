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

    private void Awake()
    {
        instance = this;
        gameObjects = new Dictionary<string, List<GameObject>>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameRestart();
    }

    // Update is called once per frame
    void Update()
    {

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
