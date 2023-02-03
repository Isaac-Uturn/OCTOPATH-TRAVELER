using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum BATTLETRUN
{
    SelectAction,
    PlayerAttack,
    EnemyAttack,
    DamageCount,
    BattleEnd
}

enum BattleStage
{

}


//배틀시작
//명령 선택
//플레이어가 몬스터 공격
//몬스터가 플레이어 공격
//죽었다면 비활성화 혹은 삭제
//몬스터나 플레이어 전멸 시 게임 끝
//다시 명령 선택
//플레이어가 몬스터 공격
//몬스터가 플레이어 공격
//몬스터나 플레이어 전멸 시 게임 끝


public class BattleManager : MonoBehaviour
{
    public static BattleManager instance = null;

    [SerializeField]
    Transform[] alliancePoints = new Transform[5];


    BATTLETRUN currentTrun = BATTLETRUN.SelectAction;

    Player player;

    public static BattleManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    void Start()
    {
        player = FindObjectOfType<Player>();

        for (int i = 0; i < player.alliance.Count; i++)
        {
            player.alliance[i].transform.position = alliancePoints[i].position;
        }
    }

    void Update()
    {

        switch (currentTrun)
        {

            case BATTLETRUN.SelectAction:
                break;

            case BATTLETRUN.PlayerAttack:
                break;

            case BATTLETRUN.EnemyAttack:
                break;

            case BATTLETRUN.DamageCount:
                break;

            case BATTLETRUN.BattleEnd:
                break;
        }

    }
}

//void OnEnable()
//{
//    // 씬 매니저의 sceneLoaded에 체인을 건다.
//    SceneManager.sceneLoaded += OnSceneLoaded;
//}

//// 체인을 걸어서 이 함수는 매 씬마다 호출된다.
//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    //배틀씬일 경우 하이어라키 창에서 위치를 찾아 대입하는 방법이 있음
//    if (SceneManager.GetActiveScene().name == "Battle")
//    {
//        gameObject.transform.position = GameObject.Find("Point").transform.position;
//        gameObject.GetComponent<PlayerController>().enabled = false;
//    }
//}