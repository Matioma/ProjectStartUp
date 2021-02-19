using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryView : MonoBehaviour
{
    [SerializeField]
    VictoryResources resources;
    [SerializeField]
    TextMeshProUGUI gold;
    [SerializeField]
    TextMeshProUGUI wood;
    [SerializeField]
    TextMeshProUGUI oranges;


    private void OnEnable()
    {
        gold.text = resources.Gold.ToString();
        wood.text = resources.Wood.ToString();
        oranges.text = resources.Oranges.ToString();
    }
}
