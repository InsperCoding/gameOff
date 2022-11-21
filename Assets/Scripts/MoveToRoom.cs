using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToRoom : MonoBehaviour
{
    public int RoomNumber;
    public void MoveNextRoom()
    {
        if(Random.Range(0,100) >= 80)
        {
            SceneManager.LoadScene(14);
        } else
        {
            SceneManager.LoadScene(RoomNumber);
        }
    }
}
