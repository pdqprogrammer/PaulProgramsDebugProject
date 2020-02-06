using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakspotScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(transform.parent.gameObject);
            Debug.Log("Enemy Dead");
        }
    }
}
