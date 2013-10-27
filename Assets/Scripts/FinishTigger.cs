using UnityEngine;
using System.Collections;

public class FinishTigger : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private Texture2D fadeTexture;
    [SerializeField]
    private BowRenderer rainbow;
    private Transform player;
    
    private float animationTime = 0; //from 0 to 1


	void OnTriggerEnter(Collider other)
    {
        var movement = other.GetComponent<PlayerMovement>();
        if(movement)
        {
            movement.canControl = false;
            movement.gravity = -1;
            player = movement.transform;
            rainbow.GetComponent<LineRenderer>().enabled = true;
        }
	}
    
    void Update()
    {
        if(player)
        {
            var pos = player.position;
            pos.x = transform.position.x;
            player.position = pos;
            
            animationTime += Time.deltaTime * 0.5f;
            
            rainbow.target.localPosition = Vector3.up * animationTime * 100;
            
            if(animationTime > 1)
            {
                Application.LoadLevel(nextLevel);
            }
        }
    }
    
    void OnGUI()
    {
        if(player)
        {
            GUI.color = new Color(1,1,1,Mathf.Clamp01(animationTime + 0.1f));
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), fadeTexture);
        }
    }
}
