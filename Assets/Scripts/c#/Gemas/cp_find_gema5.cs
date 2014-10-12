using UnityEngine;
using System.Collections;

public class cp_find_gema5 : MonoBehaviour
{
	public static int seting;
	public static int gemaSel;
	public Sprite diamante;
	public Sprite cuarzo;
	public Sprite topacio;
	public Sprite rubi;
	
	void Start () {
		seting = 0;
	}
	
	void Update () {
		if(seting == 1)
		{
			setGema (gemaSel);
			this.renderer.enabled = true;
		}
		else
		{
			this.renderer.enabled = false;
		}
	}
	
	public void setGema(int gema)
	{
		if((int)Gemas.Diamante == gema)
		{
			this.transform.GetComponent<SpriteRenderer> ().sprite = diamante;
		}
		if((int)Gemas.Caurzo == gema)
		{
			this.transform.GetComponent<SpriteRenderer> ().sprite = cuarzo;
		}
		if((int)Gemas.Rubi == gema)
		{
			this.transform.GetComponent<SpriteRenderer> ().sprite = rubi;
		}
		if((int)Gemas.Topacio == gema)
		{
			this.transform.GetComponent<SpriteRenderer> ().sprite = topacio;
		}
	}
}

