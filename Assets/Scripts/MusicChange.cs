using UnityEngine;
using System.Collections;

public class MusicChange : Activatable
{
    [RequireComponent (typeof (AudioSource))]
	void OnTriggerEnter(Collider other) 
    {
        if(isActive)
        {
           //TODO: play the right music file for each colour.
        }
	}
}
