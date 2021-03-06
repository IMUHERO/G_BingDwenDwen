using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance { get; private set; }
    public static string playerStage;
    public float moveSpeed;
    // public GameObject winterCar;
    private float MAX_MOVE = 3.0f;
    private float curMove = 0.0f;
    private float horizontal;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip skiClip;
    public AudioClip FailueClip;
	public GameObject partical;
    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>() ;
        instance = this;
    }
    void Start()
    {
        // Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if(! Globals.gameStart){
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        // print(horizontal);
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(!Globals.canGo){
                return;
            }
            GameManager.instance.OnGo(true);
        }
    }

    void FixedUpdate()
    {
        if(! Globals.gameStart){
            return;
        }
        BeginMoving();
        Rotating();
    }

    public void Restart()
    {
        transform.position = Vector3.zero;
        curMove = 0;
        playerStage = Globals.PLAYER_STAGE_BEGIN;
        animator.SetTrigger(Globals.PLAYER_ANI_BEGIN);
        PlaySound(skiClip, 0.4f);
        partical.SetActive(false);
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f){
        audioSource.PlayOneShot(clip);
        audioSource.volume = volume;
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
        // else
        // {
        //     Globals.horizontal = 0;
        // }
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
        PlaySound(FailueClip, 0.7f);
    }

    public void OnGo(bool isGo){
        partical.SetActive(isGo);
        // GetComponent<BoxCollider2D>().isTrigger = isGo;
        // transform.GetComponent<Rigidbody2D>().trigg
        // transform.GetComponent<Rigidbody>().enabled = false;
    }

}
