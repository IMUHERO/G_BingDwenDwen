using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBornController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float iceBornMoveDis = 0.0f;
    // private bool isBeginMove = false;
    private Animator animator;
    // private float curBeginDis = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayAni("begin");
    }

    // Update is called once per frame
    void Update()
    {
        // if (iceBornMoveDis > 0)
        // {
        //     Move(Globals.ICE_BORN_MOVE_SPEED);
        // }
        // else if(iceBornMoveDis < 0)
        // {
        //     Move(-Globals.ICE_BORN_MOVE_SPEED);
        // }
        // if(PlayerController.playerStage != "moving"){
        //     return;
        // }
        TestMove();
    }

    public void PlayAni(string name){
        animator.SetTrigger(name);
    }

    private void TestMove(){
        Vector2 position = transform.position;
        position.y -= 2 * Time.deltaTime;
        transform.position = position;
    }

    private void Move(float speed)
    {
        Vector2 position = transform.position;
        float dis = speed * Time.deltaTime;
        // float dis = Mathf.Clamp(oriDis, 0, iceBornMoveDis);
        position.y -= dis;
        iceBornMoveDis -= dis;
        print("move: " + ' ' + transform.position.y + ' ' + iceBornMoveDis + ' ' + dis);
        transform.position = position;
    }

    private void MoveBack(float speed)
    {
        Vector2 position = transform.position;
        float dis = speed * Time.deltaTime;
        position.y += dis;
        print("moveBack: " + ' ' + transform.position.y + ' ' + iceBornMoveDis + ' ' + dis);
        iceBornMoveDis += dis;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // PlayerController controller = other.GetComponent<PlayerController>();
            PlayerController.playerStage = "over";
            print("播放玩家摔倒动画");
            print("GAME OVER" + PlayerController.playerStage);
            iceBornMoveDis = 15;
        }
    }

    public void Restart(){

    }
}
