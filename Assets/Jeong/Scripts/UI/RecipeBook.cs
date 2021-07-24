using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{
    public Text text;
    public Image[] buttons;
    public ScrollRecipeView scrollview;
    int stagenum=0;

    public Sprite nullimg;
    public Sprite selectimg;

    void Start()
    {
        stagenum=FindObjectOfType<DataManager>().currentStageNumber;
        for(int i=0;i<3;i++){
            buttons[i].sprite=nullimg;
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
        buttons[n-1].sprite=nullimg;
    }

    void setSelectolorbtn(int n){
        buttons[n-1].sprite=selectimg;
    }

}