using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    // functions declared
    //rigidbody
    Rigidbody2D rb;
    //animator
    public Animator animator;
    // destination and movement vectors declared
    Vector2 dest;
    Vector2 movement;
    // speed of player declared and made public
    public float speed = 5f;
    //not clicking on mushrooms 
    bool clickOnLilMush = false;

    // Start is called before the first frame update
    void Start()
    {
        //grab components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // grab the mouse 1 (right click) and is NOT clicking on the little mushrooms
        if (Input.GetKey(KeyCode.Mouse1) && !clickOnLilMush)
        {
            // player moves
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //the moving animation plays
        animator.SetFloat("movement", movement.magnitude);
    }

    private void FixedUpdate()
    {
        // movement adjustments so it doesn't vibrate and go crazy on screen
        movement = dest - (Vector2)transform.position;
        //if movement is less than
        if (movement.magnitude < 0.1)
        {
            //doesn't move
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

    }

    private void OnMouseDown()
    {
        // when clicking on player, they get a mushroom hat, for fun
        animator.SetTrigger("mushroom");
    }
}
