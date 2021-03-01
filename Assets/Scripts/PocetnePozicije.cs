using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocetnePozicije : MonoBehaviour
{
    public Transform[] pocetnaPozicija;

    public Vector3 SelectRandomSpawnpoint()
    {
        int slucajni = Random.Range(0, 4);
        return pocetnaPozicija[slucajni].position;
    }
}
