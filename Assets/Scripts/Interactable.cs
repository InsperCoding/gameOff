using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactionAction;
    public GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        // Check if current scene is not Room 0 or Room6_Boss_1 or Room17_Boss_2
        if (SceneManager.GetActiveScene().name != "Room0" && SceneManager.GetActiveScene().name != "Room6_Boss_1" && SceneManager.GetActiveScene().name != "Room17_Boss_2")
        {
            Spawner = GameObject.Find("Spawners");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (SceneManager.GetActiveScene().name == "Room0")
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactionAction.Invoke();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Room6_Boss_1" || SceneManager.GetActiveScene().name == "Room17_Boss_2")
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactionAction.Invoke();
                }
            }
            else
            {
                if (Input.GetKeyDown(interactKey) && Spawner.GetComponent<Spawner>().max_enemies == 0)
                {
                    interactionAction.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
