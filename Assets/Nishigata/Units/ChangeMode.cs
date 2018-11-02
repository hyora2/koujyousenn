using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {
    bool mode;
   
    
	public GameObject unitmenu;
   
    public GameObject drower;
    public GameObject Ui_unit;
    //private GameObject Root;
    //private GameObject magicunit;
    [SerializeField]
	private MagicModeChange modeChange;

    // Use this for initialization
    void Start () {
       /* if (Cbutton.tag == "C_Mode")
        {
            ButtonPushC();

        }
        else {
            ButtonPushA();
        }*/
        
		//Root = transform.root.gameObject;
        //magicunit = Root.transform.Find("MagicUnit").gameObject;

        //modeChange = magicunit.GetComponent<MagicModeChange>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPushC()
    {
        //modeChange.save = true;
        modeChange.attacking = false;

      

        drower.GetComponent<UnitMove_sin>().enabled = true;
       Ui_unit.GetComponent<UnitMenu>().active = false;
        unitmenu.SetActive(false);
		Debug.Log("Heal");
		//modeChange.Changed(2);
    }
    public void ButtonPushA() {
        //modeChange.save = true;
        modeChange.attacking = true;

       
        drower.GetComponent<UnitMove_sin>().enabled = true;
       Ui_unit.GetComponent<UnitMenu>().active = false;
        unitmenu.SetActive(false);
		Debug.Log("Attack");
		//modeChange.Changed(1);
    }
}
