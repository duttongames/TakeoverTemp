using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);
    }
}
