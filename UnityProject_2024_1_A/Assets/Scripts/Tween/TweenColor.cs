using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //�����̽��� ������ �� 
        {
            Color color = new Color(Random.value, Random.value, Random.value);  //���� ���� ȣ��

            renderer.material.DOColor(color, 1f)          //���������� 1�� �Ŀ� ����
                .SetEase(Ease.InOutQuad);              

            renderer.material.DOPlay();                    //���� Ʈ���� �Ѳ����� ���� 
        }
    }
}
