using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<string> OrderDrink = new List<string>();
    public Material[] shakeMaterials;

    [SerializeField] float Order_Timer;
    [SerializeField] float Timer;

    public  bool isOrder = false; // �ֹ��� �ߴ��� 
    public Animator animator;
    public int positionNumber;
    public List<string> ReceivedDrink = new List<string>();
    public List<bool> OrderSuccess = new List<bool>();
    public SpriteRenderer spriteRenderer;

    List<int> StagePointLits = new List<int>();
    int OrderSuccessCount = 0;

    void OrderTimer()
    {
        if(isOrder)
            Timer -= Time.deltaTime;

        if(Timer / Order_Timer <= 0.3)
        {
            spriteRenderer.material = shakeMaterials[1];
            animator.SetTrigger("TimeOverTrigger");
        }

        if(Timer <= 0)
            OrderOver(true);
    }

    public float GetTimer()
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
        OrderUIManager uiManager = FindObjectOfType<OrderUIManager>();
        if(uiManager != null)
            uiManager.setStart(this);
    }

    void CheckDrink(Food _ReceivedDrink) //자신이 주문한 음료와 받은 음료가 맞는지 검사
    {
        //중복된 음료를 주문할때 예외처리
        string ReceivedDrinkName = _ReceivedDrink.name;
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
                FindObjectOfType<OrderUIManager>().recivefood(positionNumber,i);
                if (OrderSuccessCount >= OrderDrink.Count)
                    OrderOver(false);    
                return;
            }

        }
        animator.SetTrigger("OrderFailTrigger");
    }

    public void CustomerReset()
    {
        OrderDrink.Clear();
        OrderSuccess.Clear();
        StagePointLits.Clear();
        OrderSuccessCount = 0;
        positionNumber = 0;
        spriteRenderer.material = shakeMaterials[0];

    }

    void OrderOver(bool _timerOver) //시간종료, 주문완료
    {
        FindObjectOfType<OrderUIManager>().setFinish(positionNumber);
        isOrder = false;
        if(!_timerOver)
        {
            spriteRenderer.material = shakeMaterials[0];
            DataManager.instance.AcheiveStagePoint(StagePointLits, Order_Timer, Timer);
            SoundManager.instance.PlaySoundEffect("Coin");
            animator.SetTrigger("OrderSuccessTrigger");
            Invoke("FactionCustomer", 0.8f);
        }
        else 
        {
            animator.SetTrigger("OrderFailTrigger");
            Invoke("DissatisfactionCustomer", 0.8f);
        }

    }

    void FactionCustomer()
    {
        CustomerManager.instance.SetOffPooling(this);
        CustomerReset();
    }

    void DissatisfactionCustomer()
    {
        DataManager.instance.MinusHP();
        CustomerManager.instance.SetOffPooling(this);
        CustomerReset();
        CancelInvoke();
    }

    public void ReceiveDrink(Food _Drink) //음료 주기
    {
        if(isOrder)
            CheckDrink(_Drink);
    }

    private void Update()
    {
        OrderTimer();
    }

}
