using UnityEngine;
using System.Collections;

public class Cuerpo_animacion3 : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(5) < vida) == true)
		{
			vida = GameManager.getLife(5);
			an.SetTrigger("golpe");
		}
	}
}
