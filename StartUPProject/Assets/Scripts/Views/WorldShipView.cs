using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldShipView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI name;

    [SerializeField]
    TextMeshProUGUI level;

    private void Start()
    {
        Display();
        Debug.Log("Cool");
    }


    void Display() {
        WorldFleetBehaviour data = GetComponentInParent<WorldFleetBehaviour>();
        

        if (data.worldFleetData.isPlayer)
        {
            name.text = "Your Ship";
        }
        else {
            name.text = "Player" + Random.Range(1, 100);
        }

    }

}
