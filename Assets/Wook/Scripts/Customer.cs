using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<string> OrderDrink = new List<string>();

    [SerializeField] float Order_Timer;
    [SerializeField] float Timer;

    public  bool isOrder = false; // �ֹ��� �ߴ��� 
    public Animator animator;
    public List<string> ReceivedDrink = new List<string>();
    public int positionNumber;
    public List<bool> OrderSuccess = new List<bool>();

    List<int> StagePointLits = new List<int>();
    int OrderSuccessCount = 0;

    void OrderTimer()
    {
        if(isOrder)
            Timer -= Time.deltaTime;

        if(Timer / Order_Timer <= 0.3)
        {
            animator.SetTrigger("TimeOverTrigger");
        }

        if(Timer <= 0)
            OrderOver(true);
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
            OrderSuccess.Add(false);
        }
    }

    void CheckDrink(Food _ReceivedDrink) //자신이 주문한 음료와 받은 음료가 맞는지 검사
    {
        //중복된 음료를 주문할때 예외처리
        string ReceivedDrinkName = _ReceivedDrink.FoodName;
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

                int addTmp = 0;
                for(int j = 0 ; j < _ReceivedDrink.Ingredients.Length; j++)
                {
                    addTmp += _ReceivedDrink.Ingredients[j].Price;
                }
                StagePointLits.Add(addTmp * 3);
                if (OrderSuccessCount >= OrderDrink.Count)
                    OrderOver(false);
                break;
            }
            else 
            {
                //todo 실패애니메이션 재생
                animator.SetTrigger("OrderFailTrigger");
            }
        }
       
    }

    public void CustomerReset()
    {
        OrderDrink.Clear();
        OrderSuccess.Clear();
        StagePointLits.Clear();
    }

    void OrderOver(bool _timerOver) //시간종료, 주문완료
    {
        if(!_timerOver)
        {
            DataManager.instance.AcheiveStagePoint(StagePointLits, Order_Timer, Timer);
            animator.SetTrigger("OrderSuccessTrigger");
        }
        isOrder = false;
        //todo 손님제거
        CustomerManager.instance.SetOffPooling(this);
        CustomerReset();

    }

    public void ReceiveDrink(Food _Drink) //음료 주기
    {
        CheckDrink(_Drink);
    }

    private void Update()
    {
        OrderTimer();
    }

}
