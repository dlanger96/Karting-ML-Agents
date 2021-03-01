using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class KartingUpravljanje : MonoBehaviour
{
   
   
   public Transform cijeliKart;
   public Transform karting;
   public Rigidbody kugla;
   
   float brzina, trenutnaBrzina;
   float rotacija, trenutnaRotacija;

   [Header("Parametri")]
   public float ubrzanje = 30f;
   public float upravljanje = 80f;
   public float gravitacija = 10f;
   public LayerMask layerMask;

   [Header("Dijelovi")]
   public Transform prednji;
   public Transform straznji;
   public Transform volan;


   public void PostaviUbrzanje(float ulaz)
   {
      brzina = ubrzanje * ulaz;
      trenutnaBrzina = Mathf.SmoothStep(trenutnaBrzina, brzina, Time.deltaTime * 12f);
      brzina = 0f;
      trenutnaRotacija = Mathf.Lerp(trenutnaRotacija, rotacija, Time.deltaTime * 4f);
      rotacija = 0f;
   }

   public void Pokreni(float ulaz)
   {
      cijeliKart.localEulerAngles = Vector3.Lerp(cijeliKart.localEulerAngles, new Vector3(0, 90 + (ulaz * 15), cijeliKart.localEulerAngles.z), .2f);
      
      prednji.localEulerAngles = new Vector3(0, (ulaz * 15), prednji.localEulerAngles.z);
      prednji.localEulerAngles += new Vector3(0, 0, kugla.velocity.magnitude / 2);
      straznji.localEulerAngles += new Vector3(0, 0, kugla.velocity.magnitude / 2);
      
      volan.localEulerAngles = new Vector3(-25, 90, ((ulaz * 45)));
   }
   
   public void FixedUpdate()
   {
      kugla.AddForce(-cijeliKart.transform.right * trenutnaBrzina, ForceMode.Acceleration);
      kugla.AddForce(Vector3.down * gravitacija, ForceMode.Acceleration);
      transform.position = kugla.transform.position - new Vector3(0, 0.4f, 0);
      transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + trenutnaRotacija, 0), Time.deltaTime * 5f);
      Physics.Raycast(transform.position + (transform.up*.1f), Vector3.down, out RaycastHit hitOn, 1.1f,layerMask);
      Physics.Raycast(transform.position + (transform.up * .1f)   , Vector3.down, out RaycastHit hitNear, 2.0f, layerMask);
      karting.up = Vector3.Lerp(karting.up, hitNear.normal, Time.deltaTime * 8.0f);
      karting.Rotate(0, transform.eulerAngles.y, 0);
   }
   
   public void Upravljaj(float upravljanjeSig)
   {
      int steerDirection = upravljanjeSig > 0 ? 1 : -1;
      float steeringStrength = Mathf.Abs(upravljanjeSig);
      
      rotacija = (upravljanje * steerDirection) * steeringStrength;
   }

}
