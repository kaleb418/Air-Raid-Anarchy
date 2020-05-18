using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter: MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform runtimeSpawnParent;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnParticleCollision(GameObject other) {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = runtimeSpawnParent;
        Destroy(gameObject);
    }
}
