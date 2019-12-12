using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeButton : MonoBehaviour
{
    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    public void PauseResumeGame()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1.0f;
        }
        else if (Time.timeScale != 1.0f)
        {
            Time.timeScale = 0f;
        }
        

        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 frames per real-time second
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

    }

    public void GoFast()
    {
        Time.timeScale = 1.5f;
       
        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 frames per real-time second
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    public void GoVeryFast()
    {
      
        Time.timeScale = 2.0f;
        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 frames per real-time second
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    public void SlowDown()
    {
       
        Time.timeScale = 0.5f;
        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 frames per real-time second
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    public void SlowDownEvenMore()
    {
        
        Time.timeScale = 0.25f;
        // Adjust fixed delta time according to timescale
        // The fixed delta time will now be 0.02 frames per real-time second
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
