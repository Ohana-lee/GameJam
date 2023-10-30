using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject CharacPic;
    public bool lastDialogue;
    public bool haveNextDialogue;
    public bool endOfBeginningDialogue = false;
    public bool endOfMiddleDialogue = false;
    public bool endOfEndingDialogue = false;
    public bool trueEnd = false;
    public bool haveSoundEffect = false;
    public GameObject nextDialogue;
    public AudioClip Dooropened;
    public AudioSource audioSource;
    //public LevelProgression lvPro;
    
    private GameObject player;
    private int index;
    
    //private bool BeginningDialogueEnd = false;
    //private bool MiddleDialogueEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) //maybe change to enter button later
        {
            //if (!lastDialogue)
            //{
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            //}
            //else
           //{
                //QuestionMgr.Instance.Show(); //calls the popup questions
            //}
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {

            if (haveNextDialogue)
            {
                                                if (haveSoundEffect)
                                                {
                                                    audioSource.PlayOneShot(Dooropened, 1);
                                                }
                gameObject.SetActive(false);
                CharacPic.SetActive(false);
                nextDialogue.SetActive(true);
                //calls next dialogue
            }
            else
            {
                gameObject.SetActive(false);
                CharacPic.SetActive(false);
            }
        }
    }
}
