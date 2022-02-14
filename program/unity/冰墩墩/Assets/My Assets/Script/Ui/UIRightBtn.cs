using UnityEngine;
public class UIRightBtn : MonoBehaviour
{
    public float Ping;
    private bool IsStart = false;
    private float LastTime = 0;
    // private bool isIn = false;
    void Update()
    {
        // if(PlayerController.playerStage != Globals.PLAYER_STAGE_MOVING){
        //     IsStart = false;
        //     isIn = false;
        //     return;
        // }
        if (IsStart && Ping > 0 && LastTime > 0 && Time.time - LastTime > Ping)
        {
            Debug.Log("长按触发");
            IsStart = false;
            LastTime = 0;
        }
        if (UILeftBtn.checkOriHori())
        {
            AddHori();
            SubHori();

        }
    }
    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        if (IsStart)
        {
            Globals.countDownBtn = "right";
            Globals.rightIn = true;
            LastTime = Time.time;
            Debug.Log("长按开始");
            // Globals.horizontal = 1;
        }
        else if (LastTime != 0)
        {
            Globals.rightIn = false;
            LastTime = 0;
            Debug.Log("长按取消");
            // if(Globals.horizontal > 0){
            //     Globals.horizontal = 0;
            // }
        }
    }

    private void AddHori()
    {
        if (!Globals.rightIn)
        {
            return;
        }
        float newHori = Globals.horizontal + Time.deltaTime * Globals.HORI_CHANGE_RATE;
        Globals.horizontal = Mathf.Clamp(newHori, 0, 1);
    }

    private void SubHori()
    {
        if (Globals.countDownBtn == "right" && !Globals.rightIn && !Globals.leftIn)
        {
            float newHori = Globals.horizontal - Time.deltaTime * Globals.HORI_CHANGE_RATE;
            Globals.horizontal = Mathf.Clamp(newHori, 0, 1);
        }
    }
}
