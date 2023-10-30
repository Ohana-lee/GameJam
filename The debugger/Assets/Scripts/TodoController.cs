using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoController : MonoBehaviour
{

    public BugSpawner bugSpawner;
    public ClickBug clickbug;
    public QuestionPanel questionpanel;
    public int KCount = 0;
    public bool bugKilled;
    public GameObject tick1, tick2, tick3, tick4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bugSpawner.bug.GetComponent<ClickBug>().bugKilled) { KCount = KCount + 1; }
        if (KCount == 10) { tick1.SetActive(true); }
        if (KCount == 15) { tick2.SetActive(true); }
        if (questionpanel.QCount == 1) { tick3.SetActive(true); }
        if (questionpanel.QCount == 3) { tick4.SetActive(true); }
        //Debug.Log("bug killed: " + KCount);
        //Debug.Log("bug killed: " + KCount);
    }
}
