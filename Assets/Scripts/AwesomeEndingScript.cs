﻿using UnityEngine;
using System.Collections;

public class AwesomeEndingScript : MonoBehaviour
{
    public Renderer white;
    public Renderer text;
    public Renderer colors;
    
    private float t = -1;

    
    void Start()
    {
        text.material.color = new Color(1,1,1,0);
    }
    
    void Update()
    {
        white.material.color = new Color(1,1,1, Mathf.Clamp01((transform.position.x - 130) / 40));
    
        if(transform.position.x > 180)
        {
            Destroy(GetComponent<PlayerMovement>());
            t = 0;
            //colors.material.SetColor("_TintColor", Color.white);
        }
        
        if(t >= 0)
        {
            if(t < 1)
            {
                t = Mathf.Clamp01(t + Time.deltaTime * 0.3f);
            }
            text.material.color = new Color(1,1,1,t);
        }
    }
}
