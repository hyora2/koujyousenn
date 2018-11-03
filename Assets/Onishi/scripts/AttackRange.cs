using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    [SerializeField] private float range = 0.5f;
    private UnitStatus unitStatus;
	private bool candamage;
	private SpriteRenderer damageRenderer;

	// Use this for initialization
	void Start () {
        GetComponent<CircleCollider2D>().radius = range;
        unitStatus = GetComponent<UnitStatus>();
		candamage = true;
		damageRenderer = transform.Find("damage").gameObject.GetComponent<SpriteRenderer>();
        damageRenderer.enabled = false;
	}
    
	private void OnTriggerEnter2D(Collider2D collision)
	{
		UnitStatus status = collision.gameObject.GetComponent<UnitStatus>();
		if (status != null && unitStatus != null)
		{
			if (unitStatus.unitCheck != status.unitCheck)
			{
				enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
				if (unitMove != null)
				    unitMove.canMove = false;
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
    {
		AttackRange attckRange = collision.gameObject.GetComponent<AttackRange>();
		if(attckRange != null && candamage == true){
			UnitStatus ustatus = collision.gameObject.GetComponent<UnitStatus>();
			if (ustatus.unitCheck != unitStatus.unitCheck)
			{
				candamage = false;
				ustatus.AddDamage(unitStatus.unitPower);
				StartCoroutine("Span");
			}
        }

        UnitStatus status = GetComponent<UnitStatus>();
        if (status != null)
        {
            if (collision.gameObject.name == "PlayerBase" && candamage == true && status.unitCheck == false)
            {
                candamage = false;
                BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.damage(unitStatus.unitPower);
                StartCoroutine("Span");
            }
            else if (collision.gameObject.name == "EnemyBase" && candamage == true && status.unitCheck == true)
            {
                candamage = false;
                BaseStatus baseStatus = collision.gameObject.GetComponent<BaseStatus>();
                baseStatus.damage(unitStatus.unitPower);
                StartCoroutine("Span");
            }
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (unitStatus.unitCheck == false)
		{
			enemyUnitMove unitMove = collision.gameObject.GetComponent<enemyUnitMove>();
			if (unitMove != null)
			    unitMove.canMove = true;
		}
	}

	// Update is called once per frame
	void Update () {


	}
    public void Damage(int damage)
    {
		damageRenderer.enabled = true;
        unitStatus.unitHp -= damage;
		StartCoroutine("SpanRend");
    }

	private IEnumerator Span()
	{

		yield return new WaitForSeconds(2f);

		candamage = true;
	}

	private IEnumerator SpanRend()
	{

		yield return new WaitForSeconds(0.5f);

		damageRenderer.enabled = false;
	}
}
