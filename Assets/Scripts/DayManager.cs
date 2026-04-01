using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    // 싱글톤: 게임 어디서든 DayManager.Instance로 접근 가능
    public static DayManager Instance;

    // 현재 날짜 (1~7)
    public int currentDay = 1;

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 다음 날로 넘어가는 함수 (나중에 호출할 거야)
    public void NextDay()
    {
        if (currentDay < 7)
        {
            currentDay++;
            Debug.Log("현재 날짜: " + currentDay + "일차");
        }
    }
}
