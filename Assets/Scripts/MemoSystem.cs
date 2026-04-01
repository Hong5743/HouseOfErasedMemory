using UnityEngine;
using TMPro;

public class MemoSystem : MonoBehaviour
{
    // Inspector에서 MemoText 오브젝트 연결할 거야
    public TextMeshProUGUI memoText;

    // 날짜별 메모 텍스트 (1일차~7일차)
    private string[] dayVersions = new string[]
    {
        "오늘도 숙면을 취했다.",           // 1일차
        "오늘도 숙면을 취했다...",           // 2일차 (같아 보이지만...)
        "오늘도 숙면을 취했다. ",          // 3일차 (공백 하나 추가 — 플레이어는 모름)
        "오늘도 숙면을 취했다.",           // 4일차
        "오늘도 숙면을 취했다.",           // 5일차
        "오늘도 숙면을 취했 다.",          // 6일차 (띄어쓰기 위치 바뀜)
        "오늘도 숙면을 취했다.",           // 7일차 (다시 정상 — 더 섬뜩)
    };

    void Start()
    {
        UpdateMemo();
    }

    public void UpdateMemo()
    {
        // DayManager에서 현재 날짜 가져와서 해당 텍스트 표시
        int day = DayManager.Instance.currentDay;
        memoText.text = dayVersions[day - 1]; // 배열은 0부터 시작이라 -1
    }
}