using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionPanel : MonoBehaviour
{
    private static QuestionPanel _instance;
    public static QuestionPanel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<QuestionPanel>();
            }
            return _instance;
        }
    }
    public CanvasGroup canvasGroup;
    public Text text_title;
    public Text text_tip;
    public Toggle[] toggles;
    private int currentSelect;
    private QuestionItem.RightOption right;
    public bool isCorrect;
    //public GameObject OhNoDialogue;
    //public GameObject YayDialogue;
    //public bool isBossLevel;
    public PlayerController playerController;
    //public BossFight bossFight;
    //public GameObject middleDialogue;

    public Timer script;
    private string enemyInQuestion;
    private GameObject enemy;
    public float score = 0f;
    //private int noOfQuestions = 4;
    //private bool haveCard;
    //public int phase = 1;
    //public bool bossRight = true;
    //private bool questionAnswered = false;

    public int BossQuestionCount;
    public int CurrentIndex;
    public Timer timer;

    public void Awake()
    {
        //Debug.Log("current phase: " + phase);
        _instance = this;
        text_tip.gameObject.SetActive(false);
        toggles = transform.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i;
            toggles[i].onValueChanged.AddListener((v) =>
            {
                if (v)
                {
                    currentSelect = index;
                    canvasGroup.interactable = false;
                    text_tip.gameObject.SetActive(true);
                    text_tip.text = index == (int)right ? "Select Right!" : "Select Wrong! Correct: <color=black>" + right.ToString()+"</color>";
                    if (index == (int)right)
                    {
                        text_tip.text = " <color=green> Correct! </color>";
                        //update the TO-DO List
                        //Timer.currentTime += 10f;
                        isCorrect = true;
                    }
                    else
                    {
                        text_tip.text = "Incorrect! Correct: <color=black>" + right.ToString() + "</color>";
                        // answer is incorrect we want the robot to keep functioning... coming soon (maybe)
                        Timer.currentTime -= 2f;
                        isCorrect = false;
                    }
                    StartCoroutine(_Close());


                }
            });
        }
    }


    /*IEnumerator Next()
    {
        CurrentIndex++;
        yield return new WaitForSeconds(2);
        QuestionMgr.Instance.Show();
    }*/
    IEnumerator _Close()
    {
        yield return new WaitForSeconds(2);
        text_tip.gameObject.SetActive(false);
        gameObject.SetActive(false);


        /*if (isBossLevel)
        {
            bossFight.questionAnswered = true;
            //calls ending dialogue
            /*if (bossFight.phase != 1)
            {
                //sends score back to BossFight to decide ending
                Debug.Log("score in qPanel: " + score);
                //decideEnding(score);
            }
            else
            {
                //middleDialogue.SetActive(true);
                //phase = phase + 1;
                //calls more dialogue
            }*/
        //}
        //else
        //{*/
            /*if (isCorrect)
            {
                YayDialogue.SetActive(true);
            }
            else
            {
                OhNoDialogue.SetActive(true);
            }*/
            //GameObject.FindObjectOfType<PlayerController>().enabled = true;
        timer.isShowing = false;
        //}


    }
    public void UpdateItem(QuestionItem item)
    {
        canvasGroup.interactable = true;
        gameObject.SetActive(true);
        currentSelect = -1;
        text_title.text = item.Title;
        Toggle toA = toggles[0];
        toA.transform.Find("Label").GetComponent<Text>().text = item.OptionA;
        toA.isOn = false;
        Toggle toB = toggles[1];
        toB.transform.Find("Label").GetComponent<Text>().text = item.OptionB;
        toB.isOn = false;
        Toggle toC = toggles[2];
        toC.transform.Find("Label").GetComponent<Text>().text = item.OptionC;
        toC.isOn = false;
        Toggle toD = toggles[3];
        toD.transform.Find("Label").GetComponent<Text>().text = item.OptionD;
        toD.isOn = false;
        right = item.Right;
    }

}
