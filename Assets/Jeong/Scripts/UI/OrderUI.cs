using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public GameObject customer;
    public Food[] foodlist;
    public Transform[] slots;
    void Start()
    {
        slots=GetComponentsInChildren<Transform>();
    }
    public void setimg(){ //주문받은 내용을 UI로 표시하는 함수
        Debug.Log("주문 개수 : "+customer.GetComponent<Customer>().OrderDrink.Count);
        Debug.Log("슬롯 개수 : "+slots.Length);
        for(int i=0;i<3;i++){
            slots[i+1].gameObject.SetActive(true);
        }

        for(int i=1;i<slots.Length;i++){
            if(this.transform!=slots[i].transform){
                if(i>=customer.GetComponent<Customer>().OrderDrink.Count)
                //주문 개수가 3개보다 적은 경우
                slots[i].gameObject.SetActive(false);
                else {
                    string fname= customer.GetComponent<Customer>().OrderDrink[i];
                    Debug.Log("주문 이름 : "+fname);
                    for(int j=0;j<foodlist.Length;j++){
                        if(fname==foodlist[j].FoodName){
                            slots[i].GetComponent<Image>().sprite=foodlist[j].FoodSprite;
                            break;
                        }
                    }
                
                }
            }
        }
    }
    
    public void orderfinish(int i){ //i번째 음식을 완성 UI로 만드는 함수
        Color tem=slots[i].GetComponent<Image>().color;
        tem.a=0.5f;
        slots[i].GetComponent<Image>().color=tem;
    }



}
