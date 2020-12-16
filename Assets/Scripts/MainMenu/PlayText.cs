using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayText : MonoBehaviour
{
    public string nextLevelName;
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
