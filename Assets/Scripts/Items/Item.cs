using System;
using UnityEngine;

public class Item: MonoBehaviour
{
    [SerializeField] protected int Parameter = 0;
    
    public int Value => Parameter;
}
