using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameManager gameManager;
    public Text text;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponentInChildren<Text>();
        text.text = "Score: " + gameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.scored)
        {
            gameManager.score++;
            text.text = "Score: " + gameManager.score.ToString();
            gameManager.scored = false;
        }
    }
}
