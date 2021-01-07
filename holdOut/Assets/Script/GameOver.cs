using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text textScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Game Over\n" + ScoreControl.currentScore.ToString() + "점\n" + "Press 'Enter' to restart";
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Play");
        }
    }
}
