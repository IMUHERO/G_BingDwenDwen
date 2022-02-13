using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIController instance { get; private set; }
    public Text scoreUI;
    public Text tipUI;
    public GameObject resultUI;
    // private float onSecondCd = 0;
    private string scoreSuffix = "Distance";
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        tipUI.gameObject.SetActive(false);
        resultUI.SetActive(false);
        UIHealthBar.instance.Restart();
        setScoreText(0);
    }

    public void showTipText(string tip)
    {
        tipUI.gameObject.SetActive(true);
        tipUI.text = tip;
        Invoke("waitDestoryTip", Globals.TIP_SHOW_TIME);
    }
    void waitDestoryTip()
    {
        tipUI.gameObject.SetActive(false);
    }

    private void setScoreText(float M)
    {
        scoreUI.text = scoreSuffix + '：' + (int)M + 'M';
    }

    // Update is called once per frame
    void Update()
    {
        setScoreText(Globals.totalDistance);
        // onSecondCd += Time.deltaTime;
        // if(onSecondCd > 0.5){
        //     onSecondCd -= 0.5f;
        //     doOneSecond();
        // }
        if (PlayerController.playerStage == "over")
        {
            resultUI.SetActive(true);
        }

    }

    // private void doOneSecond(){
    // }
    public void onRank()
    {
        print("尚未完成.....");
    }

    public void onRestart()
    {
        print(">>>> onRestart");
        GameManager.instance.GameRestart();
    }

    public void onLeft()
    {

    }

    public void onRight()
    {

    }
}
