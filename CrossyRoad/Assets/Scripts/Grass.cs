using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public List<Transform> EnvirmentObjectList = new List<Transform>();
    public int StartMinVal = -6;
    public int StartMaxVal = 6;

    public int SpawnCreateRandom = 50;

    public void GeneratorEnvirment()
    {
        int randomindex = 0;
        int randomval = 0;
        GameObject tempclone;
        Vector3 offsetpos = Vector3.zero;
        for (int i = StartMinVal; i < StartMaxVal; ++i)
        {
            randomval = Random.Range(0, 100);
            if (randomval < SpawnCreateRandom)
            {
                randomindex = Random.Range(0, EnvirmentObjectList.Count);
                tempclone = GameObject.Instantiate(EnvirmentObjectList[randomindex].gameObject);
                tempclone.SetActive(true);
                offsetpos.Set(i, 1f, 0f);

                tempclone.transform.SetParent(this.transform);
                tempclone.transform.localPosition = offsetpos;
            }
        }
    }

    private void Start()
    {
        GeneratorEnvirment();
    }
}
