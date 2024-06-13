using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddProgress(string achievementName, int amount)
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName); //해당 이름이 있는 업적을 리스트에서 찾아서 가져온다
        if (achievement != null)
        {
            achievement.AddProgress(amount);   //찾은 업적의 횟수를 카운팅 한다
        }
    }
}
