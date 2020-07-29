using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }

    void loadNextLevel() {
        int s = SceneManager.GetActiveScene().buildIndex;
        if (s == 0)
            SceneManager.LoadScene(1);
        if (s == 1)
            SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag=="Finish")
        {
            loadNextLevel();   
        }
    }

}
