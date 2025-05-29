using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Car CloneTarget = null;              // �� ������
    public Transform GenerationPos = null;      // ���� ���� ��ġ

    public int GenerationPersent = 50;          // ���� ���� Ȯ��, Random.Range()�� ���

    public float CloneDelaySec = 1f;            // ���� ���� ����

    protected float NextSecToClone = 0f;        // ���� �������� ��� �ð�
    

    private void Update()
    {
        float currSec = Time.time;      // ���� �ð��� �� ������ ������, ���� �ð��� �������� ������ �ֱ������� ����
                                        // Time.time�� ������ ���۵� �� �귯�� �ð�
        if (NextSecToClone <= currSec)  // ���� �ð��� NextSecToClone���� ũ�ų� ���ٸ�, ������ ������ �ð�
        {
            CloneCar();
            NextSecToClone = currSec + CloneDelaySec; // ������ �����ϰ�, NextSecToClone�� ���� �ð����� ������Ʈ
        }
    }

    void CloneCar()
    {
        Transform clonePos = GenerationPos;     // ���� ��ġ�� GenerationPos�� ����

        Vector3 offsetPos = clonePos.position;
        offsetPos.y = 1f;       // ������ ��ġ���� Y���� 1�� �����Ͽ� ������ ����

        GameObject cloneobj = GameObject.Instantiate
            (
            CloneTarget.gameObject,     // ������ ������
            offsetPos,                  // ��ġ
            GenerationPos.rotation,     // ȸ�� ����
            this.transform              // this.transform�� �θ�� �����Ͽ� Road ������Ʈ ������ ������ ����
            );

        cloneobj.SetActive(true);       // ������ ��ü�� Ȱ��ȭ
    }
}
