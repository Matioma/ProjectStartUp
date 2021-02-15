using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Select : MonoBehaviour
{
    [SerializeField]
    UnityEvent onSelect;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            SelectObject();
        }
        if (Input.GetMouseButtonDown(0)){
            SelectObject();
        }
    }

    void SelectObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Transform clickedTransform = hit.transform;
            if (clickedTransform == null) return;


            WorldFleetBehaviour worldFleetBehaviour = clickedTransform.GetComponent<WorldFleetBehaviour>();
            Debug.Log(worldFleetBehaviour);
            if (worldFleetBehaviour != null)
            {
                worldFleetBehaviour.SelectingShip();
            }else {
                GetComponentInChildren<WorldModel>()?.DeselectAllShips();
            }
        }
        else{
            GetComponentInChildren<WorldModel>()?.DeselectAllShips();
        }
    }
}
