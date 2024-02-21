using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lilmushcounter : MonoBehaviour
{
    public Slider count;
    // Start is called before the first frame update

    void lilmush(float lilmushclick)
    {
        count.value -= lilmushclick;
        if (count.value <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


 
}
