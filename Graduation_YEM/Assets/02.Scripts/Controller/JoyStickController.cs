//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class JoyStickController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
//{
//    [SerializeField]
//    private RectTransform lever;
//    private RectTransform rectTransform;

//    //ui상에 레버 범위 조정
//    [SerializeField, Range(10, 150)]
//    private float leverRange;

//    //이동
//    private Vector2 inputDirection;
//    private bool isInput;

//    [SerializeField]
//    private CamController camController;

//    private void Awake()
//    {
//        rectTransform = GetComponent<RectTransform>();
//    }
//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        ControlJoySticklever(eventData);
//        isInput = true;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        ControlJoySticklever(eventData);
//    }

//    public void OnEndDrag(PointerEventData eventData)
//    {
//        lever.anchoredPosition = Vector2.zero;
//        isInput = false;
//        camController.CamMove(Vector2.zero);
//    }
//    private void ControlJoySticklever(PointerEventData eventData)
//    {
//        var inputPos = eventData.position - rectTransform.anchoredPosition;
//        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
//        lever.anchoredPosition = inputVector;
//        inputDirection = inputVector / leverRange;
//    }

//    private void InputControlVector()
//    {
//        //캐릭터에게 입력벡터를 전달
//        camController.CamMove(inputDirection);
//        Debug.Log(inputDirection.x + "/" + inputDirection.y);
//    }
//    void Update()
//    {
//        if (isInput)
//        {
//            InputControlVector();
//        }
//    }
//}
