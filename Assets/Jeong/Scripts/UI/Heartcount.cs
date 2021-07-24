using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartcount : MonoBehaviour
{
    public GameObject[] hearts;
    int heartnum=3;

    public void discountheart(){
        heartnum--;
        hearts[heartnum].SetActive(false);
        if(heartnum==0) Debug.Log("게임 오버");
    }

}
