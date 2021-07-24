using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scememanager : MonoBehaviour
{
    
    public void Title_Scene()
    {
        GameManagerScript.instance.StopStage();
        SceneManager.LoadScene(0);
    }

    public void Stage_Scene(int _stageNumber)
    {
        DataManager.instance.currentStageNumber = _stageNumber;
        SceneManager.LoadScene(1);
        GameManagerScript.instance.GameStart();
    }

    
}
