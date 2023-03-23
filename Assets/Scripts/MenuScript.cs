using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMenu() {
        transform.gameObject.SetActive(true);
    }
    public void CloseMenu()
    {
        transform.gameObject.SetActive(false);
    }

    public void OpenOptions() { 
    
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
