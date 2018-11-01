using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    [SerializeField] private float range = 0.5f;
    private UnitStatus unitStatus;

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius = range;
        unitStatus = gameObject.GetComponent<UnitStatus>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (unitStatus.unitCheck == false)
        {
            enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
            unitMove.canMove = false;
        }
	}

	private void OnTriggerStay2D(Collider2D collision)
    {
		AttackRange attckRange = collision.gameObject.GetComponent<AttackRange>();
		if(attckRange != null){
            attckRange.Damage(unitStatus.unitPower);
        }

		if (collision.gameObject.tag == "Base")
		{
			BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
			baseStatus.damage(unitStatus.unitPower);
		}
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (unitStatus.unitCheck == false)
		{
			enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
			unitMove.canMove = true;
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
