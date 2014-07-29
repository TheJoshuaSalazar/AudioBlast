using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{
    public GUIText scoreText;
    public int gameScore;
    public InputAudio inputAudio;
    public GameObject cubeLevel;


    // Use this for initialization
    void Start()
    {
        //highScore = PlayerPrefs.GetInt("score");
        scoreText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputAudio.runGame)
        {
            //scoreText.enabled = true;
            cubeLevel.SetActive(true);
            submitSocre(gameScore);
        }
    }

    void OnGUI()
    {
        scoreText.text = "Score: " + gameScore;
    }

    void submitSocre(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }
}
