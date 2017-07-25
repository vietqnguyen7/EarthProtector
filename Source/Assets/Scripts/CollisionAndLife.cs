using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionAndLife : MonoBehaviour
{

    private float life = 100;
    public GUIText lifeText;
    public bool RapidFire = false;
    public CollisionAndScore CAS;
    Animator anim;

    //SFX
    public AudioClip bullet;
    public AudioClip meteor;
    public AudioClip health;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (life <= 0)
        {
            StoreHighscore(CAS.points);
            SceneManager.LoadScene("HighScore");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (RapidFire)
                life -= 0.1f;
            else
                life -= 5;
            updateLife();
            SoundManager.instance.PlaySingle(bullet);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Meteor")
        {
            life -= 20;
            updateLife();
            SoundManager.instance.PlaySingle(meteor);
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Health")
        {
            life += 5;
            updateLife();
            SoundManager.instance.PlaySingle(health);
            Destroy(col.gameObject);
        }
    }

    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
        PlayerPrefs.SetInt("CurrentScore", newHighscore);
    }

    void updateLife()
    {
        lifeText.text = "Life: " + life + "%";
        anim.SetFloat("Life", life);
    }

}
