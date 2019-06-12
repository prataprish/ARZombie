using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot_script : MonoBehaviour
{	
	private Button btn;
	public GameObject crossHair;
	public GameObject bullet_prefab;
	public GameObject bullet_spawn;
	public int bullet_count;
	public Text bullet_bar;

	AudioSource bulletAudio;

    void Start()
    {	
    	bullet_bar.text = bullet_count.ToString();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(delegate() { Shoot(); });
        bulletAudio = GetComponent<AudioSource>();
    }

    void Shoot()
    {	
    	if(bullet_count > 0){
			Ray ray = Camera.main.ScreenPointToRay(crossHair.transform.position);

			Vector3 fromGun = Camera.main.ScreenToWorldPoint(bullet_spawn.transform.position);
			// fromGun.z = 1f;
		    GameObject bullet = Instantiate(bullet_prefab, fromGun, bullet_spawn.transform.rotation) as GameObject;
		    Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

		    Vector3 direction = (ray.GetPoint(100000.0f) - bullet.transform.position).normalized;

		    bulletRigidbody.AddForce(direction * 12, ForceMode.Impulse);

		    bulletAudio.Play();
		    bullet_count -= 1;
		    bullet_bar.text = bullet_count.ToString();
		}

    }
}
