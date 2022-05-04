using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointNew : MonoBehaviour
{ 
    public GameObject obstacle;

    // Canavarın sahnemize ilk getirilişi.
    void Start()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }
    
}
