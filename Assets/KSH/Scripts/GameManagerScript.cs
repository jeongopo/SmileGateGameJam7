using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public int customerSapwnDelay;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void GameStart()
    {
        StageStart();
        InvokeRepeating("SapwnStageCustomer", customerSapwnDelay, customerSapwnDelay);
    }

    public void StopStage()
    {
        CancelInvoke();
        CustomerManager.instance.ResetStage();
    }

    void StageStart()
    {
        DataManager.instance.ResetStage();
    }

    public void SapwnStageCustomer()
    {
        CustomerManager.instance.SapwnCustomer();
    }
    
    private void Start()
    {
        Invoke("GameStart", 1);
    }
}

