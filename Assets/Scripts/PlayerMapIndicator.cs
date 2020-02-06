using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(GameObject))]
public class PlayerMapIndicator : MonoBehaviour
{
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerObject.transform.position;
        playerPos.y = gameObject.transform.position.y;

        transform.position = Vector3.Lerp(transform.position, playerPos, 1.0f);
    }
}
