using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject nearPullObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            PlayerLift();
        }

        if (Input.GetButtonUp("Grab"))
        {
            PlayerRelease();
        }
    }

    private void PlayerLift()
    {
        if (nearPullObject != null)
        {
            nearPullObject.transform.parent = this.transform;
            nearPullObject.GetComponent<Rigidbody>().useGravity = false;
            nearPullObject.transform.localPosition = Vector3.zero;
        }
    }

    private void PlayerRelease()
    {
        if (nearPullObject != null)
        {
            nearPullObject.GetComponent<Rigidbody>().useGravity = true;
            nearPullObject.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if touching pullable object
        if (other.gameObject.tag.Equals("PullableObject"))
        {
            if (nearPullObject == null)
            {
                nearPullObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //check if not touching pullable object when not pulling
        if (other.gameObject == nearPullObject)
        {
            nearPullObject.GetComponent<Rigidbody>().useGravity = true;
            nearPullObject.transform.parent = null;
            nearPullObject = null;
        }
    }
}
