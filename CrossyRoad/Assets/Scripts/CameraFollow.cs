using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // ī�޶� ���� ��� (��: �÷��̾�)
    public float forwardSpeed = 1f;  // �ð��� ���� �����ϴ� �ӵ�
    private Vector3 offset;          // �ʱ� �Ÿ� ���� (ī�޶�� ��� ���� �Ÿ�)
    private float currentZ; // ���� ī�޶��� z��ġ

    void Start()
    {
        offset = transform.position - target.position;
        currentZ = transform.position.z;
    }

    void LateUpdate()
    {
        // �ð��� ���� ī�޶� z��ġ ����
        currentZ += forwardSpeed * Time.deltaTime;

        // Ÿ�� ��ġ�� �������� offset.z ��ŭ ������ ��ġ ���
        float targetZ = target.position.z + offset.z;

        // ī�޶� Ÿ�ٺ��� �� �ڿ� ������ ����, �׷��� ������ õõ�� ����
        float finalZ = Mathf.Max(currentZ, targetZ);

        transform.position = new Vector3(transform.position.x, transform.position.y, finalZ);
    }
}
