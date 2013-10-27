using UnityEngine;
using System.Collections;

public class AwesomeEndingScript : MonoBehaviour
{
    public Renderer white;
    public TextMesh text;
    public Renderer colors;
    
    private float t = -1;

    
    void Update()
    {
        white.material.color = new Color(1,1,1, Mathf.Clamp01((transform.position.x - 130) / 40));
    

        if(t >= 0)
        {
            if(t < 1)
            {
                t = Mathf.Clamp01(t + Time.deltaTime * 0.3f);
            }
            text.color = new Color(0,0,0,t);
            colors.material.SetColor("_TintColor", new Color(.5f,.5f,.5f,.25f * t));
        }
        else if(transform.position.x > 164)
        {
            Destroy(GetComponent<PlayerMovement>());
            t = 0;
        }
        
    }
}
