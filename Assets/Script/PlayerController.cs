using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�̵� ����
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[4];

    Vector2 movement;

    float basicSpeed = 0;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    Animator playerAnim;
    SpriteRenderer playerRenderer;
    BoxCollider playerCollider;
    Rigidbody playerRigid;

    bool isDungeon = true;
    int randomValue;
    int ran;

    void Start()
    {
        basicSpeed = walkSpeed;

        playerAnim = GetComponent<Animator>();
        playerAnim.enabled = false;
        playerRenderer = GetComponent<SpriteRenderer>();
        playerCollider = gameObject.AddComponent<BoxCollider>();
        playerCollider.size = new Vector3(0.5f, 0.66f, 0.5f);

        playerRigid = gameObject.AddComponent<Rigidbody>();

        playerRigid.freezeRotation = true;

        if (isDungeon)
        {
            randomValue = Random.Range(1000, 2500);
        }
    }

    void Update()
    {
        ChangeSpeed();
        MoveToPlayer();
        TransAnimation();

        if (isDungeon)
        {
            //RendomDungeonTrap();
        }
    }

    void MoveToPlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        playerAnim.SetFloat("DirectX", movement.x * offset);
        playerAnim.SetFloat("DirectY", movement.y * offset);

        transform.position += new Vector3(movement.x, 0, movement.y).normalized * basicSpeed * Time.deltaTime;
        
        if (movement.x > 0 || movement.x < 0 ||
            movement.y > 0 || movement.y < 0)
        {
            ran++;
            playerAnim.enabled = true;
        }
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
        if (Input.GetKeyUp(KeyCode.A) 
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnim.enabled = false;
            playerRenderer.sprite = sprites[0];
        }

        else if (Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnim.enabled = false;
            playerRenderer.sprite = sprites[1];
        }

        else if (Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnim.enabled = false;
            playerRenderer.sprite = sprites[2];
        }

        else if (Input.GetKeyUp(KeyCode.D)
            || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnim.enabled = false;
            playerRenderer.sprite = sprites[3];
        }
    }

    void RendomDungeonTrap()
    {          
        if (ran == randomValue)
        {
            randomValue = Random.Range(1000, 2500);
            SceneManager.LoadScene("Battle");

            playerAnim.SetBool("isCombat", true);
        }
    }

    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //��Ʋ���� ��� ���̾��Ű â���� ��ġ�� ã�� �����ϴ� ����� ����
        if (SceneManager.GetActiveScene().name == "Battle")
        {
            gameObject.transform.position = GameObject.Find("Point").transform.position;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}
