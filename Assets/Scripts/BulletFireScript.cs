using System.Collections;
using System.Collections.Generic; // this gives you access to the Lists data structure.  You can use arrays also.
using UnityEngine;

public class BulletFireScript : MonoBehaviour {

    /* old version:
    public float fireTime = 0.05f;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", fireTime, fireTime);
	}
	
	void Fire () {
        Instantiate(bullet, transform.position, Quaternion.identity);
	}
    */

    // version before the generic object pooler script
    /*
    public float fireTime = 0.05f;
    public GameObject bullet;

    // determines how many objects will be pooled:
    public int pooledAmount = 20;
    List<GameObject> bullets;

    // Use this for initialization
    void Start() {
        bullets = new List<GameObject>();

        // loads the GameObjects in your List.
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false);
            bullets.Add(obj);
        }
        // alternate?
        // foreach (GameObject bullet in bullets) {
        //      GameObject obj = (GameObject)Instantiate(bullet);
        //      obj.SetActive(false);
        //      bullets.Add(obj);
        // }

        InvokeRepeating("Fire", fireTime, fireTime);
    }

    void Fire() {
        for (int i = 0; i < bullets.Count; i++) {
            if (!bullets[i].activeInHierarchy) {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break; // pauses, so that you don't fire all the bullets at the same time.
            }
        }
    }
    */

    public float fireTime = 0.05f;

    // Use this for initialization
    void Start() {
        InvokeRepeating("Fire", fireTime, fireTime);
    }

    void Fire() {
        GameObject obj = ObjectPoolerScript.current.GetPooledGameObject();

        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}