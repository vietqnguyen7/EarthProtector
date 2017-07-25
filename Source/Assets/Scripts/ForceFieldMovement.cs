using UnityEngine;
using System.Collections;

public class ForceFieldMovement : MonoBehaviour
{

    public float speed = 100;
    private bool clockwise = false;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (clockwise)
            transform.Rotate(0, 0, -speed * Time.deltaTime);
        else
            transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            clockwise = !clockwise;
        }

#if UNITY_ANDROID
        int touchCounts = Input.touchCount;
        if(touchCounts > 0)
        {
            for(int x = 0; x < touchCounts; x++)
            {
                Touch touch = Input.GetTouch(x);
                if(touch.phase == TouchPhase.Began)
                    clockwise = !clockwise;
            }
        }
#endif
    }
}
