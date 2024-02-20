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
    public float lilMushMaxCount = 10;
    public float lilMushCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lilMushCount = lilMushMaxCount;
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
        animator.SetTrigger("lilmush");
        gameObject.SendMessage("sublilmush", -1);
        
    }

}
