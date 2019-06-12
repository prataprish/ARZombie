using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_with_child : MonoBehaviour
{
    void Update ()
	{
	    transform.position = transform.GetChild(0).gameObject.transform.position;
	}
}
