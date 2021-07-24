using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUIManager : MonoBehaviour
{
    public GameObject[] shapes;
    Customer[] customers;

    void Start()
    {
        for(int i=0;i<3;i++){
            shapes[i].SetActive(false);
        }

    }
    
    public void setStart(GameObject tmp){ //customer가 on될때, slot을 on하는 함수
        int num=tmp.GetComponent<Customer>().positionNumber;
        Debug.Log(tmp.name);
        Debug.Log(tmp.name+" 손님 입장 위치 : "+num);
        shapes[num].SetActive(true);
        shapes[num].GetComponent<OrderUI>().customer=tmp;
        shapes[num].GetComponent<OrderUI>().setimg();
    }

    public void setFinish(GameObject tmp){ //customer가 off될때, slot을 off하는 함수
        int num=tmp.GetComponent<Customer>().positionNumber;
        shapes[num].SetActive(false);
    }

}
