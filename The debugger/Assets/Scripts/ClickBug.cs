using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBug : MonoBehaviour
{

    //[SerializeField] EventManager eventManager;
    private BugMovement bugMovement;
    public TodoController todocontroller;
    public float volume;
    public bool bugKilled;
    //public int KCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        //bugMovement = this.GetComponent<bugMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(this.gameObject, 3);
       /* if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked on projectile");

            //eventManager.ExecuteEvent(bugMovement.projectileCode, this.transform.position);

            Destroy(this.gameObject);
        }*/
    }

    void OnMouseDown()
    {
        Debug.Log("clicked on projectile");
        

        //eventManager.ExecuteEvent(bugMovement.projectileCode, this.transform.position);

        Destroy(this.gameObject);
        //todocontroller.bugKilled = true;
        bugKilled = true;
    }
}