using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : ObstacleController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        base.Moving();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            GameObject.Destroy(gameObject);
            if(Globals.collectNum >= Globals.MaxCollectNum){
                return;
            }
            Globals.collectNum += 1;
            UIHealthBar.instance.SetValue(Globals.collectNum / (float)Globals.MaxCollectNum);
            print("collect num: " + Globals.collectNum + " " + Globals.collectNum / (float)Globals.MaxCollectNum);
        }
    }
}
