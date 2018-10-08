using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRenderer : MonoBehaviour {

	private float theta_scale;
	private int size;
	private LineRenderer lineRenderer;
	private MagicHealMode healMode;

	// Use this for initialization
	void Start () {
		theta_scale = 0.01f;
		size = (int)((2.0 * Mathf.PI) / theta_scale);
		size++;

		lineRenderer = gameObject.GetComponent<LineRenderer>();
		lineRenderer.startColor = Color.blue;
		lineRenderer.endColor = Color.red;
		lineRenderer.startWidth = 0.1f;
		lineRenderer.endWidth = 0.1f;
		lineRenderer.positionCount = size;
        
		healMode = gameObject.GetComponent<MagicHealMode>();
	}
	
	// Update is called once per frame
	void Update () {
		if (healMode.healing == true)
		{
			lineRenderer.enabled = true;
			DrawLine();
		}
		else
		{
			lineRenderer.enabled = false;
		}
	}

	private void DrawLine()
	{
		float theta = 0;
		for (int i = 0; i < size; i++)
		{
			theta += (2.0f * Mathf.PI * theta_scale);
			float x = 3 * Mathf.Cos(theta);
			float y = 3 * Mathf.Sin(theta);

			x += gameObject.transform.position.x;
			y += gameObject.transform.position.y;

			Vector3 pos = new Vector3(x, y, 0);
			lineRenderer.SetPosition(i, pos);
		}
	}
}
