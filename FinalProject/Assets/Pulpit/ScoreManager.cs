using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    pulpitManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("pulpitManager")?.GetComponent<pulpitManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            manager.score++;
            Destroy(gameObject);
        }
    }
}
