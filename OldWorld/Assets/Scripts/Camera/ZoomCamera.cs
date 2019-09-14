using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
	public float m_zoomSpeed = 1;
	public float m_smoothSpeed = 2.0f;
	public float m_minOrtho = 1.0f;
	public float m_maxOrtho = 20.0f;

	float targetOrtho;

	void Start()
	{
		targetOrtho = Camera.main.orthographicSize;
	}

	void Update()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0.0f)
		{
			targetOrtho -= scroll * m_zoomSpeed;
			targetOrtho = Mathf.Clamp(targetOrtho, m_minOrtho, m_maxOrtho);
		}

		Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, m_smoothSpeed * Time.deltaTime);
	}
}
