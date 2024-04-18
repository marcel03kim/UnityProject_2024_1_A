using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
    Sequence sequence;
    Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        //Tween ����
        //tween = transform.DOMoveX(5, 2);  //X�� 5�� 2�ʵ��� �̵� ��Ŵ
        //transform.DORotate(new Vector3(0, 0, 180), 2); //Z������ 2�ʵ��� 180�� ȸ�� ��Ŵ
        //transform.DOScale(new Vector3(2, 2, 2), 2); //�� ������Ʈ�� 2�ʵ��� Scale�� 2�� Ű��

        //��ü �ּ� �� �ּ� ���� Ctrl + K + C, Ctrl + K + U

        //Sequence sequence = DOTween.Sequence();      //Tween�� �̾ ������� ���� �����ִ� ����
        //sequence.Append(transform.DOMoveX(5, 1));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 1));

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce);
        //transform.DOShakeRotation(0.5f, new Vector3(0, 0, 90), 10, 90);  //Z������ ȸ���� 90�� ���� 10, ���� 90���� ���� �ش�

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce).OnComplete(TweenEnd);  //Ʈ���� �Ϸ�Ǹ� TweenEnd �Լ� ȣ��

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(5, 1));
        sequence.SetLoops(-1, LoopType.Yoyo);      //Tween�� ������·� �ݺ�

    }

    void TweenEnd()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sequence.Kill();
            //tween.Kill();
        }
    }
}
