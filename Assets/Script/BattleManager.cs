using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum BATTLETRUN
{
    BATTLESTART,
    SELECTACTION,
    PLAYERATTACK,
    ENEMYATTACK,
    DAMAGECOUNT,
    BATTLEEND
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
    [SerializeField]
    Transform[] alliancePoints = new Transform[5];

    BATTLETRUN currentTrun = BATTLETRUN.BATTLESTART;

    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

        for (int i = 0; i < player.GetAllianceList().Count; i++)
        {
            Alliance alliance = player.GetAllianceList()[i];
            alliance.transform.position = alliancePoints[i].position;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("World");
        }

        switch (currentTrun)
        {
            case BATTLETRUN.BATTLESTART:
                break;

            case BATTLETRUN.SELECTACTION:
                break;

            case BATTLETRUN.PLAYERATTACK:
                break;

            case BATTLETRUN.ENEMYATTACK:
                break;

            case BATTLETRUN.DAMAGECOUNT:
                break;

            case BATTLETRUN.BATTLEEND:
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