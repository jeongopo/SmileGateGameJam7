using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBtn : MonoBehaviour
{
    public void setbtnlevel(){
        int num=FindObjectOfType<DataManager>().currentStageNumber;
        if(num>=3){
            FindObjectOfType<Scememanager>().Title_Scene();
        }else if(num==2){
            FindObjectOfType<Scememanager>().Hard_Stage();
        }else if(num==1){
            FindObjectOfType<Scememanager>().Normal_Stage();
        }
    }
}