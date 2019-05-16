using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject theCube;
	public LayerMask groundLayer;
	public Material canPlaceMaterial;
	public Material cantPlaceMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Renderer cubeRender = theCube.GetComponent<Renderer>();
		Bounds cubeBounds = cubeRender.bounds;

		if (Physics.Raycast(ray,out hit,100f,groundLayer))
		{
			theCube.SetActive(true);
			if (hit.normal.y == 1)
			{
				cubeRender.material = canPlaceMaterial;
				
			} else
			{
				cubeRender.material = cantPlaceMaterial;
			}

			theCube.transform.position = hit.point + new Vector3(0, cubeBounds.extents.y, 0);
		} else
		{
			theCube.SetActive(false);
		}

    }
}
