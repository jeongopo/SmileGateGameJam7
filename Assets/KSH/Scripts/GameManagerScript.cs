using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public int StartDelay;
    public int customerSapwnDelay;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void GameStart()
    {
        StageStart();
        InvokeRepeating("SapwnStageCustomer", StartDelay, customerSapwnDelay);
    }

    public void StopStage()
    {
        CancelInvoke();
        CustomerManager.instance.ResetStage();
        CustomerManager.instance.AllCustomerReset();
    }

    void StageStart()
    {
        DataManager.instance.ResetStage();
    }

    public void SapwnStageCustomer()
    {
        CustomerManager.instance.SapwnCustomer();
    }
}

