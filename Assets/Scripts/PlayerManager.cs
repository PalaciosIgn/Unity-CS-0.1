using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    GameObject controller;

    PlayerController jugador;

    private AudioSource sonidoMuerte;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        sonidoMuerte = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    
    }

    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation,0,new object[] {PV.ViewID });
    }

    public void Die()
    {
        sonidoMuerte.Play();
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}
