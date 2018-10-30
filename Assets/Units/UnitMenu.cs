using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMenu : MonoBehaviour {
    public GameObject unit;
    public GameObject w_menu;
    public GameObject u_menu;
    public GameObject drower;

    bool objcheck=true;
    bool active=false;
    
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OpenMenu();
		
	}
    void OpenMenu() {
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);
            
            if (aCollider2d.gameObject == unit)
            {
                drower. GetComponent<UnitMove_sin>().enabled = false;
               
                if (active == false)
                {
                    u_menu.SetActive(true);
                    if (unit.gameObject.tag == "Wizard") {
                        w_menu.SetActive(true);
                        
                    }
                    active = true;
                }
               
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);
            Debug.Log("collider=" + aCollider2d);

            if (aCollider2d == u_menu) { objcheck = true; }
            else { objcheck = false; }
            if (objcheck==false)
            {
                if (active == true)
                {
                    u_menu.SetActive(false);
                    drower.GetComponent<UnitMove_sin>().enabled = true;
                    active = false;
                }
                
            }
               
        }
    }
}
