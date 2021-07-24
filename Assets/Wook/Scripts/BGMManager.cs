using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeBGM();
    }

    void ChangeBGM()
    {
        if (SceneManager.GetActiveScene().name == "Title")
            SoundManager.instance.Play_BGM("TitleBGM");
        else if(SceneManager.GetActiveScene().name == "Main")
            SoundManager.instance.Play_BGM("GameBGM");

    }
}
