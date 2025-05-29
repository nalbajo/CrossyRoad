using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �÷��̾� �̵� ����
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

    public Rigidbody rigid;

    public Vector3 targetPos; // ��ǥ ��ġ

    private void Start()
    {
        transform.position = targetPos; // ���� ��ġ = ��ǥ ��ġ
    }
    private void Update()
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OntriggerEnter : {other.name}, {other.tag}");
        if (other.tag.Contains("Crash"))
        {
            Debug.Log("�浹");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

}
