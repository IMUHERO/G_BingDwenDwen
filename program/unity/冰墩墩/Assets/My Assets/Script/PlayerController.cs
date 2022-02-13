using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance { get; private set; }
    public static string playerStage;
    public float moveSpeed;
    public GameObject winterCar;
    private float MAX_MOVE = 3.0f;
    private float curMove = 0.0f;
    private float horizontal;
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
        instance = this;
    }
    void Start()
    {
        // Restart();
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

    public void Restart()
    {
        transform.position = Vector3.zero;
        curMove = 0;
        playerStage = Globals.PLAYER_STAGE_BEGIN;
        animator.SetTrigger(Globals.PLAYER_ANI_BEGIN);
    }

    private void Rotating()
    {
        if (playerStage != Globals.PLAYER_STAGE_MOVING)
        {
            return;
        }
        Vector2 position = transform.position;
        float trueHori = horizontal;
        if (Mathf.Abs(horizontal) < 0.0001f)
        {
            trueHori = Globals.horizontal;
        }
        else
        {
            Globals.horizontal = 0;
        }
        float dis = trueHori * Globals.rotateRate * Time.deltaTime;
        // print("........" + trueHori);
        PlayerController.instance.animator.SetFloat(Globals.PLAYER_MOVE_HORI, trueHori);
        position.x += dis;
        transform.position = position;
    }

    private void BeginMoving()
    {
        if (curMove == -1.0f)
        {
            return;
        }
        if (curMove > MAX_MOVE)
        {
            curMove = -1.0f;
            playerStage = Globals.PLAYER_STAGE_MOVING;
            animator.SetTrigger(Globals.PLAYER_MOVE_TRIGGER);
            return;
        }
        // Debug.Log("in..." + curMove + ' ' + MAX_MOVE);
        float distance = moveSpeed * Time.deltaTime;
        Vector3 position = transform.position;
        position.y -= distance;
        transform.position = position;
        curMove += distance;
    }

    public void GameOver(){
        PlayerController.playerStage = Globals.PLAYER_STAGE_OVER;
        animator.SetTrigger(Globals.PLAYER_ANI_OVER);
    }
}
