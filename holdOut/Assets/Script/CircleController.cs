using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public float m_Delay;       //

    private int x, y;
    private bool flag;

    public Sprite[] Color;
    public GameObject[] m_MiniCircle;

    private Vector3 m_Position;
    private SpriteRenderer m_SpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Position = gameObject.transform.position;
        flag = false;
        m_Delay = 1.0f;
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
        StartCoroutine(ChangeColor());

    }

    private IEnumerator ChangeColor()
    {
        flag = true;
        //m_Delay만큼 기달리고 오브젝트의 sprite변경

        yield return new WaitForSeconds(m_Delay);
        m_SpriteRenderer.sprite = Color[0];
        yield return new WaitForSeconds(m_Delay);
        m_SpriteRenderer.sprite = Color[1];
        yield return new WaitForSeconds(m_Delay);
        Destroy(gameObject);


        //2중 for문으로 8개의 MiniCircle 생성
        for(int j = 0; j < 2; j++) {
            for (int i = 0; i < 4; i++) {
                Instantiate(m_MiniCircle[i], transform.position, Quaternion.identity);
            }
        }
        
        flag = false;
    }
}
