using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creat_Drink : MonoBehaviour
{
    [SerializeField] Food[] Rank1_Drink;
    [SerializeField] Food[] Rank2_Drink;
    [SerializeField] Food[] Rank3_Drink;
    [SerializeField]  GameObject Making_Drink;

    Food Main_Ingredient;
    Food[] Sub_Ingredient;
    Food CreatFood;


    Select_ingredient select_ingredient;
    Drink drink;
    private void Start()
    {
        select_ingredient = FindObjectOfType<Select_ingredient>();
        drink = FindObjectOfType<Drink>();
    }
    void Set_Ingredient(Food main, Food[] sub)
    {
        Main_Ingredient = main;
        Sub_Ingredient = sub;
    }

    int Recipe_Rank_Check()
    {
        int Rank = 0;
        for(int i = 0; i< Sub_Ingredient.Length; i++)
        {
            if (Sub_Ingredient[i] == null)
                break;
            Rank++;

        }
        //if (Rank != Sub_Ingredient.Length)//랭크에 맞는 개수를 가지고 있는지
        //    Rank = 0;

        return Rank;

    }
    bool Recipe_Check()
    {
        int Rank = Recipe_Rank_Check();
        bool have_Ingredients = false;
        if (Rank == 0)
            return false;

        switch (Rank)
        {
            case 1:
                for(int i = 0; i< Rank1_Drink.Length; i++) //음료 종류
                {
                    if(Rank1_Drink[i].Ingredients[0] == Main_Ingredient)
                    {//주재료가 맞는지
                        if (Sub_Ingredient[0] == Rank1_Drink[i].Ingredients[1])
                        {//부재료가 맞는지
                            CreatFood = Rank1_Drink[i];
                            return true;
                        }
                    }
                }
                break;

            case 2:
                for (int i = 0; i < Rank2_Drink.Length; i++) //음료 종류
                {
                    if (Rank2_Drink[i].Ingredients[0] == Main_Ingredient)
                    {//주재료가 맞는지
                        have_Ingredients = false;
                        for (int sub = 0; sub <2; sub++)
                        {
                            if (Sub_Ingredient[sub] == Rank2_Drink[i].Ingredients[1])
                            {
                                have_Ingredients = true;
                                break;
                            }

                        }
                        if (!have_Ingredients)
                            break;
                        have_Ingredients = false;
                        for (int sub = 0; sub < 2; sub++)
                        {
                            if (Sub_Ingredient[sub] == Rank2_Drink[i].Ingredients[2])
                            {
                                have_Ingredients = true;
                                break;
                            }
                        }

                        if (!have_Ingredients)
                            break;
                        CreatFood = Rank2_Drink[i];

                    }
                }

                break;

            case 3:
                for (int i = 0; i < Rank3_Drink.Length; i++) //음료 종류
                {
                    if (Rank3_Drink[i].Ingredients[0] == Main_Ingredient)
                    {//주재료가 맞는지
                        have_Ingredients = false;
                        for (int sub = 0; sub < 3; sub++)
                        {
                            if (Sub_Ingredient[sub] == Rank3_Drink[i].Ingredients[1])
                            {
                                have_Ingredients = true;
                                break;
                            }

                        }
                        if (!have_Ingredients)
                            break;
                        have_Ingredients = false;
                        for (int sub = 0; sub < 3; sub++)
                        {
                            if (Sub_Ingredient[sub] == Rank3_Drink[i].Ingredients[2])
                            {
                                have_Ingredients = true;
                                break;
                            }
                        }

                        if (!have_Ingredients)
                            break;
                        have_Ingredients = false;
                        for (int sub = 0; sub < 3; sub++)
                        {
                            if (Sub_Ingredient[sub] == Rank3_Drink[i].Ingredients[3])
                            {
                                have_Ingredients = true;
                                break;
                            }
                        }

                        if (!have_Ingredients)
                            break;
                        CreatFood = Rank3_Drink[i];

                    }
                }
                break;
        }

        return false;

    }

    public void Creat()
    {
        CreatFood = null;
        Set_Ingredient(select_ingredient.Return_Main(), select_ingredient.Return_Sub());
        Recipe_Check();
        select_ingredient.Select_ingredient_Reset();

        drink.GetFood(CreatFood);
        Making_Drink.SetActive(false);
        if (CreatFood != null)
            Debug.Log(CreatFood.FoodName);
        else
            Debug.Log("실패");


    }
}
