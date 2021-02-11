using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectingShip : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SelectSlot();
        }

        if (Input.GetMouseButtonDown(0))
        {
            SelectSlot();
        }
    }
    void SelectSlot() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Transform clickedTransform = hit.transform;
            if (clickedTransform == null) return;
            if (clickedTransform.parent == null) return;
            FleetSlot slot = clickedTransform.parent.GetComponentInParent<FleetSlot>();
            if (slot != null)
            {
                slot.Selected();
            }
        }
    }
}
