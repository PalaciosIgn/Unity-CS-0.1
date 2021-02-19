using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoZombie : MonoBehaviourPunCallbacks
{
    NavMeshAgent agente;
    public Transform destino;

    Rigidbody rb;

    PhotonView PV;

    void  Start()
    {
        agente = GetComponent<NavMeshAgent>();
        destino = GameObject.Find("PlayerController(Clone)").transform;

        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }


    void Update()
    {
        agente.SetDestination(destino.transform.position);
    }

}
