using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 — Inspector에서 숫자 바꿀 수 있어
    private Rigidbody2D rb;      // Rigidbody2D 컴포넌트를 담아둘 변수
    private Vector2 moveInput;   // 이동 방향을 담아둘 변수

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작할 때 Rigidbody2D를 자동으로 찾아서 연결
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 키보드 입력 읽기
        // WASD 또는 방향키 자동 인식
        float moveX = Input.GetAxisRaw("Horizontal"); // 좌우
        float moveY = Input.GetAxisRaw("Vertical");   // 상하

        moveInput = new Vector2(moveX, moveY).normalized; // .normalized = 대각선 이동할 때 속도가 빨라지는 걸 방지
        
    }

    void FixedUpdate()
    {
        // 물리 이동은 FixedUpdate에서 처리 (더 안정적)
        rb.velocity = moveInput * moveSpeed;
    }
}
