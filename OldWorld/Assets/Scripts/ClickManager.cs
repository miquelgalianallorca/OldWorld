using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
	GameObject m_selectedObject;

	void Update()
	{
		// Left click
		if (Input.GetMouseButtonDown(0))
		{
			m_selectedObject = GetClickedObject();
		}

		// Right click
		else if (Input.GetMouseButtonDown(1))
		{
			GameObject clickedObject = GetClickedObject();
			// ...
		}

		// Middle click
		else if (Input.GetMouseButtonDown(2))
		{
			GameObject clickedObject = GetClickedObject();
			// ...
		}
	}

	GameObject GetClickedObject()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
		if (hit.collider != null)
		{
			Debug.Log("Clicked: " + hit.collider.gameObject.name);
			return hit.collider.gameObject;
		}

		return null;
	}
}
