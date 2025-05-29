using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Car CloneTarget = null;              // 차 프리팹
    public Transform GenerationPos = null;      // 차량 생성 위치

    public int GenerationPersent = 50;          // 차량 생성 확률, Random.Range()로 사용

    public float CloneDelaySec = 1f;            // 차량 생성 간격

    protected float NextSecToClone = 0f;        // 다음 생성까지 대기 시간
    

    private void Update()
    {
        float currSec = Time.time;      // 현재 시간을 초 단위로 가져옴, 현재 시간을 기준으로 차량을 주기적으로 생성
                                        // Time.time은 게임이 시작된 후 흘러간 시간
        if (NextSecToClone <= currSec)  // 현재 시간이 NextSecToClone보다 크거나 같다면, 차량을 복제할 시간
        {
            CloneCar();
            NextSecToClone = currSec + CloneDelaySec; // 차량을 복제하고, NextSecToClone을 다음 시간으로 업데이트
        }
    }

    void CloneCar()
    {
        Transform clonePos = GenerationPos;     // 복제 위치를 GenerationPos로 설정

        Vector3 offsetPos = clonePos.position;
        offsetPos.y = 1f;       // 지정된 위치에서 Y값을 1로 설정하여 차량을 복제

        GameObject cloneobj = GameObject.Instantiate
            (
            CloneTarget.gameObject,     // 복제할 프리팹
            offsetPos,                  // 위치
            GenerationPos.rotation,     // 회전 방향
            this.transform              // this.transform을 부모로 설정하여 Road 오브젝트 하위로 차량을 생성
            );

        cloneobj.SetActive(true);       // 생성한 객체를 활성화
    }
}
