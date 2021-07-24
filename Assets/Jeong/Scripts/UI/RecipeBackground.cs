using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBackground : MonoBehaviour
{
    public GameObject recipepanel;
    private GraphicRaycaster gr;
    void Start()
    {
        gr = FindObjectOfType<GraphicRaycaster>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicktoout();
        }
    }

    public void clicktoout(){
        var pad = new PointerEventData(null);
        pad.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pad, results);

        if (results.Count <= 0) return;

        if (results[0].gameObject.transform.name ==transform.name)
        {
            recipepanel.SetActive(false);
        }

    }
}
