using UnityEngine;
using System.Collections;

public class Cuerpo_animacion6 : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(2) < vida) == true)
		{
			vida = GameManager.getLife(2);
			an.SetTrigger("golpe");
		}
	}
}
