using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ClearPoint : MonoBehaviour
{
    public Text text;

    void Update()
    {
        text.text = DataManager.instance.clearPoint[DataManager.instance.currentStageNumber - 1].ToString();
    }
}
