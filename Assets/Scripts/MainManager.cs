using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
 [SerializeField] private TextMeshProUGUI inputFieldPlayerName;
  public string playerName;
  public int score;
  public int highScore;
  public string highScoreName;
  

  private void Awake()
  {
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);

    LoadDataFromJSON();
  }

  private void LateUpdate()
  {
    
  }

  public void SetPlayerName()
  {
    playerName = inputFieldPlayerName.text;
  }

  public void Exit()
    {
        
    #if UNITY_EDITOR
        SaveToJSON();
        EditorApplication.ExitPlaymode();
    #else
        SaveToJSON();
        Application.Quit(); // original code to quit Unity player
    #endif
    }

    [System.Serializable]
    class SaveData 
    {
        public string highScoreName;
        public int highScore;
    }
    public void SaveToJSON()
    {
    SaveData data = new SaveData();
    data.highScoreName = highScoreName;
    data.highScore = highScore;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFromJSON()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highScoreName = data.highScoreName;
        highScore = data.highScore;
    }
}
}
