using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals: MonoBehaviour
{

    public static int collectNum = 0;
    public static float rotateRate = 1;
    public static float speedRate = 1;
    // 主要参数
    public const float LAND_MOVE_SPEED = 3;

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
}
