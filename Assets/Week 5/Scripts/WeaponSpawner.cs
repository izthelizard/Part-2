using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public GameObject spearPrefab;
    public Transform spawn;

    public void Spawner(GameObject spear)
    {
        Instantiate(spearPrefab, spawn);
    }
}
