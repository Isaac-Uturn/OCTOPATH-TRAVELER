using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colleague : MonoBehaviour
{
    public GameObject prevColleague;

    [SerializeField]
    private float followSpeed;
    bool isPlayer;

    int hp;
    int maxHp;
    int sp;
    int maxSp;

    //약점
    //고유 액션

    Animator colleagueAnim;
    SpriteRenderer colleagueRenderer;
    //Rigidbody colleagueRigid;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        colleagueAnim = GetComponent<Animator>();
        colleagueRenderer = GetComponent<SpriteRenderer>();
        //colleagueRigid = gameObject.AddComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        Vector3 offset = transform.position - prevColleague.transform.position;
        float sqrLen = offset.sqrMagnitude; 

        if (sqrLen > 0.3f)
        {
            transform.position = Vector3.Lerp(transform.position, prevColleague.transform.position, followSpeed * Time.deltaTime);
        }            
    }
}
