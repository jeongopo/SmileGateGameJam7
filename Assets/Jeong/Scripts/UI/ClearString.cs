using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearString : MonoBehaviour
{
    public Text text;

    public void setClearStr(int num){
        switch(num){
            case 1: text.text="EASY CLEAR";
                break;
            case 2: text.text="NORMAL CLEAR";
                break;
            case 3: text.text="HARD CLEAR";
                break;
            default: break;
        }

    }

}
