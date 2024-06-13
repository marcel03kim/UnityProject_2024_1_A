using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //클래스직열화
public class Achievement
{
    public string name;
    public string description;
    public bool isUnlocked;
    public int currentProgress;
    public int goal;


    //생성자 함수 (New 통해서 생성 될 때 솬련 파라미터 값을 넣어주면 생성 시 초기화 된다)
    public Achievement(string name, string description, int goal)
    {
        this.name = name;                 //업적 이름을 인수로 받아온다
        this.description = description;       //업정 설명값을 인수로 받아온다
        this.isUnlocked = false;                   //완료 X
        this.currentProgress = 0;           //초기값 0
        this.goal = goal;                      //완료값을 인수로 받아온다
    }

    public void AddProgress(int amount)
    {
        if(!isUnlocked)
        {
            currentProgress += amount;
            
            if(currentProgress >= goal)
            {
                isUnlocked = true;
                OnAchievementUnlocked();
            }
        }
    }

    protected virtual void OnAchievementUnlocked()     //보호수준과 가상함수(virtual)처리를 해서 상속 시 함수를 갱신 할 수 있게 선언
    {
        Debug.Log($"업적 달성: {name}");
    }
}
