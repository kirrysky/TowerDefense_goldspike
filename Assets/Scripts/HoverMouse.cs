using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoverMouse : MonoBehaviour {

	Transform hovered_object = null;
	Vector3 stored_scale = Vector3.one;
	
	private void FixedUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 50.0f))
		{

			if(hit.collider.gameObject.tag == "tower")
			{
				if(hovered_object != null)
				{
					hovered_object.transform.localScale = stored_scale;
				}

				hovered_object = hit.collider.transform;
				stored_scale = hovered_object.transform.localScale;
				hovered_object.transform.localScale = new Vector3(3.5f,1.5f,1.5f);
				if (Input.GetMouseButtonDown (0)) {
					switch (hit.collider.gameObject.name)
					{
					case "level1":
						SceneManager.LoadScene(1);
						break;
					case "level2":
						SceneManager.LoadScene(2);
						break;
					case "level3":
						SceneManager.LoadScene(3);
						break;
					case "level4":
						SceneManager.LoadScene(4);
						break;
					case "level5":
						SceneManager.LoadScene(5);
						break;
					case "endless":
						SceneManager.LoadScene(6);
						break;
					}
				}
			}
			Debug.Log(hit.collider.gameObject.name);
		}
	}
}
