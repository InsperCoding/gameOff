using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public GameObject enemy;

    public Transform[] spawn_points;

    public float spawnCD;
    public float currentCD;
    // Start is called before the first frame update
    void Start()
    {
        currentCD = spawnCD;
    }

    // Update is called once per frame
    void Update()
    {
        currentCD -= Time.deltaTime;

        if(currentCD <= 0){
            spawn_enemy();
        }
    }

    private void spawn_enemy(){
        int point = Random.Range(0, spawn_points.Length);

        Instantiate(enemy, spawn_points[point].position, Quaternion.identity);
        currentCD = spawnCD;
    }
}
