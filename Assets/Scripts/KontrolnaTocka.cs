using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolnaTocka : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UpraviteljKontrolnimTockama>() != null)
        {
            other.GetComponent<UpraviteljKontrolnimTockama>().DostignutaKontrolna(this);
        }
    }
}
