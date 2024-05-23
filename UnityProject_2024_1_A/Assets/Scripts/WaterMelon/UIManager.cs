using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestScoreText;

    private void OnEnable()       //활성화 상태가 되면 호출 되는 함수
    {
        GameManager.OnPointChanged += UpdatePoint;    //+= 이벤트 등록
        GameManager.OnBestScoreChanged += UpdateBestScore;
    }

    private void OnDisable()         //비활성화 상태가 되면 호출 되는 함수
    {
        GameManager.OnPointChanged -= UpdatePoint;          //-= 이벤트 삭제
        GameManager.OnBestScoreChanged -= UpdateBestScore;
    }

    void UpdatePoint(int newPoint)
    {
        pointText.text = "Point : " + newPoint;
    }
    void UpdateBestScore(int newBestScore)
    {
        bestScoreText.text = "BestScore : " + newBestScore;
    }
}
