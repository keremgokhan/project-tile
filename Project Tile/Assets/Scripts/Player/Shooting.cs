using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public ushort projectileCount = 10;
    public ushort projectileSpeed = 200;

    private Queue<GameObject> projectiles;

	// Use this for initialization
	void Start () {
        initializeProjectiles();   
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            reloadAmmo(this.projectileCount);
        }

        if (Input.GetMouseButtonDown(0))
        {
            fireProjectile();
        }
    }

    private void reloadAmmo(ushort numberOfProjectiles) {
        for (ushort i = 0; i < numberOfProjectiles; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            this.projectiles.Enqueue(projectile);
        }
    }
        
    private void initializeProjectiles() {
        this.projectiles = new Queue<GameObject>();

        reloadAmmo(this.projectileCount);
    }

    private void fireProjectile() {
        if (this.projectiles.Count <= 0)
            return;

        GameObject projectile = this.projectiles.Dequeue();
        projectile.transform.position = projectileSpawn.position;
        projectile.transform.rotation = projectileSpawn.rotation;
        projectile.SetActive(true);
        //projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 6;
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);
    }
}
