using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilmushcounter : MonoBehaviour
{
    public Slider count;
    // Start is called before the first frame update

    void lilmush(float lilmushclick)
    {
        count.value -= lilmushclick;
    }


 
}
