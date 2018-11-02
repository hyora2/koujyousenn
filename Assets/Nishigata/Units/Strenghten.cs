using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strenghten : MonoBehaviour {
    public GameObject unitmenu;
    //public GameObject point;
    public GameObject unit;
    public GameObject drower;
    public GameObject Ui_unit;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPush()
    {
        //point = GameObject.FindWithTag("PointCount");
        //point.GetComponent<PointCont>().Point -= 20;
        unit.GetComponent<UnitStatus>().unitPower += 20;
        drower.GetComponent<UnitMove_sin>().enabled = true;
        Ui_unit.GetComponent<UnitMenu>().active = false;
        unitmenu.SetActive(false);


    }
}
