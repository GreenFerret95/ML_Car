using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject groundPrefab;
    public float scale;
    public int dimensions;
    public int hightRange;
    
    public string colorHex_1;
    public string colorHex_2;

    void Start()
    {
        Color color_1;
        Color color_2;
        ColorUtility.TryParseHtmlString(colorHex_1, out color_1);
        ColorUtility.TryParseHtmlString(colorHex_2, out color_2);

        groundPrefab.transform.localScale = SetScale(groundPrefab);
        this.dimensions = SetDimensions(dimensions);
 
        float width = groundPrefab.GetComponent<Renderer>().bounds.size.x; // get the width of the plane
        Debug.Log(width);
        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {

                // temp ground height change test
                float y = Random.Range(1,hightRange) / 100f;
                // end temp

                GameObject clone = Instantiate(groundPrefab);
                // position the grid plane relative to the world center
                clone.transform.position = new Vector3((i * width) - (width * 2), 0, (j * width) - (width * 2));
                var r = clone.GetComponent<Renderer>();     // the renderer component for color setting
                // if z position is even
                if (i % 2 == 0)
                {
                    // if x position is even
                    if (j % 2 == 0) { r.material.SetColor("_Color", color_1); }
                    else { r.material.SetColor("_Color", color_2); }
                }
                else
                {
                    if (j % 2 == 0) { r.material.SetColor("_Color", color_2); }
                    else { r.material.SetColor("_Color", color_1); }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

/*
@params GameObject gameObject to set the scale for
@return Vector3 of the scale to be set
*/
    public Vector3 SetScale(GameObject gameObject)
    {
        if (scale == 0)        
            return new Vector3(1,1,1);        
        else        
            return new Vector3(scale, scale, scale); 
    }

    public int SetDimensions(int d){
        if(d==0){
            return 2;
        }
        else{
            return d;
        }
    }
}
