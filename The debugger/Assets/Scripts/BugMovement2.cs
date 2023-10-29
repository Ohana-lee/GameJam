using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement2 : MonoBehaviour
{
    [SerializeField] GameObject Buggy;
    //[SerializeField] float secondSpawn = 2f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] Vector3 force;
    //public Timer timer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<spriteRenderer>();
        //spriteRenderer.sprite = Buggy;
        transform.position = new Vector3(Random.Range(minTras, maxTras), transform.position.y, transform.position.z);
        force = new Vector3(Random.Range(-100, 100), Random.Range(150, 250), 0);
        rb.AddForce(force);
        //StartCoroutine(BugSpawn());
    }

    /*public IEnumerator BugSpawn()
    {
        Debug.Log("current time " + (int)Timer.currentTime);
        while (Timer.currentTime > 0)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(Buggy, position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }*/

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnder2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall") { Destroy(this.gameObject); }
    }
}
