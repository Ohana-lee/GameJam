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
    public bool workDone, a, b, c, d;

    // Start is called before the first frame update
    void Start()
    {
        workDone = false;
        a = false;
        b = false;
        c = false;
        d = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bugSpawner.bug.GetComponent<ClickBug>().bugKilled) { KCount = KCount + 1; }
        if (questionpanel.QCount == 1) { tick1.SetActive(true); a = true; }
        if (questionpanel.QCount == 2) { tick2.SetActive(true); b = true; }
        if (questionpanel.QCount == 3) { tick3.SetActive(true); c = true; }
        if (questionpanel.QCount == 4) { tick4.SetActive(true); d = true; }
        //Debug.Log("bug killed: " + KCount);
        //Debug.Log("bug killed: " + KCount);
        if (a && b && c && d)
        {
            workDone = true;
        }
    }
}
