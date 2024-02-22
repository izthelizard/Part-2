using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilmushscript : MonoBehaviour
{
    //declaring variables 
    //rigidbody
    Rigidbody2D rb;
    //animator
    public Animator animator;
    //clicking on little mush action is set to false
    bool clickOnLilMush = false;
    // number of little mushrooms at a max of 20 (each take two clicks)
    public float lilMushMaxCount = 20;
    public float lilMushCount;
    public lilmushcounter numLilMush;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //the amount of little mushrooms at the start is = to the max amount (20)
        lilMushCount = lilMushMaxCount;

    }

    // Update is called once per frame
    void Update()
    {
        // if mouse left click is click AND you're clicking on a little mushroom
        if (Input.GetMouseButtonDown(0) && clickOnLilMush)
        {
            // the little mush trigger is set (having them die and then reborn)
            animator.SetTrigger("lilmush");
        }
    }
    private void OnMouseDown()
    {
        //the counter is changed by 1
        gameObject.SendMessage("lilmush", 1);

    }
    void lilmush(float lilmushclick)
    {
        // the count goes DOWN
        lilMushCount -= lilmushclick;
        //calculates the value between the normal count and the max count and makes sure it stays within the range
        lilMushCount = Mathf.Clamp(lilMushCount, 0, lilMushMaxCount);
        //play the animation when it goes down
        animator.SetTrigger("lilmush");

    }
}
