using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeUI : MonoBehaviour
{
    public Customer customer;
    public Image gaze;

    void Update()
    {
        setgaze();
    }

    void setgaze(){
        gaze.fillAmount=customer.GetTimer();
    }
}
