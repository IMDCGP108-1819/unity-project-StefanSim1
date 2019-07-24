using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1.5f;
    [SerializeField] int Asteroids;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void CountAsteroids()
    {
        Asteroids++;
    }

    public void AsteroidsDestroyed()
    {
        Asteroids--;
        if(Asteroids <=0)
        {
            
        }
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadNextScene();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
