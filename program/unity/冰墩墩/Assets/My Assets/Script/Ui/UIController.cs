using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreUI;
    private float onSecondCd = 0;
    private string scoreSuffix = "Distance";
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = scoreSuffix + '：' + (int)Globals.totalDistance + 'M';
        // onSecondCd += Time.deltaTime;
        // if(onSecondCd > 0.5){
        //     onSecondCd -= 0.5f;
        //     doOneSecond();
        // }

    }

    // private void doOneSecond(){
    // }
    public void onRank(){
        print("尚未完成.....");
    }

    public void onRestart(){
        print(">>>> onRestart");
    }
}
