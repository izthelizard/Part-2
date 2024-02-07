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


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
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
