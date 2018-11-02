using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwich : MonoBehaviour {
   public bool Attack;
    public bool Cure;
    public GameObject a;
    public GameObject c;

	[SerializeField]
	private MagicModeChange modeChange;

	// Use this for initialization
	void Start () {
        //if (Attack == true) {
		if (modeChange.attacking == false){
            a.SetActive(true);
        }
		//else if(Cure==true){
		else if (modeChange.attacking == true){
            c.SetActive(true);
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		//if (Attack == true) {
        if (modeChange.attacking == true)
        {
            a.SetActive(true);
        }
        //else if(Cure==true){
        else if (modeChange.attacking == false)
        {
            c.SetActive(true);
        }
	}

	void ChangeMode() {
        Attack = true;
        Cure = true;
    }
}
