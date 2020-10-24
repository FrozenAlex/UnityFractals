using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComplexMath;

public class TextureDraw : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	Texture2D texture;
	[SerializeField]
	Renderer m_ObjectRenderer;


	public Color get_color(int x, int y)
	{
		return new Color(22, 22, 22, 12);
	}

	void Start()
	{
		//Fetch the GameObject's Renderer component
		m_ObjectRenderer = GetComponent<Renderer>();

		texture = new Texture2D(1024, 2048);
		m_ObjectRenderer.materials[1].mainTexture = texture;

		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{
				// Triangle thing	
				// Color color = ((x & y) != 0 ? Color.white : Color.gray);
				Color color = new Color(222,222,222,222);

				texture.SetPixel(x, y, color);
				Debug.Log(new Complex(1,0));
			}
		}
		texture.Apply();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
