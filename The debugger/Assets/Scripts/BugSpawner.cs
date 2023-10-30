using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] GameObject buggy;
    [SerializeField] Timer timer;
    public GameObject Desktop;
    public Camera camera;
    public AudioSource audioSource;
    public AudioClip ErrorMusic;
    public AudioClip GlitchMusic;
    public float volume;
    public GameObject bug;
    List<GameObject> list = new List<GameObject>();
    private int numberOfBugs;
    //private int i = 6;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Are you ever here?");
        //while (Timer.currentTime > 0)
        //{
        //Debug.Log("Are you ever here?");
        InvokeRepeating("SpawnOrNot", 0.0f, 0.6f);
        Spawn();
        
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float intensity, fIntensity, cIntensity;
        intensity = Random.Range(0, 1);
        fIntensity = Random.Range(0, 1);
        cIntensity = Random.Range(0, 1);
        int n = Random.Range(0, 37);
        if (n%19 == 0)
        {
            camera.enabled = true;
            //audioSource.PlayOneShot(GlitchMusic, volume);
        }
        else
        {
            camera.enabled = false;
        }
        if ( (numberOfBugs > 8))
        {
            //Desktop.GetComponent<GlitchEffect>().intensity = intensity;
            //Desktop.GetComponent<GlitchEffect>().flipIntensity = fIntensity;
            //Desktop.GetComponent<GlitchEffect>().colorIntensity = cIntensity;
            //Desktop.GetComponent<Camera>().SetActive(true);
            
            camera.enabled = true;
        }
        else
        {
            camera.enabled = false;
        }

    }

    void SpawnOrNot()
    {
        if (Timer.currentTime < 0)
        {
            Destroy(this.gameObject);
        }
        //if (Timer.currentTime > 50) { i = 5; }
        //else if (Timer.currentTime > 40) { i = 4; }
        //else if (Timer.currentTime > 30) { i = 3; }
        //else if (Timer.currentTime > 20) { i = 2; }
        //if ((Timer.currentTime < 6) && (Timer.currentTime > 5)) { i = 1; }
        int randomNumber = Random.Range(0, 10);
        // change it to randomNumber != 0 for a ton of bugs
        if ((Timer.currentTime > 50) && (randomNumber % 9 == 0))
        {
            Spawn();
        }
        else if ((Timer.currentTime > 30) && (randomNumber % 3 == 0)) { Spawn(); }
        else if ((Timer.currentTime > 4) && (randomNumber % 3 == 0)) { Spawn(); }
        else if ((Timer.currentTime > 3) && (randomNumber % 1 == 0)) { Spawn(); }
        //Debug.Log("randomNumber = " + randomNumber);
    }

    void Spawn()
    {
        
        list.Add(Instantiate(buggy, transform.position, transform.rotation));
        Debug.Log(bug.GetComponent<ClickBug>().bugKilled);
        //audioSource.PlayOneShot(ErrorMusic, volume);
        numberOfBugs = (GameObject.FindGameObjectsWithTag("Bug").Length)/2;
        Debug.Log("amount of bugs on screen: " + numberOfBugs);

    }
}