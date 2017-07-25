using UnityEngine;
using System.Collections;

public class CollisionAndScore : MonoBehaviour {

    public int points = 0;
    public GUIText scoreText;
    public bool RapidFire = false;
    public AudioClip bulletSFX;
    public AudioClip NO;
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            SoundManager.instance.PlaySingle(bulletSFX);
            if (RapidFire)
                points += 10;
            else
                points += 100;
            updatePoints();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Meteor")
        {
            points += 1000;
            SoundManager.instance.PlaySingle(bulletSFX);
            updatePoints();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Health")
        {
            SoundManager.instance.PlaySingle(NO);
            Destroy(col.gameObject);
        }
    }

    void updatePoints()
    {
        scoreText.text = "Score: " + points;
    }

}
