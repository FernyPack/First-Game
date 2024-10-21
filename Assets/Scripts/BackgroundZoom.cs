using UnityEngine;

public class BackgroundZoom : MonoBehaviour
{
    public float zoomSpeed = 0.5f;  // Speed of zoom
    public float zoomAmount = 0.05f;  // Amount to zoom in and out
    private Vector3 originalScale;  // Store the original scale
    private bool zoomingIn = true;  // Track whether we are zooming in or out

    void Start()
    {
        // Store the original scale of the background object
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Adjust the scale based on zoom direction
        if (zoomingIn)
        {
            transform.localScale += Vector3.one * zoomSpeed * Time.deltaTime;

            // If we've zoomed in by the specified amount, start zooming out
            if (transform.localScale.x >= originalScale.x + zoomAmount)
            {
                zoomingIn = false;
            }
        }
        else
        {
            transform.localScale -= Vector3.one * zoomSpeed * Time.deltaTime;

            // If we've zoomed out by the specified amount, start zooming in
            if (transform.localScale.x <= originalScale.x - zoomAmount)
            {
                zoomingIn = true;
            }
        }
    }
}
