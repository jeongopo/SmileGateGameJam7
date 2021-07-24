using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scememanager : MonoBehaviour
{
    
    public void Chage_Scene(int _number)
    {
        SceneManager.LoadScene(_number);
    }

    public void Title_Scene()
    {
        FindObjectOfType<CustomerManager>().ResetStage();
        SceneManager.LoadScene(0);
        GameManagerScript.instance.StopStage();
    }

    public void Stage_Scene(int _stageNumber)
    {
        DataManager.instance.currentStageNumber = _stageNumber;
        SceneManager.LoadScene(1);
        GameManagerScript.instance.GameStart();
    }

    public void Easy_Stage()
    {
        Stage_Scene(1);
    }
    public void Normal_Stage()
    {
        Stage_Scene(2);
    }
    public void Hard_Stage()
    {
        Stage_Scene(3);
    }

    public void End_Game()
    {
        Application.Quit();

    }
    
}
