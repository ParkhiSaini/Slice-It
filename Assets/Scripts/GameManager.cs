using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate=1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public bool isGameActive;
    public Button RestartButton;
    public GameObject titleScreen;
    private int lives;
    public GameObject pausescreen;
    private bool paused;

    public void StartGame(int difficulty)
    {
        isGameActive=true;
        spawnRate/=difficulty;
        StartCoroutine(SpawnTarget());
        score=0;
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Pause();

        }
    }

    void Pause()
    {
        if(!paused)
        {
            paused=true;
            pausescreen.SetActive(true);
            Time.timeScale=0;
        }
        else{
            paused=false;
            pausescreen.SetActive(false);
            Time.timeScale =1;

        }
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index =Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public  void UpdateScore(int scoreToAdd){
        score+=scoreToAdd;
        scoreText.text="Score:"+score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        isGameActive=false;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateLives(int remlives)
    {
        lives+= remlives;
        livesText.text = "Lives:"+lives;
        if(lives<=0)
        {
            GameOver();
        }

    }
   
   


}
