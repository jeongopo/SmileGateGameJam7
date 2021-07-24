using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int customerSapwnDelay;

    private void Start()
    {
        InvokeRepeating("StageStart", customerSapwnDelay, customerSapwnDelay);
    }

    public void StageStart()
    {
        CustomerManager.instance.SapwnCustomer();
    }
}

