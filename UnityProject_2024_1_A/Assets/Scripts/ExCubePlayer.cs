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
        checkTime += Time.deltaTime;           //시간을 누적해서 쌓는다
        if (checkTime >= 1.0f)                 //1초마다 어떤 행동을 한다 
        {
            Point += 1;                          //1초마다 점수를 1점 올린다
            checkTime = 0.0f;                   //시간을 초기화 한다
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Power = Random.Range(100, 200);
            m_Rigidbody.AddForce(transform.up * Power);
        }

        checkTime -= Time.deltaTime;

        if(checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultSene");
        }

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
