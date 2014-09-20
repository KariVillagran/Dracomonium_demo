using UnityEngine;
using System.Collections;

public class Cabeza_animacion2 : MonoBehaviour {

	public Animator an;
	int Dragon1 = 1000;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((GameManager.getLife(4) < Dragon1) == true)
		{
			Dragon1 = GameManager.getLife(4);
			an.SetTrigger("golpe");
		}
	}
}
