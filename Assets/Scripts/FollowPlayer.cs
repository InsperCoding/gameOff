using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // public Vector3 offset;


    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, -10);
    }
}
