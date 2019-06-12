using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleARCore.Examples.HelloAR;

public class walk_script : MonoBehaviour
{	
	private Animator m_Animator;
	private double player_health;
	public AudioClip zombieAudio;
	public AudioClip attackAudio;
	AudioSource audio;
	public int startingHealth = 3;
    public int currentHealth;  
    HelloARController player;


	void Start()
	{
        m_Animator = gameObject.GetComponent<Animator>();
        float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
        print("Distance to other: " + dist);
        currentHealth = startingHealth;
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = zombieAudio;

        audio.Play();
    }

    void Update()
    {	

    	player = GameObject.Find("Example Controller").GetComponent<HelloARController>();

    	if(currentHealth <= -100){
	        Destroy(gameObject);
        }

        try{
        	if(currentHealth == 0){
    	        gameObject.GetComponent<Animator>().ResetTrigger("Start");
    	        gameObject.GetComponent<Animator>().ResetTrigger("Attack");
    	        gameObject.GetComponent<Animator>().SetTrigger("Die");
    	        audio.Stop();
        		player.zkills += 1;
        		currentHealth -= 1;
            }
        } catch(Exception e){
                player.zkills += 1;
                Destroy(gameObject);
                Debug.LogException(e, this);
        }

        if(currentHealth < 0){
        	currentHealth -= 1;
        }
    	
    	float dist = Vector3.Distance(Camera.main.transform.position, transform.position);
    	if(dist > 1.3){
    		m_Animator.ResetTrigger("Attack");
			m_Animator.SetTrigger("Start");
			audio.clip = zombieAudio;
	    	transform.LookAt(Camera.main.transform.position);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
		} else {
			
        	audio.Play();
			m_Animator.ResetTrigger("Start");
			m_Animator.SetTrigger("Attack");
			audio.clip = attackAudio;
			player.curHealth -= 0.25;
			
		}
    }
}
