using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision_bullet : MonoBehaviour
{   
	public GameObject object2;
	walk_script zombie;
    public Sprite fire;
    public Sprite nofire;
    Image firePow;

    void Start()
    {   
        firePow = GameObject.Find("Point").GetComponent<Image>();
        Debug.Log("bullet fired");
        firePow.sprite = fire;
    }

    void Update()
    {
      	for(int i = 0; i< 10000; i++){
            firePow.sprite = nofire;
        }
    }

    void OnCollisionEnter(Collision collision)
    {	
    	int loss = 2;
    	Debug.Log(collision.gameObject.name);
    	if(collision.gameObject.tag == "ZombieHead"){
    		loss = 10;
            collision.gameObject.SetActive(false);
    	}
    	zombie = collision.gameObject.transform.parent.gameObject.GetComponent<walk_script>();
    	zombie.currentHealth -= loss;
    	Instantiate(object2, transform.position, transform.rotation);
      	Destroy(gameObject);
    }
}
