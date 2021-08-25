using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyButtonController : MonoBehaviour
//, IPointerUpHandler, IPointerDownHandler
{
    //Button joyButton;
    [HideInInspector]
    public bool Pressed;

    void Awake()
    {
    }

    void Update()
    {
        Pressed = false;
    }

    public void OnClickButton()
    {
        Pressed = true;
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Pressed = true;
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Pressed = false;
    //    }
    //}

    //public void OnMouseUp()
    //{
    //    Pressed = false;
    //}

    //public void OnMouseDown()
    //{
    //    Pressed = true;
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Pressed = true;
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    Pressed = false;
    //}
}
