using UnityEngine;
using System.Collections;

public class Texto : MonoBehaviour {

	public Transform panel;

	void Start()
	{
		panel.guiTexture.enabled = true;
		panel.position = Vector3.zero;
		panel.localScale = Vector3.zero;
		Rect pos = panel.guiTexture.pixelInset;
		pos.width = Screen.width;
		pos.height = Screen.height;
		panel.guiTexture.pixelInset = pos;
		panel.guiTexture.enabled = true;
		StartCoroutine(Detener(2.2f));

	}

	IEnumerator Detener(float seconds){
		yield return new WaitForSeconds(seconds);
		panel.guiTexture.enabled = false;
	}


}
