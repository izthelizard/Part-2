using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lilmushcounter : MonoBehaviour
{
    // Slider function named
    public Slider count;
    // Start is called before the first frame update

    // 
    void lilmush(float lilmushclick)
    {
        //make the slider number go down
        count.value -= lilmushclick;
        // if the count on the slider is 0 or less then, then it will refresh to the start screen again (or the next scene in the order)
        if (count.value <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


 
}
