using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static string playerStage;
    public float moveSpeed;
    public float horiSpeed;
    public GameObject winterCar;
    private float MAX_MOVE = 3.0f;
    private float curMove = 0.0f;
    private float horizontal;
    void Start()
    {
        playerStage = "begin";
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        // print(horizontal);
    }

    void FixedUpdate()
    {
        BeginMoving();
        Rotating();
    }

    private void Rotating(){
        if(playerStage != "moving"){
            return;
        }
        Vector2 position = transform.position;
        position.x += horiSpeed * horizontal * Globals.rotateRate * Time.deltaTime;
        transform.position = position;
    }

    private void BeginMoving(){
        if(curMove == -1.0f){
            return;
        }
        if(curMove > MAX_MOVE){
            curMove = -1.0f;
            playerStage = "moving";
            return;
        }
        // Debug.Log("in..." + curMove + ' ' + MAX_MOVE);
        float distance = moveSpeed * Time.deltaTime;
        Vector3 position = transform.position;
        position.y -= distance;
        transform.position = position;
        curMove += distance;
    }
}
