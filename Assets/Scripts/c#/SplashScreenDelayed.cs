using UnityEngine;
using System.Collections;

public class SplashScreenDelayed : MonoBehaviour {
	public int level = 1;
	public float delayTime= 5;
	// Use this for initialization
	IEnumerator Start () {
	
		yield return new WaitForSeconds (delayTime);
		Application.LoadLevel (level);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) )
		{

			Application.LoadLevel(level);
		}
	}
}