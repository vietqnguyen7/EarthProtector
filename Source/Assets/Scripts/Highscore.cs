using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

    public GUIText Normal;
    public GUIText Current;
    // Use this for initialization
    void Start ()
    {
        Normal.text = "Normal Play: " + PlayerPrefs.GetInt("highscore", 0);
        Current.text = "Current Score: " + PlayerPrefs.GetInt("CurrentScore", 0);

    }
	
}
