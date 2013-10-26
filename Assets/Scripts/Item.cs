using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType _type;
    public ItemType type
    {
        get{ return _type; }
    }

	private Vector3 originalPosition;
	
	void Awake()
	{
		originalPosition = transform.position;
	}

	void OnTriggerEnter(Collider other)
	{
		var pitem = other.GetComponent<PlayerItem>();
		if(pitem)
        {
			pitem.OnReceiveItem(this);
		}
	}
    
    public void Return()
    {
        transform.position = originalPosition;
        StartCoroutine(Grow());
    }
    
    IEnumerator Grow()
    {
        transform.localScale = Vector3.zero;
        float size = 0;
        while(size < 1)
        {
            transform.localScale = Vector3.one * size;
            size += Time.deltaTime * 2;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}
