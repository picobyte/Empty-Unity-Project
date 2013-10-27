using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MusicChange : Activatable
{
	void OnTriggerEnter(Collider other) 
    {
        if(isActive)
        {
           //TODO: play the right music file for each colour.
        }
	}
}
