using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string LevelName = "level: " + levelId;
        SceneManager.LoadScene(LevelName);
    }
}
