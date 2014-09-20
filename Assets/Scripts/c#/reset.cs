using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		calmao ();
		if (Input.GetMouseButtonDown (0)) {
						
						Application.LoadLevel (0);
				} 
	}
	IEnumerator calmao(){
		yield return new WaitForSeconds(5.0f);
	}
}
