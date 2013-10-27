using UnityEngine;
using System.Collections;

public class ActivateRendererOnStart : MonoBehaviour
{
	void Start()
    {
        renderer.enabled = true;
        Destroy(this);
	}
}
