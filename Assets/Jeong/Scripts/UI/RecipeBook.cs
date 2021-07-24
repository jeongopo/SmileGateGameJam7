using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{
    public Text text;
    public Button[] buttons;
    public ScrollRecipeView scrollview;
    int stagenum=0;
    public Color selectedcolor;
    public Color normalcolor;

    void Start()
    {
        stagenum=FindObjectOfType<DataManager>().currentStageNumber;
        for(int i=0;i<3;i++){
            ColorBlock colorBlock= buttons[i].colors;
            colorBlock.normalColor=normalcolor;
            buttons[i].colors=colorBlock;
        }
    }

    public void setonestar(){
        scrollview.setrecipe_onestar();
        setSelectolorbtn(1);
        setNormalolorbtn(2);
        setNormalolorbtn(3);
        text.text="1등급 레시피".ToString();
    }

    public void settwostar(){
        if(stagenum>=2){
            scrollview.setrecipe_twostar();
            setSelectolorbtn(2);
            setNormalolorbtn(1);
            setNormalolorbtn(3);
            text.text="2등급 레시피".ToString();
        }else {
           Debug.Log("클리어 레벨이 낮아 열 수 없음");
        }
    }

    public void setthreestar(){
        if(stagenum>=3){
            scrollview.setrecipe_threestar();
            setSelectolorbtn(3);
            setNormalolorbtn(2);
            setNormalolorbtn(1);
            text.text="3등급 레시피".ToString();
        }else Debug.Log("클리어 레벨이 낮아 열 수 없음");
    }

    void setNormalolorbtn(int n){
        ColorBlock colorBlock= buttons[n-1].colors;
        colorBlock.normalColor=normalcolor;
        colorBlock.selectedColor=normalcolor;
        buttons[n-1].colors=colorBlock;
    }

    void setSelectolorbtn(int n){
        ColorBlock colorBlock= buttons[n-1].colors;
        colorBlock.normalColor=selectedcolor;
        colorBlock.selectedColor=selectedcolor;
        buttons[n-1].colors=colorBlock;
    }

}