using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    public Text TextUI = null;
    public int Count = 0;
    public int Power = 100;
    public Rigidbody m_Rigidbody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Count += 1;
            TextUI.text = Count.ToString();
            Power = Random.Range(100, 200);
            m_Rigidbody.AddForce(transform.up * Power);
        }

        if(gameObject.transform.position.y >= 2 || gameObject.transform.position.y >= -2)
        {
            TextUI.text = "½ÇÆÐ";
            Count = 0;
        }
    }
}
