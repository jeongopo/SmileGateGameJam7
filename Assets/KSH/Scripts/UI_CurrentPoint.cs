using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CurrentPoint : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = DataManager.instance.currentStagePoint.ToString();
    }
}
