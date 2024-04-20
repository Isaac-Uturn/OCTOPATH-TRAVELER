using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{
    GameObject Player;

    CinemachineVirtualCamera cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        cinemachine = GetComponent<CinemachineVirtualCamera>();

        if (null != Player)
        {
            cinemachine.m_Follow = Player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
