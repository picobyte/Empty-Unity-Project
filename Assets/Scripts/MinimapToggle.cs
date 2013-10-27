using UnityEngine;
using System.Collections;

public class MinimapToggle : MonoBehaviour
{
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            camera.enabled = !camera.enabled;
        }
	}
}
