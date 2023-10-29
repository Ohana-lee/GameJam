using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    private Rigidbody2D mycircle;
    public float speedx;
    public float speedy;
    public float maxheight;
    public bool up;

    private float dx, dy;
    // Start is called before the first frame update
    void Start()
    {
        mycircle = gameObject.GetComponent<Rigidbody2D>();
        up = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (up)
        {
            dx = transform.position.x + (speedx * Time.deltaTime);
            dy = transform.position.y + (speedy * Time.deltaTime);
            transform.position = new Vector3(dx, dy, 0);
        }
        if (mycircle.position.y >= maxheight)
        {
            up = false;
        }

        if (!up)
        {
            dx = transform.position.x + (speedx * Time.deltaTime);
            dy = transform.position.y - (speedy * Time.deltaTime);
            transform.position = new Vector3(dx, dy, 0);
        }

    }



    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}