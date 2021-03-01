using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class KartingAgent : Agent
{
   public UpraviteljKontrolnimTockama upraviteljKontrolnim;
   private KartingUpravljanje upraviteljKarting;
   
   public override void Initialize()
   {
      upraviteljKarting = GetComponent<KartingUpravljanje>();
   }
   
   public override void OnEpisodeBegin()
   {
      upraviteljKontrolnim.ResetirajKontrolne();
   }
      public override void CollectObservations(VectorSensor sensor)
      {
        Vector3 razlika = upraviteljKontrolnim.sljedeci.transform.position - transform.position;

        sensor.AddObservation(razlika / 20f);

        AddReward(-0.001f);
      }
      public override void OnActionReceived(ActionBuffers actions)
      {
        var ulaz = actions.ContinuousActions;

        upraviteljKarting.PostaviUbrzanje(ulaz[1]);
        upraviteljKarting.Upravljaj(ulaz[0]);
      }
      
      public override void Heuristic(in ActionBuffers actionsOut)
      {
        var radnja = actionsOut.ContinuousActions;

        radnja[0] = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            radnja[1] = 1f;
        }
        else
        {
            radnja[1] = 0f;
        }
      }

}
