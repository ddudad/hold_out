using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;                                   //플레이어 스피드
    public UnityEngine.UI.Slider hpSlider;                      //체력바

    private float m_Horizontal;                                 //플레이어 방향
    private float m_Vertical;                                   //플레이어 방향    
    private bool flag;                                          //코루틴이 1번만 동작하도록
    private int color;                                          //플레이어 컬러 정보(0~3)
    private float time;                                         //플레이어가 얼마나 색을 유지할 것인지

    public Sprite[] spriteColor;

    private Rigidbody2D m_Rigidbody;
    //private Vector2 oldVector;
    private SpriteRenderer m_SpriteRenderer;
    private Transform m_Transform;
    private Vector3 m_StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 5f;
        m_Rigidbody = GetComponent<Rigidbody2D>();              //플레이어 충돌 체크, 이동
        m_SpriteRenderer = GetComponent<SpriteRenderer>();      //플레이어 색 변경
        m_Transform = GetComponent<Transform>();                //플레이어가 맵 밖으로 나가는 것을 방지하기 위해(position)
        //oldVector = new Vector2(0f, 0f);
        flag = false;
        m_StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hpSlider.value <= 0) {
            GameManager.gm.GameOver();
            gameObject.SetActive(false);
        }

        if (!flag) {
            //Debug.Log(transform.position);
            Change();
        }

        PlayerMove();
        ChangeRotate();
        ScreenCheck();
    }
    public void Change()
    {
        StartCoroutine(ChangeColor());

    }

    private IEnumerator ChangeColor()
    {
        flag = true;

        color = Random.Range(0, 3);
        time = Random.Range(5, 10);
        m_SpriteRenderer.sprite = spriteColor[color];
        yield return new WaitForSeconds(time);

        flag = false;
    }

    //플레이어 움직이기
    private void PlayerMove()
    {
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");
        m_Rigidbody.velocity = new Vector2(m_Horizontal, m_Vertical) * playerSpeed;
    }

    //플레이어 rotation 변경
    private void ChangeRotate()
    {
        //키가 입력될 때만 변경
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
            /*
            Vector2 nowVector = new Vector2(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y);
            m_Rigidbody.transform.right = Vector2.Lerp(oldVector, nowVector, 50f);
            oldVector = nowVector;
            */
            m_Rigidbody.transform.right = new Vector2(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y);
        }
    }

    //맵 밖으로 못나가게
    private void ScreenCheck()
    {
        if(this.transform.position.x < - 8.5f) {
            m_Transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.x > + 8.5f) { 
            m_Transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
        }
        if (this.transform.position.y < -4.6f) {
            m_Transform.position = new Vector3(transform.position.x, -4.6f, transform.position.z);
        }
        if (this.transform.position.y > 4.6f) {
            m_Transform.position = new Vector3(transform.position.x, 4.6f, transform.position.z);
        }
    }

    //MiniCircle이랑 충돌할 때
    public void OnTriggerEnter2D(Collider2D other)
    {
        //같은 색인 경우라면
        if(color == 0 && other.tag.Equals("greenMiniCircle")) {
            hpSlider.value += 0.01f;
            ScoreControl.currentScore += 3;
        }
        else if (color == 1 && other.tag.Equals("yellowMiniCircle")) {
            hpSlider.value += 0.01f;
            ScoreControl.currentScore += 3;
        }
        else if (color == 2 && other.tag.Equals("blueMiniCircle")) {
            hpSlider.value += 0.01f;
            ScoreControl.currentScore += 3;
        }
        else if (color == 3 && other.tag.Equals("redMiniCircle")) {
            hpSlider.value += 0.01f;
            ScoreControl.currentScore += 3;
        }
        //같은 색이 아니라면
        else {
            hpSlider.value -= 0.1f;
        }
        //MiniCircle 삭제
        Destroy(other.gameObject);
    }
}

