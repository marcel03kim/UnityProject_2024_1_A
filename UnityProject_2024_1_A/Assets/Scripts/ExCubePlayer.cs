using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;
    public int Count = 0;
    public int Power = 100;

    public int Point = 0;
    public float checkTime = 0.0f;
    public float checkEndTime = 30.0f;

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

        checkTime -= Time.deltaTime;

        if(checkEndTime <= 0)

        TextUI.text = Point.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero;
        }
    }
    void OntriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Items")
        {
            Point += 10;
            Destroy(other.gameObject);
        }
    }

}
