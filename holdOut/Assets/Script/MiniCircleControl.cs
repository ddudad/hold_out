using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCircleControl : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    //MiniCircle이 이동할 위치
    private int tx, ty;                         
    private float circleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        tx = 0; 
        ty = 0;

        //이동할 위치
        //tx, ty가 0이 나오면 다시 랜덤하게 뽑음
        do {
            tx = Random.Range(-10, 10);
        } while (tx == 0);

        do {
            ty = Random.Range(-5, 5);
        } while (ty == 0);

        circleSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //이동할 위치벡터를 방향벡터로 바꾼 후 speed를 곱해 그 방향으로 쭉 나가게 함.
        m_Rigidbody.velocity = new Vector2(tx, ty).normalized * circleSpeed;
    }

    //MiniCircle 삭제
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("checkOut")) {
            Destroy(gameObject);
            ScoreControl.currentScore++;
        }
    }
}
