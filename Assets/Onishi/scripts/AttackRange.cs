using System.Collections;
using System.Collections.Generic;
using UnityEngine;
       
public class AttckRange : MonoBehaviour {
   
    [SerializeField] private float range = 0.5f;
    private UnitStatus unitStatus;

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius = range;
        unitStatus = gameObject.GetComponent<UnitStatus>();
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        AttckRange attckRange = collision.gameObject.GetComponent<AttckRange>();
        if(attckRange != null){
            attckRange.Damage(unitStatus.unitPower);
        }
    }

    // Update is called once per frame
    void Update () {
        
      
	}
    public void Damage(int damage)
    {
        unitStatus.unitHp -= damage;
    }
}


