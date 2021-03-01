using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolneTocke : MonoBehaviour
{
    public List<KontrolnaTocka> kontrolneTocke;
    
    private void Awake()
    {
        kontrolneTocke = new List<KontrolnaTocka>(GetComponentsInChildren<KontrolnaTocka>());
    }
}
