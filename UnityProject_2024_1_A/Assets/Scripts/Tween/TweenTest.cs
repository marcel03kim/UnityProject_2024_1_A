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
        //Tween 단위
        //tween = transform.DOMoveX(5, 2);  //X축 5로 2초동안 이동 시킴
        //transform.DORotate(new Vector3(0, 0, 180), 2); //Z축으로 2초동안 180도 회전 시킴
        //transform.DOScale(new Vector3(2, 2, 2), 2); //이 오브젝트를 2초동안 Scale을 2로 키움

        //전체 주석 및 주석 해제 Ctrl + K + C, Ctrl + K + U

        //Sequence sequence = DOTween.Sequence();      //Tween을 이어서 순서대로 실행 시켜주는 단위
        //sequence.Append(transform.DOMoveX(5, 1));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 1));
        //sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 1));

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce);
        //transform.DOShakeRotation(0.5f, new Vector3(0, 0, 90), 10, 90);  //Z축으로 회전을 90도 강도 10, 랜덤 90으로 힘을 준다

        //transform.DOMoveX(5, 2).SetEase(Ease.OutBounce).OnComplete(TweenEnd);  //트윈이 완료되면 TweenEnd 함수 호출

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(5, 1));
        sequence.SetLoops(-1, LoopType.Yoyo);      //Tween을 요요형태로 반복

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
