using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public bool cutscene;

    // Start is called before the first frame update
   public void Loadscene(string sceneName)
   {
        SceneManager.LoadScene(sceneName);
   }

    void Update()
    {
        if (cutscene)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) //maybe change to enter button later
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
