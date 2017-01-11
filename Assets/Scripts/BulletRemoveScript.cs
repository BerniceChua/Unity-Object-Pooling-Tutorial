using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRemoveScript : MonoBehaviour {

	void OnEnable() {
        Invoke("SetInactive", 2.0f);
    }

    void SetInactive() {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke(); // prevents "double disabled" from "void OnEnable".
    }
}
