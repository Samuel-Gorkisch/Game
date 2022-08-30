using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed = 5f;
        
    public Rigidbody2D player;

    private Vector2 movement;
   
    // Update is called once per frame
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        player.MovePosition(player.position + movement.normalized * moveSpeed * Time.fixedDeltaTime); 
    }
}
