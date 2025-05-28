using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] public float MoveSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        float movex = MoveSpeed * Time.deltaTime;
        this.transform.Translate(movex, 0f, 0f);
        


    }
}
