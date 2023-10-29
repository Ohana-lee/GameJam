using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BugMovement : MonoBehaviour
{

    public float speed = 10;
    private Vector3 targetPos;
    Vector3 startPos, currPos;
    public bool LHS;
    private float dist;
    // public void ProjectileMovement(bool LHS){
    //     this.LHS = LHS;
    // }

    void Start()
    {
        startPos = transform.position;
        currPos = transform.position;
        // targetPos should be between the currPos' x and LHS (0)
        targetPos = new Vector3(Random.Range(transform.position.x, 0), Random.Range(1, 6), 0);
    }

    void Update()
    {
        Vector3 nextPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.rotation = LookAt2D(nextPos - startPos);
        transform.position = nextPos;

        // Do something when we reach the target
        if (nextPos == targetPos)
        {

            /*if (LHS)
                dist = 5;
            else
                dist = -5;
            targetPos = new Vector3(transform.position.x + dist, -5, 0);
            nextPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            // Rotate to face the next position, and then move there
            transform.rotation = LookAt2D(nextPos - transform.position);
            transform.position = nextPos;*/
        }
    }

    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}