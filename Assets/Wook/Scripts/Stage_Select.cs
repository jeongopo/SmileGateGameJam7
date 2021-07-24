using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage_Select : MonoBehaviour
{
    [SerializeField] Button Normal;
    [SerializeField] Button Hard;
    void Start()
    {
        ClearCheck();
    }

    void ClearCheck()
    {
        if (DataManager.instance.StageClearList[0] == true)
            Normal.interactable = true;
        if (DataManager.instance.StageClearList[1] == true)
            Normal.interactable = true;
    }
}
