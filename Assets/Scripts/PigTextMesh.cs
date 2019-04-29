using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PigTextMesh : MonoBehaviour
{
    
    private PiggyBank pig;
    private TextMeshPro tmp;

    void Start()
    {
        pig = transform.parent.GetComponent<PiggyBank>();
        tmp = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        tmp.SetText(pig.value.ToString("F2"));        
        // TODO Fix text rotation so it stays in place when pigs rotate.
    }
}
