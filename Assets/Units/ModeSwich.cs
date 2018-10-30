using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwich : MonoBehaviour {
   public bool Attack;
    public bool Cure;
    public GameObject a;
    public GameObject c;

	// Use this for initialization
	void Start () {
        if (Attack == true) {
            a.SetActive(true);
        }
        else if(Cure==true){
            c.SetActive(true);
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeMode() {
        Attack = true;
        Cure = true;
    }
}
