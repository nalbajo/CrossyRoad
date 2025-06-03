using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �÷��̾� �̵� ����
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

    [SerializeField] Raft RaftObject;
    [SerializeField] Transform RaftCompareObj;

    public Rigidbody rigid;

    public Vector3 targetPos; // ��ǥ ��ġ
    public Vector3 RaftPos = Vector3.zero;

    private void Start()
    {
        transform.position = targetPos; // ���� ��ġ = ��ǥ ��ġ
    }

    protected void InputUpdate()
    {
        // Ű�� �� �� ������ �����ؾ� ���� �� �ְ�
        // ������ġ�� ��ǥ ��ġ�� ������ Ű�� ���� �� ����
        if (transform.position == targetPos)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                targetPos += Vector3.forward * moveDistance;
                Debug.Log("��");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                targetPos += Vector3.back * moveDistance;
                Debug.Log("��");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                targetPos += Vector3.left * moveDistance;
                Debug.Log("����");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                targetPos += Vector3.right * moveDistance;
                Debug.Log("������");
            }
        }
        // �������� �̵���Ű��
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }

    private Vector3 lastRaftPosition;

    protected void UpdateRaft()
    {
        if (RaftObject == null)
            return;

        Vector3 currentRaftPos = RaftObject.transform.position;
        Vector3 delta = currentRaftPos - lastRaftPosition;

        
        // �÷��̾ �����̰� �ִ� �����̶�� �̵� ��� ��ǥ(targetPos)���� Raft�� �̵��� ������
        targetPos += delta;
        transform.position += delta; // �¸��� ������ ��ŭ �÷��̾ ������
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

        Debug.Log($"[Trigger] �浹�� ������Ʈ: {other.name}");
        Debug.Log($"[Trigger] ������Ʈ �±�: {other.tag}");
        Debug.Log($"[Trigger] �θ� ������Ʈ: {other.transform.parent?.name}");
        Debug.Log($"[Trigger] Raft ������Ʈ�� �θ� �ֳ�? {(other.transform.parent?.GetComponent<Raft>() != null)}");


        if (other.tag.Contains("Raft"))
        {
            Debug.Log("[Trigger] Raft!");
            Raft raft = other.GetComponent<Raft>();
            if (raft == null)
                raft = other.GetComponentInParent<Raft>();
            if (raft == null)
                raft = other.GetComponentInChildren<Raft>();

            if (RaftObject != null)
            {
                Debug.Log("[Trigger] RaftComponent �����");
                RaftCompareObj = RaftObject.transform;
                RaftPos = this.transform.position - RaftObject.transform.position;
                lastRaftPosition = RaftObject.transform.position; // ž�� �� ��ġ ���
            }
            else
            {
                Debug.LogWarning("RaftComponent�� ã�� �� ����!");
            }
            Debug.Log($"���� : {other.name}, {RaftPos}");
            return;
        }

        if (other.tag.Contains("Crash"))
        {
            Debug.Log("�浹");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"OntriggerEnter : {other.name}, {other.tag}");

        if (other.tag.Contains("Crash") && RaftCompareObj == other.transform.parent)
        {
            Debug.Log("�浹");
            RaftCompareObj = null;
            RaftObject = null;
            RaftPos = Vector3.zero;
        }
    }

}
