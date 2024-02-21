using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilmushscript : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    bool clickOnLilMush = false;
    public float lilMushMaxCount = 20;
    public float lilMushCount;
    public lilmushcounter numLilMush;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickOnLilMush)
        {
            animator.SetTrigger("lilmush");
        }
    }
    private void OnMouseDown()
    {
        gameObject.SendMessage("lilmush", 1);

    }
    void lilmush(float lilmushclick)
    {
        lilMushCount -= lilmushclick;
        lilMushCount = Mathf.Clamp(lilMushCount, 0, lilMushMaxCount);
        animator.SetTrigger("lilmush");

    }
}
