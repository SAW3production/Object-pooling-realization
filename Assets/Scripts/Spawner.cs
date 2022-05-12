using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("Cube", this.transform.position, this.transform.rotation);
    }
}
