using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class Drink : MonoBehaviour
{
    [SerializeField] Image Food_image;
    [SerializeField] GameObject Making_Drink;

    Food CreatFood = null;
    public static bool IsCreatFood = false;

    private GraphicRaycaster gr;
    private RectTransform rectTransform;
    Color color;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gr = FindObjectOfType<GraphicRaycaster>();
        color = Food_image.color;
    }

     public void GetFood(Food _CreatFood)
    {
        if(_CreatFood == null)
        {
            IsCreatFood = false;
            CreatFood = null;
            color.a = 0;
            Food_image.color = color;
            return;
        }

        Cursor.visible = false;
        CreatFood = _CreatFood;
        color.a = 1;
        Food_image.color = color;
        Food_image.sprite = CreatFood.FoodSprite;
        IsCreatFood = true;
    }

    public void DrinkReset()
    {
        IsCreatFood = false;
        Cursor.visible = true;
        color.a = 0;
        Food_image.color = color;
    }
    private void Update()
    {
        if (!IsCreatFood)
            return;
        Move();
        ClickCheck();
    }

    private void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Trash();
            Give_drink();
        }
    }

    void Give_drink()
    {
        Vector3 mousePosition;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward);

        if (hit.collider == null)
            return;

        if (hit.transform.tag == "Customer")
        {
            Customer customer = hit.transform.GetComponent<Customer>();
            color.a = 0;
            Food_image.color = color;
            Cursor.visible = true;
            customer.ReceiveDrink(CreatFood);
            IsCreatFood = false;
            CreatFood = null;

            Making_Drink.SetActive(true);

        }

        //RaycastHit hitInfo;

        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        //{
        //    if(hitInfo.transform.tag == "Customer")
        //    {
        //        Customer customer = hitInfo.transform.GetComponent<Customer>();
        //        customer.ReceiveDrink(CreatFood);
        //        IsCreatFood = false;
        //        CreatFood = null;
        //        color.a = 0;
        //        Food_image.color = color;
        //    }
        //}

    }


    void Trash()
    {
        var pad = new PointerEventData(null);
        pad.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pad, results);

        if (results.Count <= 0) return;

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.transform.tag == "TrashCan")
            {
                Cursor.visible = true;
                CreatFood = null;
                color.a = 0;
                Food_image.color = color;
                IsCreatFood = false;
                Making_Drink.SetActive(true);
                return;
            }
        }
    }

    private void Move()
    {
        rectTransform.position = Input.mousePosition;
    }
}
