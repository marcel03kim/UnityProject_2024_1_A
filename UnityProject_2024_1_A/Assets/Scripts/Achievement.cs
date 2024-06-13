using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  //Ŭ��������ȭ
public class Achievement
{
    public string name;
    public string description;
    public bool isUnlocked;
    public int currentProgress;
    public int goal;


    //������ �Լ� (New ���ؼ� ���� �� �� �߷� �Ķ���� ���� �־��ָ� ���� �� �ʱ�ȭ �ȴ�)
    public Achievement(string name, string description, int goal)
    {
        this.name = name;                 //���� �̸��� �μ��� �޾ƿ´�
        this.description = description;       //���� ������ �μ��� �޾ƿ´�
        this.isUnlocked = false;                   //�Ϸ� X
        this.currentProgress = 0;           //�ʱⰪ 0
        this.goal = goal;                      //�Ϸᰪ�� �μ��� �޾ƿ´�
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

    protected virtual void OnAchievementUnlocked()     //��ȣ���ذ� �����Լ�(virtual)ó���� �ؼ� ��� �� �Լ��� ���� �� �� �ְ� ����
    {
        Debug.Log($"���� �޼�: {name}");
    }
}
