using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastScript : MonoBehaviour
{
    Vector3 illegalSpawnLocation;

    public bool canSpawn(Vector3 location)
    {
        if (location == illegalSpawnLocation)
            return false;
        else
            return true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pulpit")
        {
            illegalSpawnLocation = other.gameObject.transform.position;
        }
    }
}
