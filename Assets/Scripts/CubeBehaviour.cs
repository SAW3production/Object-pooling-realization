using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour, IPooledObject // INHERITANCE
{
     public int _spawnPower { get; private set; } // ENCAPSULATION

    private Rigidbody _theRigidBody;
    private void Awake()
    {
        _theRigidBody = this.GetComponent<Rigidbody>();
        _spawnPower = Random.Range(-50,50);
    }
    public void OnObjectSpawn()
    {
        
        _theRigidBody.velocity = GenerateRandomForce();
    }
    
    private Vector3 GenerateRandomForce()
    {
        float x = Random.Range(-_spawnPower, _spawnPower);
        float y = Random.Range(-_spawnPower, _spawnPower);
        float z = Random.Range(-_spawnPower, _spawnPower);
        return new Vector3(x, y, z);
    }
}
