using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject ClearPanel;
    public GameObject Overpanel;
    public GameObject recipe;
    public void recipeopen_func(){
        FindObjectOfType<SoundManager>().Play_BGM("RecipOpen");
        recipe.SetActive(true);
    } 
}
