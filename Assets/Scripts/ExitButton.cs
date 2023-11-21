using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ExitButton : MonoBehaviour
{

    [SerializeField] private Button beginButton;
    // Start is called before the first frame update
    void Start()
    {
        beginButton.onClick.AddListener(ExitPlay);

    }

    private void ExitPlay()
    {
        
        
            MainManager.Instance.Exit();
        
    }

 
}
