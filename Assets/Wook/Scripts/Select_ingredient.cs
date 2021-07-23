using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Select_ingredient : MonoBehaviour
{
    [SerializeField] Button B_Main_Ingredient;
    [SerializeField] Food F_Main_Food;
    [SerializeField] Button[] B_Sub_Ingredient;
    [SerializeField] Food[] F_Sub_Food = new Food[3];

    int SubFood_Count = 0;


    private void Start()
    {

    }

    //주재료 선택
    public void Main_Ingredient_Select(Food food)
    {
        if (food.foodtype != FoodType.Ingredients_Main)
            return;
        //if (F_Main_Food == null)
        //    return;

        F_Main_Food = food;
        Change_button(B_Main_Ingredient, food, 1);
    }

    //주재료 제거
    public void Main_Ingredient_UnSelect()
    {
        F_Main_Food = null;
        Change_Alpha(B_Main_Ingredient, 0);
    }

    //부재료 선택
    public void Sub_Ingredient_Select(Food food)
    {
        if (food.foodtype != FoodType.Ingredients_Sub)
            return;
        if (SubFood_Count == 3) //개수 체크
            return;
        for (int i = 0; i < 2; i++) //중복체크
        {
            if (F_Sub_Food[i] == food)
                return;
        }


        F_Sub_Food[SubFood_Count] = food;
        Change_button(B_Sub_Ingredient[SubFood_Count], food, 1);
        SubFood_Count++;
    }

    //부재료 제거
    public void Sub_Ingredient_UnSelect(int num)
    {

        F_Sub_Food[num] = null;
        Change_Alpha(B_Sub_Ingredient[num], 0);

        if (num != SubFood_Count)//중간 재료를 선택했을 경우
            Swap_sub(num);
        SubFood_Count--;


    }

    //부재료 위치 변경
    void Swap_sub(int Unselect)
    {
        int Swap_Count = 0;
        switch (SubFood_Count)
        {
            case 2:
                Swap_Count = 1;
                break;

            case 3:
                if (Unselect == 0)
                    Swap_Count = 2;
                else if (Unselect == 1)
                    Swap_Count = 1;
                break;
        }
        for(int i = Unselect; i< Unselect+Swap_Count; i++)
        {
            F_Sub_Food[i] = F_Sub_Food[i + 1];
            Change_button(B_Sub_Ingredient[i], F_Sub_Food[i], 1);
            Change_Alpha(B_Sub_Ingredient[i + 1], 0);
        }

    }

    void Change_button(Button button, Food food, float alpha)
    {
        button.image.sprite = food.FoodSprite;
        Change_Alpha(button, alpha);
    }

    void Change_Alpha(Button button, float alpha)
    {
        Color color = button.image.color;
        color.a = alpha;
        button.image.color = color;
        if (alpha <= 0)
        
            button.interactable = false;      
        else
            button.interactable = true;

    }
}
