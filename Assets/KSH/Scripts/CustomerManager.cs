using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager instance;

    public Customer[] customerPrefab;
    public List<Vector2> customerPositionList;

    [SerializeField] Transform OnPoolingParent;
    [SerializeField] Transform OffPoolingParent;

    List<Customer> allList = new List<Customer>();
    List<Customer> onList = new List<Customer>();
    List<Customer> offList = new List<Customer>();

    List<bool> isCustomerPosition;

    float createCustomerDelay;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        isCustomerPosition = new List<bool>();
        for(int i = 0; i < customerPositionList.Count; i++)
        {
            isCustomerPosition.Add(false);
        }

    }

    public void SetOnPooling(Customer _customer) //오브젝트 켤때 콜백함수
    {
        Customer findCustomer = offList.Find(o => o == _customer);
        if(findCustomer != null)
        {
            findCustomer.transform.SetParent(OnPoolingParent);
            onList.Add(findCustomer);
            offList.Remove(findCustomer);
            gameObject.SetActive(true);
        }
    }

    public void SetOffPooling(Customer _customer) //오브젝트 꺼질때 콜백함수
    {
        Customer findCustomer = onList.Find(o => o == _customer);
        if(findCustomer != null)
        {
            findCustomer.transform.SetParent(OnPoolingParent);
            offList.Add(findCustomer);
            onList.Remove(findCustomer);
            gameObject.SetActive(false);
        }
    }

    void SettingCustomer(Customer _customer)//주문음료, 타이머 설정
    {
        int orderCount = 0;
        _customer.SetOrderDrink(DataManager.instance.GetPossibleOrderDrink(ref orderCount), orderCount);
        _customer.SetTimer(DataManager.instance.GetCustomerTimer(_customer.OrderDrink.Count));
    }

    void InitCustomer()//customer 초기생성
    {
        for(int i = 0; i < 3; i++)
        {
            Customer tmp = Instantiate(customerPrefab[i].gameObject).GetComponent<Customer>();
            tmp.name = "Customer_" + i.ToString();
            tmp.transform.SetParent(OffPoolingParent);
            tmp.gameObject.SetActive(false);
            allList.Add(tmp);
            offList.Add(tmp);
            SettingCustomer(tmp);
        }
    }

    public Vector2 RePositioningCustomer()
    {
        for(int i = 0; i < customerPositionList.Count; i++)
        {
            if(isCustomerPosition[i])
            {
                isCustomerPosition[i] = true;
                return customerPositionList[i];
            }
        }
        return Vector2.zero;
    }

    public void sapwnCustomer()
    {
        if(!offList.Count.Equals(0))
        {
            SettingCustomer(offList[0]);
            RePositioningCustomer();
            SetOnPooling(offList[0]);
        }
    }

    void Start()
    {
        //임시 딜레이
        Invoke("InitCustomer", 1);
    }

    void CustomerSapwn()
    {
        
    }
}

