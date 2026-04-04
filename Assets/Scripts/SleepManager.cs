using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SleepManager : MonoBehaviour
{
    // Inspector에서 연결
    public Image fadeImage;          // 검은 화면 페이드용
    public TextMeshProUGUI promptText; // "E키를 눌러 잠들기" 안내
    public MemoSystem memoSystem;    // 메모 업데이트용

    private bool playerNearby = false;
    private bool isSleeping = false;

    void Start()
    {
        if (promptText != null)
            promptText.gameObject.SetActive(false);

        // 페이드 이미지 투명하게 시작
        if (fadeImage != null)
            fadeImage.color = new Color(0, 0, 0, 0);
    }

    void Update()
    {
        if (playerNearby && !isSleeping && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Sleep());
        }
    }

    IEnumerator Sleep()
    {
        isSleeping = true;

        if (promptText != null)
            promptText.gameObject.SetActive(false);

        // 페이드 아웃 (화면 어두워짐)
        yield return StartCoroutine(Fade(0f, 1f, 1.5f));

        // 날짜 넘기기
        DayManager.Instance.NextDay();

        // 메모 텍스트 업데이트
        if (memoSystem != null)
            memoSystem.UpdateMemo();

        // 잠깐 대기
        yield return new WaitForSeconds(1f);

        // 페이드 인 (화면 밝아짐)
        yield return StartCoroutine(Fade(1f, 0f, 1.5f));

        isSleeping = false;
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, endAlpha);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (promptText != null)
                promptText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            if (promptText != null)
                promptText.gameObject.SetActive(false);
        }
    }
}