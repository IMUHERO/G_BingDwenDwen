using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigController : ObstacleController
{
    void Start()
    {
        tagName = Globals.BIG_NAME;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        base.Moving();
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Player"){
            print("in big........." + GetComponent<BoxCollider2D>().isTrigger);
            if(Globals.isPlayerGo){
                return;
            }
            // PlayerController controller = other.GetComponent<PlayerController>();
            GameManager.instance.GameOver();
            print("播放玩家摔倒动画");
            print("GAME OVER: " + PlayerController.playerStage);
        }
    }
}
