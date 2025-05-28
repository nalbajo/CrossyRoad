using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // �÷��̾� �̵� ����
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;

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
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetPos += Vector3.forward * moveDistance;
                Debug.Log("��");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetPos += Vector3.back * moveDistance;
                Debug.Log("��");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPos += Vector3.left * moveDistance;
                Debug.Log("����");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPos += Vector3.right * moveDistance;
                Debug.Log("������");
            }
        }
        // �������� �̵���Ű��
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
