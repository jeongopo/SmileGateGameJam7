using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUIManager : MonoBehaviour
{
    public OrderUI[] shapes;
    public GazeUI[] gazes;
    Customer[] customers;

    void Start()
    {
        allinactive();
    }
    
    public void setStart(Customer tmp){ //customer가 on될때, slot을 on하는 함수
        int num=tmp.GetComponent<Customer>().positionNumber;
        //Debug.Log(tmp.name+" 손님 입장 위치 : "+num);
        shapes[num].gameObject.SetActive(true);
        shapes[num].customer=tmp;
        shapes[num].setimg();
        gazes[num].gameObject.SetActive(true);
        gazes[num].customer=tmp;
    }

    public void setFinish(int num){ //customer가 off될때, slot을 off하는 함수
        shapes[num].gameObject.SetActive(false);
        gazes[num].gameObject.SetActive(false);
    }

    public void allinactive(){
        for(int i=0;i<3;i++){
            shapes[i].gameObject.SetActive(false);
            gazes[i].gameObject.SetActive(false);
        }
    }

    public void recivefood(int num,int slot){ //num번째 손님의 slot을 서빙함
        shapes[num].GetComponent<OrderUI>().orderfinish(slot);
    }

}
