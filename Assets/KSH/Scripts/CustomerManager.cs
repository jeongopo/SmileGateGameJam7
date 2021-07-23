using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Customer customerPrefab;

    [SerializeField] Transform OnPoolingParent;
    [SerializeField] Transform OffPoolingParent;

    List<Customer> allList = new List<Customer>();
    List<Customer> onList = new List<Customer>();
    List<Customer> offList = new List<Customer>();

    float createCustomerDelay;

    void SetOnPooling(Customer _customer)
    {
        Customer findCustomer = offList.Find(o => o == _customer);
        if(findCustomer != null)
        {
            findCustomer.transform.SetParent(OnPoolingParent);
            onList.Add(findCustomer);
            offList.Remove(findCustomer);
        }
    }

    void SetOffPooling(Customer _customer)
    {
        Customer findCustomer = onList.Find(o => o == _customer);
        if(findCustomer != null)
        {
            findCustomer.transform.SetParent(OnPoolingParent);
            offList.Add(findCustomer);
            onList.Remove(findCustomer);
        }
    }

    void SettingCustomer(Customer _customer)
    {
        _customer.SetTimer(DataManager.instance.GetCustomerTimer(_customer.OrderDrink.Count));
        _customer.SetOrderDrink(DataManager.instance.GetPossibleOrderDrink(), 3);
    }

    void SetSpriteAnimator(Customer _customer)
    {
        int spriteRend = Random.Range(0, _customer.CustomerSprites.Length);
        _customer.GetComponent<SpriteRenderer>().sprite = _customer.CustomerSprites[spriteRend];
        _customer.animator = _customer.CustomerAnimators[spriteRend];
    }

    void InitCustomer()
    {
        for(int i = 0; i < 5; i++)
        {
            Customer tmp = Instantiate(customerPrefab.gameObject).GetComponent<Customer>();
            tmp.name = "Customer_" + i.ToString();
            tmp.transform.SetParent(OffPoolingParent);
            tmp.gameObject.SetActive(false);
            allList.Add(tmp);
            offList.Add(tmp);
            SettingCustomer(tmp);
        }
    }

    void Start()
    {
        InitCustomer();
    }
}
