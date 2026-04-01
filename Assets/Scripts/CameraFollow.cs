using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 따라갈 대상 (Player)
    public Transform target;

    // 카메라가 얼마나 부드럽게 따라올지 (숫자 클수록 딱딱하게 따라옴)
    public float smoothSpeed = 5f;

    // 카메라 Z축 고정값 (2D에서 카메라는 항상 -10)
    private float fixedZ = -10f;

    void LateUpdate()
    {
        if (target == null) return;

        // 목표 위치 = 플레이어 위치, Z는 고정
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, fixedZ);

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}