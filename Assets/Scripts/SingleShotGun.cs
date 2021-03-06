﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleShotGun : Gun
{
    [SerializeField] Camera cam;

    private AudioSource sonidoRiffle;

    PhotonView PV;


    void Start()
    {
        sonidoRiffle = GetComponent<AudioSource>();

    }
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    public override void Use()
    {
        Shoot();
    }
    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        sonidoRiffle.Play();
        if(Physics.Raycast(ray,out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageble>()?.TakeDamage(((GunInfo)itemInfo).damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
            print("shoot" + hit.collider.name);
        }
        print("Shoot");
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
            Destroy(bulletImpactObj, 10f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);
        }
    }
}
