using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SlotEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false; 
    }
}
