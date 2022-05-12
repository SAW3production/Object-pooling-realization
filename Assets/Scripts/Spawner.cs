using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private new string tag;
    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool(tag, this.transform.position, this.transform.rotation);
    }
}
