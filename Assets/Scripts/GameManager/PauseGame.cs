using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public bool isPaused;

    public void pause()
    {
        Time.timeScale = 0;
    }
    public void unpause()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (isPaused)
        {
            pause();
        }
        else
        {
            unpause();
        }
    }
}
