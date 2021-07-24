using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<string> OrderDrink = new List<string>();

    [SerializeField] float Order_Timer;
    [SerializeField] float Timer;
    [SerializeField] bool isOrder = false; // �ֹ��� �ߴ��� 

    public Animator animator;
    public List<string> ReceivedDrink = new List<string>();
    public int positionNumber;
    List<bool> OrderSuccess = new List<bool>();
    int OrderSuccessCount = 0;

    void OrderTimer()
    {
        if(isOrder)
            Timer -= Time.deltaTime;

        if(Timer <= 0)
            OrderOver();
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

    public void SetOrderDrink(List<string> Drinks, int _orderCount)
    {
        for(int i = 0; i < _orderCount; i++)
        {
            OrderDrink.Add(Drinks[Random.Range(0, Drinks.Count)]);
        }
    }

    void CheckDrink(string _ReceivedDrinkName) //자신이 주문한 음료와 받은 음료가 맞는지 검사
    {
        //중복된 음료를 주문할때 예외처리
        string ReceivedDrinkName = _ReceivedDrinkName;
        for (int i = 0; i < OrderDrink.Count; i++)
        {
            if(OrderSuccess[i])
            {
                continue;
            }

            if (OrderDrink[i].Equals(ReceivedDrinkName))
            {
                OrderSuccess[i] = true;
                OrderSuccessCount++;
                break;
            }
            else 
            {
                //todo 실패애니메이션 재생
                animator.SetTrigger("OrderFailTrigger");
            }
        }
       
       if(OrderSuccessCount >= OrderDrink.Count)
            OrderOver();
    }

    public void CustomerReset()
    {
        OrderDrink.Clear();
    }

    void OrderOver() //시간종료, 주문완료
    {
        DataManager.instance.AcheiveStagePoint(OrderSuccessCount);
        isOrder = false;
        //todo 손님제거
        CustomerManager.instance.SetOffPooling(this);
        CustomerReset();

    }

    public void ReceiveDrink(string _DrinkName) //음료 주기
    {
        CheckDrink(_DrinkName);
    }

}
