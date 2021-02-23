using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoZombie : MonoBehaviourPunCallbacks, IDamageble
{
    NavMeshAgent agente;
    public Transform destino;

    PhotonView PV;

    const float vidaMax = 300f;
    float vidaActual = vidaMax;

    ZombieManager zombieManager;

    void  Start()
    {
        agente = GetComponent<NavMeshAgent>();
        destino = GameObject.Find("PlayerController(Clone)").transform;
    }

    void Awake()
    {
        PV = GetComponent<PhotonView>();

        zombieManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<ZombieManager>();
        
    }


    void Update()
    {
        if (destino != null)
        { 
            agente.SetDestination(destino.transform.position);

            if (vidaActual <= 0)
            {
                Die();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        PV.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!PV.IsMine)
            return;
        vidaActual -= damage;

        if (vidaActual <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        zombieManager.Die();
    }
}
