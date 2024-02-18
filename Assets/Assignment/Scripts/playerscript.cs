using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    Vector2 dest;
    Vector2 movement;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement", movement.magnitude);
    }

    private void FixedUpdate()
    {
        movement = dest - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

    }
}
