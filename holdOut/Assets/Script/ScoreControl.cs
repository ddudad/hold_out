using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public static int currentScore;   //현재 점수
    public Text textScore;            //점수표시를 위한 Text
    private string text;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;           //초기값 0
    }

    // Update is called once per frame
    void Update()   
    {
        textScore.text = currentScore.ToString();
    }
}
