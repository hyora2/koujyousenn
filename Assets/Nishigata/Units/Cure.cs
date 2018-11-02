using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour {

	public GameObject unitmenu;
    public GameObject point;
    public GameObject unit;
    public GameObject drower;

    // Use this for initialization
    void Start () {
        

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonPush()
    {
        point = GameObject.FindWithTag("PointCount");
        point.GetComponent<PointCont>().Point -= 10;
        unit.GetComponent<UnitStatus>().unitHp += 50;
        drower.GetComponent<UnitMove_sin>().enabled = true;
        unitmenu.SetActive(false);
        Debug.Log("cure");

       

    }
}
