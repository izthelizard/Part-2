using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour
{
    public List<Vector2> points;
    Vector3 lastPosition;
    Vector2 currentPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    public AnimationCurve landing;
    float landingTimer;
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y); 
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f )
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero * 0.75f, interpolation);
        }

        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);
                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown() {
    
        points = new List<Vector2>();
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastPosition = currentPosition;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void onMouseDrag() {

        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > pointThreshold) { 
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(0, currentPosition);
            lastPosition = currentPosition;
        }
    
    }

}
