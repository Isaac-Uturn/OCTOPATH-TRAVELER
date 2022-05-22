using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Alliance
{
    public List<Alliance> alliance;
    
    Vector2 movement;
    float offset;

    float basicSpeed = 0;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    Animator playerAnim;
    SpriteRenderer playerRenderer;
    BoxCollider playerCollider;
    Rigidbody playerRigid;

    int randomValue;
    int battleRandom;

    private void Start()
    {
        basicSpeed = walkSpeed;

        DontDestroyOnLoad(this);

        playerAnim = GetComponent<Animator>();
        playerAnim.enabled = false;
        playerRenderer = GetComponent<SpriteRenderer>();
        playerCollider = gameObject.AddComponent<BoxCollider>();
        playerCollider.size = new Vector3(0.5f, 0.66f, 0.5f);
        playerRigid = gameObject.AddComponent<Rigidbody>();
        playerRigid.freezeRotation = true;
    }

    private void Update()
    {
        if (ALLYSTATE.Combat != currentState)
        {
            MoveToPlayer();
            //ChangeBattleSnece();
        }

        switch (currentState)
        {
            case ALLYSTATE.FowardIdle:
                playerAnim.enabled = false;
                playerRenderer.sprite = sprites[1];
                break;
            case ALLYSTATE.LeftIdle:
                playerAnim.enabled = false;
                playerRenderer.sprite = sprites[2];
                break;
            case ALLYSTATE.RightIdle:
                playerAnim.enabled = false;
                playerRenderer.sprite = sprites[3];
                break;
            case ALLYSTATE.BackIdle:
                playerAnim.enabled = false;
                playerRenderer.sprite = sprites[0];
                break;
            case ALLYSTATE.Move:
                TransAnimation();
                ChangeSpeed();
                break;
            case ALLYSTATE.Combat:
                break;
        }
    }

    void MoveToPlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        playerAnim.SetFloat("DirectX", movement.x * offset);
        playerAnim.SetFloat("DirectY", movement.y * offset);

        transform.position += new Vector3(movement.x, 0, movement.y).normalized * basicSpeed * Time.deltaTime;

        if (movement.x > 0 || movement.x < 0 ||
            movement.y > 0 || movement.y < 0)
        {
            battleRandom++;
            playerAnim.enabled = true;

            currentState = ALLYSTATE.Move;
        }
    }

    public override float GetMoveX()
    {
        return movement.x * offset;
    }

    public override float GetMoveY()
    {
        return movement.y * offset;
    }


    void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            basicSpeed = runSpeed;
        }

        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            basicSpeed = walkSpeed;
        }
    }

    void TransAnimation()
    {
        if (Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.UpArrow))
        {
            currentState = ALLYSTATE.BackIdle;
        }

        else if (Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.DownArrow))
        {
            currentState = ALLYSTATE.FowardIdle;
        }

        else if (Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentState = ALLYSTATE.LeftIdle;
        }

        else if (Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentState = ALLYSTATE.RightIdle;
        }
    }

    void ChangeBattleSnece()
    {
        if (battleRandom == randomValue)
        {
            randomValue = Random.Range(1000, 2500);
            SceneManager.LoadScene("Battle");

            currentState = ALLYSTATE.Combat;
            playerAnim.enabled = true;
            playerAnim.SetBool("isCombat", true);
        }
    }
    public List<Alliance> GetAllianceList()
    {
        return alliance;
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
    //        gameObject.GetComponent<Player>().enabled = false;
    //    }
    //}
}
