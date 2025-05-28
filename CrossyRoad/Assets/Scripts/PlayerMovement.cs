using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어 이동 구현
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

    public Vector3 targetPos; // 목표 위치

    private void Start()
    {
        transform.position = targetPos; // 현재 위치 = 목표 위치
    }
    private void Update()
    {
        // 키를 한 번 누르고 도착해야 누를 수 있게
        // 현재위치와 목표 위치가 같으면 키를 누를 수 있음
        if (transform.position == targetPos)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetPos += Vector3.forward * moveDistance;
                Debug.Log("앞");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetPos += Vector3.back * moveDistance;
                Debug.Log("뒤");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPos += Vector3.left * moveDistance;
                Debug.Log("왼쪽");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPos += Vector3.right * moveDistance;
                Debug.Log("오른쪽");
            }
        }
        // 목적지로 이동시키기
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
