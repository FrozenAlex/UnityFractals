
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
    int max_iterations = 30;




    public Color get_color(int x, int y)
    {
        var c = new Complex(0, 0);
        var z = new Complex(0, 0);

        if (x % 5 == 0)
        {
            return new Color(1, 1, 1, 1);
        }
        else
        {
            return new Color(0, 0, 0, 1);
        }

    }

    void Start()
    {
        //Fetch the GameObject's Renderer component
        m_ObjectRenderer = GetComponent<Renderer>();

        texture = new Texture2D(256, 512);

        m_ObjectRenderer.materials[1].mainTexture = texture;

        var left = -1.75;
        var top = -0.25;
        var xside = 0.25;
        var yside = 0.45;

        var height = texture.height;
        var width = texture.width;

        // Set scale
        var scaleX = xside / width;
        var scaleY = yside / height;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                var c = new Complex(x * scaleX + left, y * scaleY + top);
                var z = new Complex(0, 0);

                var count = 0;

                while (z.Module() < 4 && count < max_iterations)
                {
                    z = (z * z) + c;
                    count = count + 1;
                }


                var result = 1 - ((1 / max_iterations) * count);

                // transform coordinates here
                texture.SetPixel(x, y, new Color(result, result, result, 1));
                // Triangle thing	
                // Color color = ((x & y) != 0 ? Color.white : Color.gray);
                //Color color = new Color(222, 222, 222, 222);


            }
        }
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
