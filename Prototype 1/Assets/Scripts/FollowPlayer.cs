using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Variables
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -8.44f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after the update method and is used to prevent delay
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
