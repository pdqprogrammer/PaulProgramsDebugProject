using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PullableObject"))
        {
            Destroy(gameObject);
        }
    }
}
