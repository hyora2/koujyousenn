using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMenu : MonoBehaviour {
    public GameObject unit;
    public GameObject w_menu;
    public GameObject u_menu;
    public GameObject drower;

    bool objcheck=true;
    public bool active=false;
    
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OpenMenu();
        Debug.Log("active=" + active);
        Debug.Log("objcheck=" + objcheck);
		
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
                    active = true;
                    if (unit.gameObject.tag == "WizardUnit") {
                        w_menu.SetActive(true);

                      

                    }
                   
                }
               
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);
            Debug.Log("collider=" + aCollider2d);

            if(aCollider2d == null)
            {
                Debug.Log("null dayo ");
                objcheck = false;
            }
            else
            {
                if (aCollider2d.gameObject == u_menu)
                {
                    objcheck = true;
                }

            }
          

            if (objcheck==false)
            {
                Debug.Log("Oha");

                if (active == true)
                {
                    Debug.Log("hallo");
                    
                    u_menu.SetActive(false);
                    active = false;
                    drower.GetComponent<UnitMove_sin>().enabled = true;

                }
                else { Debug.Log("falseoha"); }
                
            }
               
        }
    }
}
