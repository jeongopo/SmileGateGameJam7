using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int customerSapwnDelay;

    private void Start()
    {
        StageStart();
        InvokeRepeating("SapwnStageCustomer", customerSapwnDelay, customerSapwnDelay);
    }

    void StageStart()
    {
        DataManager.instance.SetStartStage();
    }

    public void SapwnStageCustomer()
    {
        CustomerManager.instance.SapwnCustomer();
    }
}

