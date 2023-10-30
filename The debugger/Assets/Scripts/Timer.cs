using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    /*public void Construct(bool _hasShow, bool _playerInRange)
    {
        isShowing = _isShowing;
    }*/

    public TextMeshPro timer;
    [SerializeField] public float startingTime = 10f;
    public static float currentTime = 0f;
    [SerializeField] public Color32 startColour = new Color32(255, 0, 163, 255); //default pink
    [SerializeField] public Color32 midColour = new Color32(255, 92, 0, 255); //default orange
    [SerializeField] public Color32 endColour = new Color32(255, 0, 35, 255); //default red
    private Color32 timerColour;
    public bool isShowing;
    public AudioSource audioSource;
    public AudioClip ErrorMusic;
    public float volume;
    public TodoController todocontroller;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        timer.text = currentTime.ToString();
        timer.fontSize = 150;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate current time as a fraction of starting time and adjust colour accordingly:
        float timeRatio = currentTime / startingTime;
        if (timeRatio >= 1)
        {
            //timer.color = new Color32(255, 0, 163, 252); //starts at pink
            timerColour = startColour;
        }
        if (1 > timeRatio && timeRatio >= 0.5)
        {
            timer.color = new Color32(255, (byte)(2 * (1 - timeRatio) * 92), (byte)(((2 * timeRatio) - 1) * 163), 252); //moving to orange
            for (int i = 0; i < 3; i++)
            {
                if (startColour[i] < midColour[i]) //increasing
                {
                    timerColour[i] = (byte)(startColour[i] + (2 * (1 - timeRatio) * (midColour[i] - startColour[i])));
                }
                else //decreasing
                {
                    timerColour[i] = (byte)(midColour[i] + ((2 * timeRatio) - 1) * (startColour[i] - midColour[i]));
                }
            }
        }
        else if (0.5 > timeRatio && timeRatio >= 0)
        {
            //timer.color = new Color32(255, (byte)(2 * timeRatio * 92), (byte)(((2 * (1 - timeRatio)) - 1) * 35), 252); //moving to red
            for (int i = 0; i < 3; i++)
            {
                if (midColour[i] < endColour[i]) //increasing
                {
                    timerColour[i] = (byte)(midColour[i] + (2 * (1 - timeRatio) - 1) * (endColour[i] - midColour[i]));
                }
                else //decreasing
                {
                    timerColour[i] = (byte)(endColour[i] + 2 * timeRatio * (midColour[i] - endColour[i]));
                }
            }
        }

        //Debug.Log("current time " + (int)Timer.currentTime);
        if (((int)Timer.currentTime % 10 == 0) && (!isShowing))
        {
            //collider.GetComponent<PlayerController>().enabled = false;
            QuestionMgr.Instance.Show(); //to call the popup questions
            audioSource.PlayOneShot(ErrorMusic, volume);
            //audioSource.Play();
            isShowing = true;
        }

        timer.color = timerColour;
        currentTime -= 1 * Time.deltaTime;
        timer.text = ((int)currentTime).ToString();
        if (currentTime <= 0)
        {
            // load game over scene
            //SceneManager.LoadScene("Game Over");
            if (todocontroller.workDone)
            {
                //go to good end
                //SceneManager.LoadScene("Game Over");
                SceneManager.LoadScene("Ending 1");
            }
            else
            {
                //go to bad end;
                SceneManager.LoadScene("Ending");
            }
        }
    }
}
