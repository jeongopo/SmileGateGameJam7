using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scememanager : MonoBehaviour
{
    
    public void Change_Scene(int Scene_Number)
    {
        SceneManager.LoadScene(Scene_Number);
    }
}
