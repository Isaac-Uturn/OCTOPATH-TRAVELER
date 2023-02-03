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