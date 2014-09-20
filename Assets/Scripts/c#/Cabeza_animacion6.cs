using UnityEngine;
using System.Collections;

public class Cabeza_animacion6 : MonoBehaviour {

	public Animator an;
	int Dragon1 = 1000;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((GameManager.getLife(2) < Dragon1) == true)
		{
			Dragon1 = GameManager.getLife(2);
			an.SetTrigger("golpe");
		}
	}
}
