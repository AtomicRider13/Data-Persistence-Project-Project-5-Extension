using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BeginButton : MonoBehaviour
{

    [SerializeField] private Button beginButton;
    // Start is called before the first frame update
    void Start()
    {
        beginButton.onClick.AddListener(BeginPlay);

    }

    private void BeginPlay()
    {
        
        
            SceneManager.LoadScene(1);
        
    }

 
}
