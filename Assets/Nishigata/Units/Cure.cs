using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour {

	public GameObject unitmenu;
    public GameObject point;
    public GameObject unit;
    public GameObject drower;
    public GameObject Ui_unit;
    public int UsePoint = 10;
    public int CureHP=50;

    // Use this for initialization
    void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPush()
    {
        point = GameObject.FindWithTag("PointCount");
        point.GetComponent<PointCont>().Point -= UsePoint;
        unit.GetComponent<UnitStatus>().AddDamage(-CureHP);
        drower.GetComponent<UnitMove_sin>().enabled = true;
        Ui_unit.GetComponent<UnitMenu>().active = false;
        unitmenu.SetActive(false);
        Debug.Log("cure");

       

    }
}
