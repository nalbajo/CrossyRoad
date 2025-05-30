using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform CloneTarget;               // �� ������
    public Transform GenerationPos;             // ���� ���� ��ġ

    public int GenerationPersent = 50;          // ���� ���� Ȯ��, Random.Range()�� ���

    public float CloneDelaySec = 1f;            // ���� ���� ����

    protected float NextSecToClone = 0f;        // ���� �������� ��� �ð�


    private void Update()
    {
        float currSec = Time.time;      // ���� �ð��� �� ������ ������, ���� �ð��� �������� ������ �ֱ������� ����
                                        // Time.time�� ������ ���۵� �� �귯�� �ð�
        if (NextSecToClone <= currSec)  // ���� �ð��� NextSecToClone���� ũ�ų� ���ٸ�, ������ ������ �ð�
        {
            int randomval = Random.Range(0, 100);
            if(randomval <= GenerationPersent)
            {
                CloneCar();
            }
            NextSecToClone = currSec + CloneDelaySec; // ������ �����ϰ�, NextSecToClone�� ���� �ð����� ������Ʈ
        }
    }

    void CloneCar()
    {
        Transform clonePos = GenerationPos;     // ���� ��ġ�� GenerationPos�� ����

        Vector3 offsetPos = GenerationPos.position;

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
