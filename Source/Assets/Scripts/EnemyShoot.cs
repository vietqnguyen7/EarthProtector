using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public GameObject EnemyBullet;
    public GameObject player;
    private float time;
    public bool RapidFire = false;
    public bool Normal = false;

    //UFO VARIABLES
    public int ufoNum;
    static int ufoFire = 1;
    static int fireNum = 0;
    static bool fire = true;
    int ufoLow = 1;
    int ufoHigh = 6;

    //METEOR VARIABLES 
    static int metLow = 1;
    static int metHigh = 6;
    static int meteorNum = 1;
    public int sendMet = 1;
    static bool metFire = true;


    //HEALTHPACK VARIABLES 
    static int healthNum = 1;
    public int sendHealth = 1;
    static bool healthFire = true;

    //Sound Effects
    public AudioClip bulletSFX;

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (RapidFire)
        {
            Invoke("FireBullet", 1f);
        }
        else if(Normal)
        {

            //Fires UFO fire
            if (fire && ufoNum == ufoFire)
            {
                Invoke("FireBullet", 1f);
                fire = false;
                fireNum++;
                Invoke("ResetUFO", 1.6f);
            }

            //Fires meteor
            if(fireNum % 5 == 0 && meteorNum == sendMet && metFire)
            {
                Invoke("SendMeteor", 1f);
                metFire = false;
                Invoke("ResetMet", 2);

            }

            //Fires healthpack
            if(fireNum % 25 == 0 && healthNum == sendHealth && healthFire)
            {
                Invoke("SendHealth", 1f);
                healthFire = false;
                Invoke("ResetHealth", 5);
            }
        }

    }

    //Fire UFO bullet
    void FireBullet()
    {
        GameObject bullet = (GameObject)Instantiate(EnemyBullet);
        bullet.transform.position = transform.position;
        Vector2 dir = player.transform.position - bullet.transform.position;
        SoundManager.instance.PlaySingle(bulletSFX);
        bullet.GetComponent<EnemyBullet>().SetDirection(dir);
    }

    //Send Meteor
    void SendMeteor()
    {
        GameObject meteor = (GameObject)Instantiate(EnemyBullet);
        meteor.transform.position = transform.position;
        Vector2 dir = player.transform.position - meteor.transform.position;
        meteor.GetComponent<EnemyBullet>().SetDirection(dir);
    }

    //Send Healthpack
    void SendHealth()
    {
        GameObject health = (GameObject)Instantiate(EnemyBullet);
        health.transform.position = transform.position;
        Vector2 dir = player.transform.position - health.transform.position;
        health.GetComponent<EnemyBullet>().SetDirection(dir);
    }


    void ResetUFO()
    {
        ufoFire = Random.Range(ufoLow, ufoHigh);
        fire = true;
    }

    void ResetMet()
    {
        meteorNum = Random.Range(metLow, metHigh);
        metFire = true;
    }

    void ResetHealth()
    {
        healthNum = Random.Range(1, 4);
        healthFire = true;
    }

    public void ResetVariables()
    {
        ufoFire = 1;
        fireNum = 0;
        fire = true;
        metLow = 1;
        metHigh = 6;
        meteorNum = 1;
        metFire = true;
        healthNum = 1;
        healthFire = true;
    }
}
