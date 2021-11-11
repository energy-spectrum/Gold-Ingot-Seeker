using UnityEngine;


public class CameraController : MonoBehaviour
{
    private float speed = 0.02f;
    private float zoomMin = 3f;
    private float zoomMax = 7.5f;
    void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchFirst = Input.GetTouch(1);

            Vector2 touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPos = touchFirst.position - touchFirst.deltaPosition;

            float distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
            float currentDistTouch = (touchZero.position - touchFirst.position).magnitude;

            float difference = currentDistTouch - distTouch;

            Zoom(difference * speed);
        }
    }

    private void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomMin, zoomMax);
    }
}
