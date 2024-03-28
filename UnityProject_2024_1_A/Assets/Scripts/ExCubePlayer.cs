using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;
    public int Count = 0;
    public int Power = 100;

    public int Point = 0;
    public float checkTime = 0.0f;

    public Rigidbody m_Rigidbody;

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;           //�ð��� �����ؼ� �״´�
        if (checkTime >= 1.0f)                 //1�ʸ��� � �ൿ�� �Ѵ� 
        {
            Point += 1;                          //1�ʸ��� ������ 1�� �ø���
            checkTime = 0.0f;                   //�ð��� �ʱ�ȭ �Ѵ�
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Power = Random.Range(100, 200);
            m_Rigidbody.AddForce(transform.up * Power);
        }

        TextUI.text = Point.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        Point = 0;
        gameObject.transform.position = Vector3.zero;
    }
}
