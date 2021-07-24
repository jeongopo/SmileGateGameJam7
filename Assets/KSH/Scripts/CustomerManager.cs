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
        else 
        {
            Destroy(gameObject);
        }

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
            findCustomer.gameObject.SetActive(true);
            FindObjectOfType<OrderUIManager>().setStart(findCustomer);
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
            findCustomer.gameObject.SetActive(false);
            isCustomerPosition[_customer.positionNumber] = false;
            
        }
    }

    void SettingCustomer(Customer _customer)//주문음료, 타이머 설정
    {
        int orderCount = 0;
        _customer.SetOrderDrink(DataManager.instance.GetPossibleOrderDrink(ref orderCount), orderCount);
        _customer.SetTimer(DataManager.instance.GetCustomerTimer(_customer.OrderDrink.Count));
        Debug.Log(_customer.positionNumber);
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
            tmp.CustomerReset();
        }
        FindObjectOfType<OrderUIManager>()?.allinactive();
    }

    public Vector2 RePositioningCustomer(Customer _customer)
    {
        for(int i = 0; i < customerPositionList.Count; i++)
        {
            if(!isCustomerPosition[i])
            {
                isCustomerPosition[i] = true;
                _customer.positionNumber = i;
                return customerPositionList[i];
            }
        }
        return Vector2.zero;
    }

    public void SapwnCustomer()
    {
        if(!offList.Count.Equals(0))
        {
            offList[0].transform.position = RePositioningCustomer(offList[0]);
            SettingCustomer(offList[0]);
            offList[0].isOrder = true;
            SetOnPooling(offList[0]);
        }
    }

    public void ResetStage()
    {
        for(int i = 0; i < onList.Count; i++)
        {
            onList[0].isOrder = false;
            SetOffPooling(onList[0]);
        }
    }

    void Start()
    {
        InitCustomer();
    }
}

