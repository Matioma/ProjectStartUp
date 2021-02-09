using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StorageConfiguration", order = 1)]
public class StorageConfiguration : ScriptableObject
{
    [SerializeField]
    public int oranges;
    [SerializeField]
    public int gold;
    [SerializeField]
    public int wood;
}
