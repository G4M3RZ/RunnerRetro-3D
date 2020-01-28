using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour {
    public TextMeshPro ElScore;
    public TextMeshPro HighScoreDead;
    public TextMeshPro HighScorePause;
    public GameObject Puntaje;
    public float numb;
	// Use this for initialization
	void Start ()
    {
        HighScoreDead.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");
        HighScorePause.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");
    }
	
	// Update is called once per frame
	void Update () {
        numb = Puntaje.GetComponent<Puntaje>().Contador;
        Score();
	}

    public void Score()
    {
        ElScore.text = numb.ToString("Score: " + "0");
        if (numb > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", numb);
            HighScoreDead.text = numb.ToString("f0");
            HighScorePause.text = numb.ToString("f0");
        }
    }
}
