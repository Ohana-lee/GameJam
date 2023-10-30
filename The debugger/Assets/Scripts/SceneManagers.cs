using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    // Start is called before the first frame update
   public void Loadscene(string sceneName)
   {
        SceneManager.LoadScene(sceneName);
   }
}
