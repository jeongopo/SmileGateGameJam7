using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRecipeView : MonoBehaviour
{
    public GameObject prefab;
    public Food[] foods_onestar;
    public Food[] foods_twostar;
    public Food[] foods_threestar;
    RectTransform rectTransform;
    float width = 20.0f;
    float height = 65.0f;
    void Start()
    {
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        setrecipe_onestar();
    }

    void Update()
    {
        
    }

    public void setrecipe_onestar(){
        allchilddestroy();
        setrecipe(foods_onestar);
    }
    public void setrecipe_twostar(){
        allchilddestroy();
        setrecipe(foods_twostar);
    }
    public void setrecipe_threestar(){
        allchilddestroy();
        setrecipe(foods_threestar);
    }

    void setrecipe(Food[] pfood){
        int yValue=-50;
        for(int i=0;i<pfood.Length;i++){
            GameObject tem=Instantiate(prefab,new Vector3(0,yValue,0),Quaternion.identity);
            tem.GetComponent<Recipe>().setRecipe(pfood[i]);
            tem.transform.SetParent(this.transform,false);
            yValue-=60;
        }
        rectTransform.sizeDelta =new Vector2(width,height*(pfood.Length));
    }
    void allchilddestroy(){
        Transform[] children=this.GetComponentsInChildren<Transform>();
        for(int i=0;i<children.Length;i++){
            if(children[i].transform!=this.transform)   Destroy(children[i].gameObject);
        }
    }
}
