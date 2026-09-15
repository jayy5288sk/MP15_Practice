using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PractiveSwitcher : MonoBehaviour
{
    private const string SCENE_A = "StaticPracticeA";
    private const string SCENE_B = "StaticPracticeB";

    private void Update()
    {
        ReadSceneKey();
    }

    private void ReadSceneKey()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MoveToOtherScene();
        }
    }

    private void MoveToOtherScene()
    {
        if(SceneManager.GetActiveScene().name == SCENE_A)
        {
            SceneManager.LoadScene(SCENE_B);
        }
        else
        {
            SceneManager.LoadScene(SCENE_A);
        }
    }
}
