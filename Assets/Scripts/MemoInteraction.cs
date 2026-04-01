using UnityEngine;
using TMPro;

public class MemoInteraction : MonoBehaviour
{
    // Inspector에서 연결할 MemoText UI
    public TextMeshProUGUI memoText;
    
    // 플레이어가 근처에 있는지 여부
    private bool playerNearby = false;

    // E키 안내 텍스트 (Inspector에서 연결)
    public TextMeshProUGUI promptText;

    void Start()
    {
        // 시작할 때 텍스트 숨기기
        memoText.gameObject.SetActive(false);

        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // 플레이어가 근처에 있고 E키를 누르면
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // 메모 텍스트 토글 (보이면 숨기고, 숨겨져 있으면 보이게)
            bool isActive = memoText.gameObject.activeSelf;
            memoText.gameObject.SetActive(!isActive);
        }
    }

    // 플레이어가 Trigger 영역에 들어왔을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (promptText != null)
                promptText.gameObject.SetActive(true); // "E키를 누르세요" 표시
        }
    }

    // 플레이어가 Trigger 영역에서 나갔을 때
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            memoText.gameObject.SetActive(false); // 메모 숨기기

            if (promptText != null)
                promptText.gameObject.SetActive(false); // 안내 텍스트 숨기기
        }
    }
}