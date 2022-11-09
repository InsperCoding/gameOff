using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 offset;

    int enemiesKilled;

    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EnemyKilled(Vector3 enemyPosition){
        int random = Random.Range(0, 4);
        if (random == 0){
            offset = new Vector3(0, 1, 0);
        } else if (random == 1){
            offset = new Vector3(0, -1, 0);
        } else if (random == 2){
            offset = new Vector3(1, 0, 0);
        } else if (random == 3){
            offset = new Vector3(-1, 0, 0);
        }

        Debug.Log("Enemy Killed");
        Instantiate(enemy, enemyPosition + offset, Quaternion.identity);
        Instantiate(enemy, enemyPosition - offset, Quaternion.identity);
        enemiesKilled++;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = enemiesKilled.ToString();

    }

    public void GameOver(){
        PlayerPrefs.SetInt("score", enemiesKilled);
        SceneManager.LoadScene("GameOver");
        Debug.Log("Game Over");
    }

    void Update(){
        print(PlayerPrefs.GetInt("score"));
        if (SceneManager.GetActiveScene().name == "GameOver"){
            scoreText = GameObject.Find("ScoreText");
            scoreText.GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt("score").ToString();
            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("Game");
            }
        }
        
        if (SceneManager.GetActiveScene().name == "StartScreen"){
            if (Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene("Game");
            }
        }

        if (SceneManager.GetActiveScene().name == "Game"){
            PlayerPrefs.SetInt("score", enemiesKilled);
            scoreText = GameObject.Find("Score");
        }
    }
}
