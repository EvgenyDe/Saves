using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private int currentScene;
    private int countScene;

    
    [SerializeField] private InputService inputService;


    private void Start()
    {
         countScene= SceneManager.sceneCountInBuildSettings;
         currentScene = SceneManager.GetActiveScene().buildIndex;
         Debug.Log(currentScene);

         inputService.OnEscape += MainMenu;
    }

    public void NextScene()
    {
        if(currentScene<countScene-1)
        {
            currentScene += 1;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);

    }
    public void MainMenu()
    {
        LevelInfo.levelProgress = currentScene;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        currentScene = LevelInfo.levelProgress;
        SceneManager.LoadScene(currentScene);

    }
    
}