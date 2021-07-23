using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredient : MonoBehaviour
{
    Select_ingredient select_Ingredient;
    public Food IGD;
    Image image;
    private void Start() {
        image=this.gameObject.GetComponent<Image>();
        select_Ingredient = FindObjectOfType<Select_ingredient>();
        image.sprite = IGD.FoodSprite;
    }

    public void setIGD(Food setIGD){
        IGD=setIGD;
        image.sprite=IGD.FoodSprite;
    }

    public void getIGD(){
        if(IGD.foodtype == FoodType.Ingredients_Main)
        {
            select_Ingredient.Main_Ingredient_Select(IGD);
        }
        else if(IGD.foodtype == FoodType.Ingredients_Sub)
        {
            select_Ingredient.Sub_Ingredient_Select(IGD);
        }
    }

}
