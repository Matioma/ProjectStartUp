using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour
{
    [SerializeField]
    UnityEvent onSelect;
    [SerializeField]
    UnityEvent onDeselect;

    WorldFleetBehaviour selectedShip;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SelectObject();
        }

        //Debug.Log(IsMouseOverUI());

        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }

        //if (Input.GetMouseButtonDown(0) == true && EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (EventSystem.current.currentSelectedGameObject.gameObject.tag == "Button") {
        //        Debug.Log(EventSystem.current.currentSelectedGameObject.gameObject.tag);
        //    }
        //    //Debug.Log(EventSystem.current.currentSelectedGameObject.gameObject.name);
        //}
    }

    bool IsMouseOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
    
    }

    public void AttackSelectedShip() {
        selectedShip.GetComponent<WorldFleetController>().AttackShip();
    }


    void SelectObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (EventSystem.current.IsPointerOverGameObject()) { 
        //    if (EventSystem.current.currentSelectedGameObject.gameObject.tag == "Button")
        //    {
        //        //Debug.Log(EventSystem.current.currentSelectedGameObject.gameObject.tag);
        //        return;
        //    }
        //}

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Transform clickedTransform = hit.transform;
            if (clickedTransform == null) return;




            WorldFleetBehaviour worldFleetBehaviour = clickedTransform.GetComponent<WorldFleetBehaviour>();
            if (worldFleetBehaviour != null)
            {
                if (selectedShip != null) selectedShip.DeselectShip();

                onSelect?.Invoke();
                selectedShip = worldFleetBehaviour;
                selectedShip.SelectingShip();
                return;
            }
            else
            {
                //GetComponentInChildren<WorldModel>()?.DeselectAllShips();
            }

        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject()) {
                if (EventSystem.current.currentSelectedGameObject.gameObject.layer == 5) {
                    return;
                }
            }
            selectedShip = null;
            onDeselect?.Invoke();
        }
    }
}
