using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] ObjectArray;
    public Transform ParentTransform;

    public int MinPosZ = -20;
    public int MaxPosZ = 20;

    private void Start()
    {
        for(int i = MinPosZ; i < MaxPosZ; ++i)
        {
            CloneRoad(i);
        }
    }
    public void CloneRoad(int p_posz)
    {
        int randomindex = Random.Range(0, ObjectArray.Length);
        GameObject cloneobj = GameObject.Instantiate(ObjectArray[randomindex]);

        Vector3 offsetpos = Vector3.zero;
        offsetpos.z = (float)p_posz;

        cloneobj.transform.SetParent(ParentTransform);
        cloneobj.transform.position = offsetpos;

        int randomrot = Random.Range(0, 2);
        if(randomrot == 1)
        {
            cloneobj.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
