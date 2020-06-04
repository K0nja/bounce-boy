using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        FindObjectOfType<AudioManager>().Play("death");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
