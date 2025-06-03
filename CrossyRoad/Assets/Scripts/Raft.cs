using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float RangeDestroy = 12;

    void Update()
    {
        float movex = MoveSpeed * Time.deltaTime;
        transform.position += new Vector3(movex, 0f, 0f);

        if (this.transform.position.x >= RangeDestroy)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
