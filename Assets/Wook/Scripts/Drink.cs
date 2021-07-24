using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class Drink : MonoBehaviour
{
    [SerializeField] Image Food_image;
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
                    return;
                }
                else if (results[i].gameObject.transform.tag == "TrashCan")
                {

                    return;
                }
            }
        }
    }

    private void Move()
    {
        rectTransform.position = Input.mousePosition;
    }
}