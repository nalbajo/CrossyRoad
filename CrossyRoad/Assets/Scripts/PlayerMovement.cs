using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어 이동 구현
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

    [SerializeField] Raft RaftObject;
    [SerializeField] Transform RaftCompareObj;

    public Rigidbody rigid;

    public Vector3 targetPos; // 목표 위치
    public Vector3 RaftPos = Vector3.zero;

    private void Start()
    {
        transform.position = targetPos; // 현재 위치 = 목표 위치
    }

    protected void InputUpdate()
    {
        // 키를 한 번 누르고 도착해야 누를 수 있게
        // 현재위치와 목표 위치가 같으면 키를 누를 수 있음
        if (transform.position == targetPos)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                targetPos += Vector3.forward * moveDistance;
                Debug.Log("앞");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                targetPos += Vector3.back * moveDistance;
                Debug.Log("뒤");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                targetPos += Vector3.left * moveDistance;
                Debug.Log("왼쪽");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                targetPos += Vector3.right * moveDistance;
                Debug.Log("오른쪽");
            }
        }
        // 목적지로 이동시키기
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }

    private Vector3 lastRaftPosition;

    protected void UpdateRaft()
    {
        if (RaftObject == null)
            return;

        Vector3 currentRaftPos = RaftObject.transform.position;
        Vector3 delta = currentRaftPos - lastRaftPosition;

        
        // 플레이어가 움직이고 있는 도중이라면 이동 대상 좌표(targetPos)에도 Raft의 이동을 더해줌
        targetPos += delta;
        transform.position += delta; // 뗏목이 움직인 만큼 플레이어도 움직임
        lastRaftPosition = currentRaftPos;
    }

    private void Update()
    {
        InputUpdate();
        UpdateRaft();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OntriggerEnter : {other.name}, {other.tag}");

        Debug.Log($"[Trigger] 충돌된 오브젝트: {other.name}");
        Debug.Log($"[Trigger] 오브젝트 태그: {other.tag}");
        Debug.Log($"[Trigger] 부모 오브젝트: {other.transform.parent?.name}");
        Debug.Log($"[Trigger] Raft 컴포넌트가 부모에 있나? {(other.transform.parent?.GetComponent<Raft>() != null)}");


        if (other.CompareTag("Raft")) // tag 비교는 Contains보다 CompareTag가 성능과 안정성 면에서 좋음
        {
            RaftObject = other.GetComponent<Raft>()
                      ?? other.GetComponentInParent<Raft>()
                      ?? other.GetComponentInChildren<Raft>();

            if (RaftObject == null)
            {
                Debug.LogWarning("Raft 컴포넌트를 찾을 수 없습니다.");
                return;
            }

            RaftCompareObj = RaftObject.transform;
            RaftPos = this.transform.position - RaftObject.transform.position;
            lastRaftPosition = RaftObject.transform.position; // 뗏목 위에 탔을 때 위치 저장
            Debug.Log($"탔다 : {other.name}, {RaftPos}");
        }

        if (other.tag.Contains("Crash"))
        {
            Debug.Log("충돌");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"OntriggerEnter : {other.name}, {other.tag}");

        if (other.tag.Contains("Crash") && RaftCompareObj == other.transform.parent)
        {
            Debug.Log("충돌");
            RaftCompareObj = null;
            RaftObject = null;
            RaftPos = Vector3.zero;
        }
    }

}
