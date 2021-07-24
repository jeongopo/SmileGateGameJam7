using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBtn : MonoBehaviour
{
    public void setbtnlevel(){
        int num=FindObjectOfType<DataManager>().currentStageNumber;
        if(num>=3){
            FindObjectOfType<Scememanager>().Title_Scene();
        }else FindObjectOfType<Scememanager>().Chage_Scene(num+1);
    }
}