using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
    }
}