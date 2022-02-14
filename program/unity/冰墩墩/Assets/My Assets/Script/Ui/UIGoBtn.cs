using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onGoBtn(){
        print(">>> on go btn ........");
        if(!Globals.canGo){
            return;
        }
        GameManager.instance.OnGo(true);
    }
}
