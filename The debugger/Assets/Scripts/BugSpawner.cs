using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject buggy;
    [SerializeField] Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Are you ever here?");
        //while (Timer.currentTime > 0)
        //{
            //Debug.Log("Are you ever here?");
            InvokeRepeating("Spawn", 0.0f, .6f);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        //Debug.Log("Are you ever here?");
        Instantiate(buggy, transform.position, transform.rotation);
    }
}
