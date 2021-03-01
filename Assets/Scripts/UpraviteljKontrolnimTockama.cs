using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpraviteljKontrolnimTockama : MonoBehaviour
{
    public float NajveceVrijeme = 30f;
    public float Preostalo = 30f;
    
    public KartingAgent kartingA;
    public KontrolnaTocka sljedeci;
    
    private int TrenutniInd;
    private List<KontrolnaTocka> Kontrolne;
    private KontrolnaTocka prethodni;

    public event Action<KontrolnaTocka> dostignuti; 

    void Start()
    {
        Kontrolne = FindObjectOfType<KontrolneTocke>().kontrolneTocke;
        ResetirajKontrolne();
    }

    public void ResetirajKontrolne()
    {
        TrenutniInd = 0;
        Preostalo = NajveceVrijeme;
        
        PostaviIducu();
    }

    private void Update()
    {
        Preostalo -= Time.deltaTime;

        if (Preostalo < 0f)
        {
            kartingA.AddReward(-1f);
            kartingA.EndEpisode();
        }
    }

    public void DostignutaKontrolna(KontrolnaTocka kontrolna)
    {
        if (sljedeci != kontrolna) return;
        
        prethodni = Kontrolne[TrenutniInd];
        dostignuti?.Invoke(kontrolna);
        TrenutniInd++;

        if (TrenutniInd >= Kontrolne.Count)
        {
            kartingA.AddReward(0.5f);
            kartingA.EndEpisode();
        }
        else
        {
            kartingA.AddReward((0.5f) / Kontrolne.Count);
            PostaviIducu();
        }
    }

    private void PostaviIducu()
    {
        if (Kontrolne.Count > 0)
        {
            Preostalo = NajveceVrijeme;
            sljedeci = Kontrolne[TrenutniInd];
            
        }
    }
}
