using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnTrigger : MonoBehaviour
{

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == triggeringTag && enabled)
        {
            // destory both
            Destroy(other.gameObject);
            Destroy(gameObject);


        }
    }
}
