using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text stopMessage;
    public GameObject stopObject;
    private bool stop;

    private void Awake()
    {
        gm = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        stopObject.SetActive(false);
        //stopMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //일시정지 기능
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(stop == false) {
                Time.timeScale = 0;
                stopObject.SetActive(true);
                //stopMessage.gameObject.SetActive(true);
                stop = true;
                return;
            }
            
            if(stop == true) {
                Time.timeScale = 1;
                stopObject.SetActive(false);
                //stopMessage.gameObject.SetActive(false);
                stop = false;
                return;
            }
        }
    }

    //게임오버 기능
    public void GameOver()
    {
        //게임오버되면 GameOver Scene을 실행
        SceneManager.LoadScene("GameOver");
        //Debug.Log("게임 오버");
    }
}
