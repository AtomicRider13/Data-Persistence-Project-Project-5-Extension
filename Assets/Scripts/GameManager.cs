using System.Collections;

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playerName;

    public TextMeshProUGUI highScore;
    public GameObject titleScreen;
    public TextMeshProUGUI livesText;
    public AudioSource gameMusic;
    public GameObject pauseMenu;



    public bool isGameActive;
    private int score = 0;
    private float spawnRate = 1.0f;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = "Player: " + MainManager.Instance.playerName;
        highScore.text = "High Score: " + MainManager.Instance.highScore;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("Space bar pressed");
                PauseMenu();
            }
        highScore.text = "High Score: " + MainManager.Instance.highScore;

        if (score > MainManager.Instance.highScore)
        {
            MainManager.Instance.highScore = score;
            MainManager.Instance.highScoreName = MainManager.Instance.playerName;
        }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[index]);


            if (lives == 0) 
            {
                GameOver();
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
       
        score += scoreToAdd;
        MainManager.Instance.score = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToSubtract)
    {
        lives -= livesToSubtract;
        if (lives < 0) 
        {
            lives = 0;
        }
        livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    public void PauseMenu() 
    {
        if (Time.timeScale == 1) 
        {
            Debug.Log("Time Scale should be set to 0");
            Time.timeScale = 0;
            Debug.Log("Pause screen should display");
            pauseMenu.gameObject.SetActive(true);

            
        } else if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Time Scale should be set to 1");
            Time.timeScale = 1;
            Debug.Log("Pause screen should not display");
            pauseMenu.gameObject.SetActive(false);
           
        }
    }  
}
