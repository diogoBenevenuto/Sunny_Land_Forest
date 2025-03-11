using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{

    public float offSetX = 3f, smooth = 0.1f, limitedUp = 2f, limitedDown = 0f, limitedLeft = 0f, limitedRight = 100f;

    private Transform player;
    private float playerX, playerY;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    
    void FixedUpdate()
    {
        if(player != null)
        {
            playerX = Mathf.Clamp(player.position.x + offSetX, limitedLeft, limitedRight);
            playerY = Mathf.Clamp(player.position.y, limitedDown, limitedUp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth);

        }

    }
}
