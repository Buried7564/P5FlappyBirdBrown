using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour 
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameover = false;
    public float scrollSpeed = -1.5f;
    public TextMeshProUGUI Continue;
    public TextMeshProUGUI ScoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }
    }
    public void BirdScored()
    {
        if (gameover)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameover = true;
    }
}
