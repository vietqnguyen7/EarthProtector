using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSource;
    public static SoundManager instance = null;


	// Use this for initialization
	void Awake ()
    {
       instance = this;
	}

    public void PlaySingle (AudioClip clip)
    {
        efxSource.PlayOneShot(clip);
    }
}
