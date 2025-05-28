using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // 카메라가 따라갈 대상 (예: 플레이어)
    public float forwardSpeed = 1f;  // 시간에 따라 전진하는 속도
    private Vector3 offset;          // 초기 거리 차이 (카메라와 대상 간의 거리)
    private float currentZ; // 현재 카메라의 z위치

    void Start()
    {
        offset = transform.position - target.position;
        currentZ = transform.position.z;
    }

    void LateUpdate()
    {
        // 시간에 따라 카메라 z위치 증가
        currentZ += forwardSpeed * Time.deltaTime;

        // 타겟 위치를 기준으로 offset.z 만큼 떨어진 위치 계산
        float targetZ = target.position.z + offset.z;

        // 카메라가 타겟보다 더 뒤에 있으면 따라감, 그렇지 않으면 천천히 전진
        float finalZ = Mathf.Max(currentZ, targetZ);

        transform.position = new Vector3(transform.position.x, transform.position.y, finalZ);
    }
}
