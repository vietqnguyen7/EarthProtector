using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
    public float speed;
    Vector2 dir;
    bool isReady;

    void Awake()
    {
        speed = 1.6f;
        isReady = false;
    }
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 pos = transform.position;
            pos += dir * speed * Time.deltaTime;
            transform.position = pos;
        }
	
	}

    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
        isReady = true;
    }
}
