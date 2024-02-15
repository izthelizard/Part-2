using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionScript : MonoBehaviour
{
   public void SetResolution16x9()
    {
        Screen.SetResolution(1600, 900, false);
        Debug.Log("16:9");
    }

    public void SetResolutionHD()
    {
        Screen.SetResolution(1920, 1080, false);
        Debug.Log("HD");
    }
}
