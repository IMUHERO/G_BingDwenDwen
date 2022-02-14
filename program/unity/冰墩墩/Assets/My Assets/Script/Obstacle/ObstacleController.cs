using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float moveDis = 0;
    public string tagName = "";
    public void Moving()
    {
        if (PlayerController.playerStage != Globals.PLAYER_STAGE_MOVING)
        {
            return;
        }
        if (moveDis > Globals.OBSTABLE_LIVE_DISTANCE)
        {
            GameManager.instance.removeObject(tagName, gameObject);
        }
        Vector2 position = transform.position;
        float dis = GameManager.instance.GetObstacleSpeed() * Time.deltaTime;
        moveDis += dis;
        position.y += dis;
        transform.position = position;
    }
}
