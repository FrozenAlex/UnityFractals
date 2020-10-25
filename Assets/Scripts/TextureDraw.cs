
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
	[SerializeField]
	int max_iterations = 100;

	void Start()
	{
		//Fetch the GameObject's Renderer component
		m_ObjectRenderer = GetComponent<Renderer>();

		texture = new Texture2D(1024, 1024);

		m_ObjectRenderer.materials[1].mainTexture = texture;

		float left = -1.75f;
		float top = -0.25f;
		float xside = 0.25f;
		float yside = 0.45f;

		int height = texture.height;
		int width = texture.width;

		// Set scale
		float scaleX = (xside + (left * -1)) / width;
		float scaleY = (yside + (top * -1)) / height;

		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{
				var cx = (x * scaleX) + left;
				var cy = (y * scaleY) + top;

				var c = new Complex(cx, cy);
				var z = new Complex(0, 0);

				int count = 0;

				while ((z.r * z.r + z.i * z.i < 4) && (count < max_iterations))
				{
					z = (z * z) + c;
					count++;
				}

				float result = 1f - ((1f / max_iterations) * count);

				// transform coordinates here
				texture.SetPixel(x, y, new Color(result, result, result, 1));
			}
		}
		texture.Apply();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
