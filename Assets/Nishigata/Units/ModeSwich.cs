using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwich : MonoBehaviour {
   public bool Attack=false;
    public bool Cure=false;
    public GameObject a;
    public GameObject c;

	[SerializeField]
	private MagicModeChange modeChange;

	// Use this for initialization
	void Start () {
        //if (Attack == true) {
		if (modeChange.attacking == false){
            a.SetActive(true);
            c.SetActive(false);
        }
		//else if(Cure==true){
		else if (modeChange.attacking == true){
            c.SetActive(true);
            a.SetActive(false);
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
        Debug.Log("mode.attack=" + modeChange.attacking);
		//if (Attack == true) {
        if (modeChange.attacking == true)
        {
            c.SetActive(true);
            a.SetActive(false);

          
        }
        //else if(Cure==true){
        else if (modeChange.attacking == false)
        {
            a.SetActive(true);
            c.SetActive(false);

        }
	}

	void ChangeMode() {
        Attack = true;
        Cure = true;
    }
}
