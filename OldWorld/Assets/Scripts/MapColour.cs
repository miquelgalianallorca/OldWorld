using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColour : MonoBehaviour
{
	public Color m_colour;

	SpriteRenderer m_SpriteRenderer;

	void Start()
  {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.color = m_colour;
	}
}
