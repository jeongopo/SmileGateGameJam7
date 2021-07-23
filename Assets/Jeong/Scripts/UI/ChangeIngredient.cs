using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIngredient : MonoBehaviour
{
    ingredient[] IGDslot;
    public Food[] ingredients;
    int startnum=0;

    void Start() {
        IGDslot=transform.GetComponentsInChildren<ingredient>();
    }

    public void upwardIGD(){ //위로 버튼 눌렀을 때
        startnum++; //시작번호 늘려주기
        if(startnum>=ingredients.Length) startnum=0;

        int idx=startnum; //재료의 인덱스
        for(int i=0;i<IGDslot.Length;i++){
            IGDslot[i].setIGD(ingredients[idx]);
            idx++;
            if(idx>=ingredients.Length) idx=0;
        }
    }
    public void downwardIGD(){ //아래로 버튼 눌렀을 때
        startnum--; //시작번호 줄여주기
        if(startnum<0) startnum=ingredients.Length-1;

        int idx=startnum; //재료의 인덱스
        for(int i=0;i<IGDslot.Length;i++){
            IGDslot[i].setIGD(ingredients[idx]);
            idx++;
            if(idx>=ingredients.Length) idx=0;
        }
    }
}
