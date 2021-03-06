using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals: MonoBehaviour
{
    public static bool gameStart = false;
    public static int collectNum;
    public static float rotateRate;
    public static float speedRate;
    public static float generateRate;
    public static float totalDistance;
    public static float horizontal;

    public static float distanceSpeedRate;
    public static float distanceGenerateRate;

    public static bool leftIn;
    public static bool rightIn;
    public static string countDownBtn;
    // 大招
    public static bool isPlayerGo;
    public static bool canGo;

    public static void Restart(){
        gameStart = true;
        collectNum = 0;
        rotateRate = BASE_ROTATE_RATE;
        speedRate = BASE_SPEED_RATE;
        generateRate = 1;
        totalDistance = 0;
        horizontal = 0.0f;
        distanceSpeedRate = 1;
        distanceGenerateRate = 1;
        leftIn = false;
        rightIn = false;
        countDownBtn = "";
        isPlayerGo = false;
        canGo = false;
    }
    // 主要参数
    public const float PLAYER_GO_SPEED = 15f;
    public const float HORI_CHANGE_RATE = 2f;
    public const float BASE_ROTATE_RATE = 5;
    public const float BASE_SPEED_RATE = 1;
    public const float LAND_MOVE_SPEED = 4.0f;
    public const float MaxCollectNum = 8f;   // 积攒5个释放大招

    public const int LAND_HIGH = 15;

    public const int DIS_ADD_SPEED = 200;
    public const float DIS_ADD_GEN = 100;
    public const float DIS_ADD_SPEED_RATE = 0.15f;
    public const float DIS_ADD_GEN_RATE = 0.85f;
    // public static float[] DIS_SPEED_RATE = {1.2f, 1.5f, 2.0f};
    // public static float[] DIS_GEN_RATE = {1.2f, 1.5f, 2.0f};

    public const int LAND_WIDTH = 14;
    // UI
    public const float TIP_SHOW_TIME = 1.5f;
    public const int XRR_SHOW_TIME = 1;

    // 雪崩
    public const float ICE_BORN_MOVE_SPEED = 1;
    public const float ICE_BORN_BEGIN_MOVE_DIS = 6;
    public const float SNOW_BORN_MOVE_RATE = 0.8f;
    // 障碍物
    public const int OBSTABLE_LIVE_DISTANCE = 50;
    // 特殊地板
    public const float SAND_SPEED_RATE = 0.5f;
    public const float SAND_ROTATE_RATE = 0.5f;
    public const float ICE_SPEED_RATE = 1.5f;
    public const float ICE_ROTATE_RATE = 0.2f;
    public const float SNOW_SPEED_RATE = 0.7f;
    public const float SNOW_ROTATE_RATE = 0.5f;

    // name
    public const string PLAYER_STAGE_BEGIN = "BEGIN";
    public const string PLAYER_STAGE_MOVING = "MOVING";
    public const string PLAYER_STAGE_OVER = "OVER";

    public const string SNOW_BORN_NAME = "snowBorn";
    public const string SMALL_NAME = "small";
    public const string BIG_NAME = "big";
    public const string LAND_NAME = "land";
    public const string LANTERN_NAME = "land";

    public const string PLAYER_MOVE_TRIGGER = "moving";
    public const string PLAYER_MOVE_HORI = "hori";
    public const string PLAYER_ANI_OVER = "over";
    public const string PLAYER_ANI_BEGIN = "begin";

    // text
    public const string TIP_SPEED = "滑雪速度加快!";
    public const string TIP_GENERATE = "障碍物增多!";
}
