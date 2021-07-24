using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    public Image foodimg;
    public Image mainimg;
    public Image[] subimg;
    public Text menutext;
    public Food food;

    public void setRecipe(Food setfood){
        food=setfood;
        foodimg.sprite=food.FoodSprite;
        mainimg.sprite=food.Ingredients[0].FoodSprite;
        for(int i=0;i<subimg.Length;i++){
            if(i>=food.Ingredients.Length-1) Destroy(subimg[i]);
            else subimg[i].sprite=food.Ingredients[i+1].FoodSprite;
        }
        menutext.text=food.FoodName;
    }

}
