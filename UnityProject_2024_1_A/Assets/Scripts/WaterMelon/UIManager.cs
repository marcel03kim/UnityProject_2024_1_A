using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestScoreText;

    private void OnEnable()       //Ȱ��ȭ ���°� �Ǹ� ȣ�� �Ǵ� �Լ�
    {
        GameManager.OnPointChanged += UpdatePoint;    //+= �̺�Ʈ ���
        GameManager.OnBestScoreChanged += UpdateBestScore;
    }

    private void OnDisable()         //��Ȱ��ȭ ���°� �Ǹ� ȣ�� �Ǵ� �Լ�
    {
        GameManager.OnPointChanged -= UpdatePoint;          //-= �̺�Ʈ ����
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
