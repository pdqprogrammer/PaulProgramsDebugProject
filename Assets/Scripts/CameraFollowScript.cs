using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class CameraFollowScript : MonoBehaviour
{
    Vector3 camOffset;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 1.0f) + camOffset;
    }
}
