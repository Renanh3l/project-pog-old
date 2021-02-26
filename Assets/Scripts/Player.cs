using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public float speed = 2f;
    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float input_x = Input.GetAxis("Horizontal");
            float input_y = Input.GetAxis("Vertical");

            NetworkAnimator playerAnimator = GetComponent<NetworkAnimator>();
            bool isMoving = input_x != 0 || input_y != 0;
            
            if (isMoving)
            {
                Vector3 movement = new Vector3(input_x, input_y, 0).normalized;
                transform.position += movement * speed * Time.deltaTime;
                playerAnimator.animator.SetFloat("input_x", input_x);
                playerAnimator.animator.SetFloat("input_y", input_y);
            }
            
            playerAnimator.animator.SetBool("isMoving", isMoving);
        }
    }

    void Update()
    {
        HandleMovement();
    }
    

}
