using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBigCircle : MonoBehaviour
{
    public float m_Delay;

    private int m_Count;
    private bool flag;
    private int x, y;
    private int oldX, oldY;

    public GameObject circle;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        m_Count = 0;
        oldX = 0;
        oldY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag) {
            Wait();
        }
    }

    public void Wait()
    {
        StartCoroutine(Create());

    }

    private IEnumerator Create()
    {
        flag = true;
        float m = 0f;

        //이전의 BigCircle과 새로 생기는 BigCircle과의 x축 거리가 1.5이상 되도록 do while문으로 돌림

        do {
            //x의 범위는 맵의 가로축 범위

            x = UnityEngine.Random.Range(-8, 8);                                        
            m = Math.Abs(x) - Math.Abs(oldX);

        } while (m <= 1.5f && m >= -1.5f);

        //이전의 BigCircle과 새로 생기는 BigCircle과의 y축 거리가 1.5이상 되도록 do while문으로 돌림

        do {
            //y의 범위는 맵의 세로축 범위

            y = UnityEngine.Random.Range(-3, 3);                                        
            m = Math.Abs(y) - Math.Abs(oldY);

        } while (m <= 1.5f && m >= -1.5f);


        //새로 생긴 BigCircle의 위치 정보(x, y)를 oldX, oldY에 저장

        oldX = x;                                                                      
        oldY = y;

        //만들어진 (x, y)좌표에 BigCircle생성

        Instantiate(circle, new Vector3(x, y, 0f), Quaternion.identity);

        //생성 후 m_Delay시간 대기

        yield return new WaitForSeconds(m_Delay);


        //BigCircle이 3개 생성될 때마다 m_Delay를 10%낮춤
        //m_Delay는 최저 0.5의 값을 가짐

        if ((m_Count++) % 3 == 0 && m_Delay > 0.5f) {
            m_Delay -= m_Delay * 0.1f;
        }

        flag = false;
    }
}
