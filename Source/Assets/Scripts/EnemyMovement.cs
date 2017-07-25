using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1.4f;
    private float wallLeft;
    private float wallRight;
    private float wallTop;
    private float wallDown;
    public float unitLeft;
    public float unitRight;
    public float unitTop;
    public float unitDown;
    float Dir = 1.0f;
    public bool vertical = false;
    Vector2 walk;

    void Start()
    {
        if(vertical)
        {
            wallTop = transform.position.y + unitTop;
            wallDown = transform.position.y - unitDown;
        }
        else
        {
            wallLeft = transform.position.x - unitLeft;
            wallRight = transform.position.x + unitRight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!vertical)
        {
            walk.x = Dir * Speed * Time.deltaTime;
            if (Dir > 0.0f && transform.position.x >= wallRight)
            {
                Dir = -1.0f;
            }
            else if (Dir < 0.0f && transform.position.x <= wallLeft)
            {
                Dir = 1.0f;
            }
        }
        else
        {
            walk.y = Dir * Speed * Time.deltaTime;
            if (Dir > 0.0f && transform.position.y >= wallTop)
            {
                Dir = -1.0f;
            }
            else if (Dir < 0.0f && transform.position.y <= wallDown)
            {
                Dir = 1.0f;
            }
        }

        transform.Translate(walk);

    }
}