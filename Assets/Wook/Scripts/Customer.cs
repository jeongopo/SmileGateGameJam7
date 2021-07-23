using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{

    [SerializeField] float Order_Timer;
    [SerializeField] float Timer;
    [SerializeField] string[] Drink;
    [SerializeField] string[] Dessert;
    [SerializeField] bool isOrder = false; // �ֹ��� �ߴ��� 

    private void Start()
    {
        
    }

    void OrderTimer()
    {
        if(isOrder)
            Timer -= Time.deltaTime;
    }

    float GetTimer()
    {
        return Timer / Order_Timer;
    }

    public void SetTimer(float _Timer)
    {
        Order_Timer = _Timer;
        Timer = Order_Timer;
    }

}
