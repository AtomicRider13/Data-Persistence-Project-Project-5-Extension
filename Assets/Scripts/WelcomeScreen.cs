using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    public string inputName;

    public TextMeshProUGUI playerScore;
    
    public TextMeshProUGUI highScore;
    private int score;
    private int highScoreToBeat;
    private string highScoreName;
    

    // Start is called before the first frame update
    void Start()
    {
        
        highScoreName = MainManager.Instance.highScoreName;
        highScoreToBeat = MainManager.Instance.highScore;
        if (highScoreToBeat == 0) 
        { 
            highScore.text = " ";
        } else {
            highScore.text = highScoreName + " - " + highScoreToBeat;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        NameInput();
    }

    public void NameInput()
    {
        if (inputName != null)
        {
            playerName.text = MainManager.Instance.playerName;
        }
        inputName = playerName.text;
        MainManager.Instance.playerName = inputName;
    }

    public void HighScore()
    {
        playerScore.text = highScoreName + " - " + highScoreToBeat;
    }
    
}
