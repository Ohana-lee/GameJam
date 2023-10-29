using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    public Timer script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current time " + (int)Timer.currentTime);
        if ((int)Timer.currentTime % 5 == 0)
        {
            //collider.GetComponent<PlayerController>().enabled = false;
            QuestionMgr.Instance.Show(); //to call the popup questions
        }
    }
}
