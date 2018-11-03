using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivatePosition : MonoBehaviour {
    Vector3 defposion;
    public GameObject unit;
    public GameObject Ui_unit;
    Vector3 loposition;

	// Use this for initialization
	void Start () {
        defposion =unit.transform.localPosition;
        loposition = Ui_unit.transform.position - unit.transform.position;
        
		
	}

    // Update is called once per frame
    void Update() {
        // Ui_unit.transform.position = unit.transform.position + defposion;
        if (unit.transform.localPosition != defposion) {
           
        }
		
	}
}
