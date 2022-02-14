using UnityEngine;
public class UILeftBtn : MonoBehaviour 
{
    public float Ping;
    private bool IsStart = false;
    private float LastTime = 0;
    // private bool isIn = false;
    void Update () {
        if (IsStart && Ping > 0 && LastTime > 0 && Time.time - LastTime > Ping)
        {
            Debug.Log("长按触发");
            IsStart = false;
            LastTime = 0;
        }
        if(checkOriHori()){
            AddHori();
            SubHori();
        }
    }
    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        if(IsStart)
        {
            Globals.leftIn = true;
            Globals.countDownBtn = "left";
            LastTime = Time.time;
            Debug.Log("长按开始");
            // Globals.horizontal = -1;
        }
        else if(LastTime != 0)
        {
            Globals.leftIn = false;
            LastTime = 0;
            Debug.Log("长按取消");
            // if(Globals.horizontal < 0){
            //     Globals.horizontal = 0;
            // }
        }    
    }
    public static bool checkOriHori(){

        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) < 0.0001f)
        {
            return true;
        }
        return false;
    }

    private void AddHori(){
        if(! Globals.leftIn ){
            return;
        }
        float newHori = Globals.horizontal - Time.deltaTime * Globals.HORI_CHANGE_RATE;
        Globals.horizontal = Mathf.Clamp(newHori, -1, 0);
    }

    private void SubHori(){
        if(Globals.countDownBtn == "left" && ! Globals.rightIn && ! Globals.leftIn){
            // print("000000000: " + Globals.horizontal);
            float newHori = Globals.horizontal + Time.deltaTime * Globals.HORI_CHANGE_RATE;
            Globals.horizontal = Mathf.Clamp(newHori, -1, 0);
            // print("1111111111: " + newHori);
            // print("2222222222: " + Globals.horizontal);
        }
    }
}
