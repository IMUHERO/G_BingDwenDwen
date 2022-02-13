using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIController instance { get; private set; }
    public Text scoreUI;
    public Text tipSpeedUI;
    public Text tipGenUI;
    public Text resultText;
    public GameObject XueRongRong;
    public GameObject resultUI;
    // private float onSecondCd = 0;
    private string scoreSuffix = "Distance";
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        // Restart();
    }

    public void Restart()
    {
        XueRongRong.SetActive(false);
        tipSpeedUI.gameObject.SetActive(false);
        tipGenUI.gameObject.SetActive(false);
        resultUI.SetActive(false);
        UIHealthBar.instance.Restart();
        setScoreText(0);
    }

    public void showTipText(string tip)
    {
        print("show tips ....." + tip);
        if(tip == Globals.TIP_SPEED){
            tipSpeedUI.gameObject.SetActive(true);
            tipSpeedUI.text = tip;
            Invoke("waitDestorySpeedTip", Globals.TIP_SHOW_TIME);
        }
        if(tip == Globals.TIP_GENERATE){
            tipGenUI.gameObject.SetActive(true);
            tipGenUI.text = tip;
            Invoke("waitDestoryGenTip", Globals.TIP_SHOW_TIME);
        }
    }
    void waitDestorySpeedTip()
    {
        tipSpeedUI.gameObject.SetActive(false);
    }
    void waitDestoryGenTip()
    {
        tipGenUI.gameObject.SetActive(false);
    }

    public void showXueRongRong(){
        XueRongRong.SetActive(true);
        Invoke("waitDestoryXRR", Globals.XRR_SHOW_TIME);
    }

    void waitDestoryXRR()
    {
        XueRongRong.SetActive(false);
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
        if (PlayerController.playerStage == Globals.PLAYER_STAGE_OVER)
        {
            resultUI.SetActive(true);
            resultText.text = scoreUI.text;
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
