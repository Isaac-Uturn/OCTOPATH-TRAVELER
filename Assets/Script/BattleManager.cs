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

//��Ʋ����
//��� ����
//�÷��̾ ���� ����
//���Ͱ� �÷��̾� ����
//�׾��ٸ� ��Ȱ��ȭ Ȥ�� ����
//���ͳ� �÷��̾� ���� �� ���� ��
//�ٽ� ��� ����
//�÷��̾ ���� ����
//���Ͱ� �÷��̾� ����
//���ͳ� �÷��̾� ���� �� ���� ��


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
//    // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
//    SceneManager.sceneLoaded += OnSceneLoaded;
//}

//// ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
//void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//{
//    //��Ʋ���� ��� ���̾��Ű â���� ��ġ�� ã�� �����ϴ� ����� ����
//    if (SceneManager.GetActiveScene().name == "Battle")
//    {
//        gameObject.transform.position = GameObject.Find("Point").transform.position;
//        gameObject.GetComponent<PlayerController>().enabled = false;
//    }
//}