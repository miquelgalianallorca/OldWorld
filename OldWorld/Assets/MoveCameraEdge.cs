using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraEdge : MonoBehaviour
{
	public int m_boundary = 50;
	public float m_speed = 15f;
	public bool m_bShowDebug = false;
	public float m_smoothTime = 0.3f; // Time it will take to reach the target with smoothDamp

	// Current velocity for smoothing movement
	private Vector3 velocity = Vector3.zero;

	// Move camera when mouse close to edge. On LateUpdate to happen after all other movement
	void LateUpdate()
	{
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
		Vector3 currentPosition = transform.position;
		bool bOnEdge = false;

		// Check if mouse is near edge
		if ((Input.mousePosition.x > screenWidth - m_boundary)
			|| (Input.mousePosition.x < 0 + m_boundary)
			|| (Input.mousePosition.y > screenHeight - m_boundary)
			|| (Input.mousePosition.y < 0 + m_boundary))
		{
			bOnEdge = true;
		}

		if (bOnEdge)
		{
			Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 dir = (cursorPosition - currentPosition).normalized;
			Vector3 targetPosition = currentPosition + dir * m_speed * Time.deltaTime;

			Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, m_smoothTime);
			transform.position = smoothedPosition;
		}
	}

	// Draw UI debugging
	void OnGUI()
	{
		if (m_bShowDebug)
		{
			// Mouse position
			GUI.Box(new Rect((Screen.width / 2) - 140, 5, 280, 25), "Mouse Position = " + Input.mousePosition);
			GUI.Box(new Rect((Screen.width / 2) - 70, Screen.height - 30, 140, 25), "Mouse X = " + Input.mousePosition.x);
			GUI.Box(new Rect(5, (Screen.height / 2) - 12, 140, 25), "Mouse Y = " + Input.mousePosition.y);
		}
	}
}
