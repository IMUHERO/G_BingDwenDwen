using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals: MonoBehaviour
{
    public static int collectNum;
    public static float rotateRate;
    public static float speedRate;
    public static float totalDistance;
    public static float horizontal;

    public static void Restart(){
        collectNum = 0;
        rotateRate = 3;
        speedRate = 1;
        totalDistance = 0;
        horizontal = 0.0f;
    }
    // 主要参数
    public const float LAND_MOVE_SPEED = 4.0f;
    public const float MaxCollectNum = 5.0f;   // 积攒5个释放大招

    public const int LAND_HIGH = 15;

    public const int LAND_WIDTH = 16;
    // UI
    public const int TIP_SHOW_TIME = 3;

    // 雪崩
    public const float ICE_BORN_MOVE_SPEED = 1;
    public const float ICE_BORN_BEGIN_MOVE_DIS = 6;
    // 障碍物
    public const int OBSTABLE_LIVE_DISTANCE = 50;
    // 特殊地板
    public const float SAND_SPEED_RATE = 0.5f;
    public const float SAND_ROTATE_RATE = 0.5f;
    public const float ICE_SPEED_RATE = 2.0f;
    public const float ICE_ROTATE_RATE = 0.2f;
    public const float SNOW_SPEED_RATE = 0.7f;
    public const float SNOW_ROTATE_RATE = 0.5f;

    // name
    public const string SNOW_BORN_NAME = "snowBorn";
    public const string SMALL_NAME = "small";
    public const string BIG_NAME = "big";
    public const string LAND_NAME = "land";

    // text
    public const string TIP_SPEED = "滑雪速度加快!";
}
