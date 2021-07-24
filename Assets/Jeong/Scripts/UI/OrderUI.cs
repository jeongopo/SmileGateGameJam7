using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public GameObject customer;
    public List<Food> foodlist;
    public OrderSlot[] slots;
    void Start()
    {
        //slots=GetComponentsInChildren<OrderSlot>();
    }
    public void setimg(){ //주문받은 내용을 UI로 표시하는 함수
        // Debug.Log("주문 개수 : "+customer.GetComponent<Customer>().OrderDrink.Count);
        // Debug.Log("슬롯 개수 : "+slots.Length);
        for(int i=1;i<slots.Length;i++){
            slots[i].gameObject.SetActive(true);
        }

        for(int i=1;i<slots.Length;i++){
                if(i>=customer.GetComponent<Customer>().OrderDrink.Count)
                //주문 개수가 3개보다 적은 경우
                slots[i].gameObject.SetActive(false);
                else {
                    string fname= customer.GetComponent<Customer>().OrderDrink[i];
                    Debug.Log("주문 이름 : "+fname);

                    //Debug.Log(foodlist.Find(o => o.name==fname).FoodSprite);
                    slots[i].changeimg(foodlist.Find(o => o.name==fname).FoodSprite);

                    // for(int j=0;j<foodlist.Length;j++){
                    //     if(fname==foodlist[j].FoodName){
                    //         slots[i].sprite=foodlist[j].FoodSprite;
                    //         break;
                    //     }
                    // }
                
                }
            }
        
    }
    
    public void orderfinish(int i){ //i번째 음식을 완성 UI로 만드는 함수
        slots[i].doneimg();
    }



}
