using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : ObstacleController
{
    public AudioClip addNumClip;
    // Start is called before the first frame update
    void Start()
    {
        tagName = Globals.LANTERN_NAME;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        base.Moving();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerController.instance.PlaySound(addNumClip, 0.8f);
            GameObject.Destroy(gameObject);
            if(Globals.canGo){
                UIController.instance.showXueRongRong();
                return;
            }
            Globals.collectNum += 1;
            if(Globals.collectNum >= Globals.MaxCollectNum){
                GameManager.instance.OnCanGo(true);
            }
            UIController.instance.showXueRongRong();
            float value = Globals.collectNum / (float)Globals.MaxCollectNum;
            UIHealthBar.instance.SetValue(value);
            print("collect num: " + Globals.collectNum + " " + Globals.collectNum / (float)Globals.MaxCollectNum);
        }
    }
}
