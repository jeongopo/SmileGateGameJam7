using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public Customer customer;
    public List<Food> foodlist;
    public OrderSlot[] slots;
    
    public void setimg()//주문받은 내용을 UI로 표시하는 함수
    { 
        for (int i = 1; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].resetimg();
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (i >= customer.OrderDrink.Count)
            {
                slots[i].gameObject.SetActive(false);
            }
                //주문 개수가 3개보다 적은 경우
            else
            {
                string fname = customer.OrderDrink[i];
                Sprite spriteTmp = foodlist.Find(o => o.name == fname).FoodSprite;
                slots[i].changeimg(spriteTmp);
            }
        }

    }

    public void orderfinish(int i)
    { //i번째 음식을 완성 UI로 만드는 함수
        slots[i].doneimg();
    }



}
