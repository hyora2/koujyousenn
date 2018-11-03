using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulCol : MonoBehaviour {

	private UnitStatus unitStatus;
	private SpriteRenderer damage;
	[SerializeField]
	private float wait;

	// Use this for initialization
	void Start () {
		GameObject parent = transform.root.gameObject;
		GameObject unit = parent.transform.Find("Ui&Unit/unit").gameObject;
		damage = unit.transform.Find("damage").gameObject.GetComponent<SpriteRenderer>();
		damage.enabled = false;
		unitStatus = unit.GetComponent<UnitStatus>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
		if (collision.gameObject.tag == "Unit")
		{
			UnitStatus status = collision.gameObject.GetComponent<UnitStatus>();
			if (status != null && unitStatus != null)
			{
				status.AddDamage(unitStatus.unitPower);
				damage.enabled = true;
				StartCoroutine("Span");
			}
		}
	}

	private IEnumerator Span()
	{

		yield return new WaitForSeconds(wait);

		damage.enabled = false;
	}
}
