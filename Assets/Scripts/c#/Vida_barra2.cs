using UnityEngine;
using System.Collections;

public class Vida_barra2 : MonoBehaviour {

	public Sprite spr;
	public Transform vida;
	float pos;
	public int draco;
	
	void Start () {
		pos = vida.transform.position.x;
	}
	
	void Update () {
		float restoDragon = selectDragon(draco);
		if(restoDragon <= 0)
		{
			vida.transform.GetComponent<SpriteRenderer>().sprite = null;
		}
		else
		{
			float porcentaje = (((restoDragon * 100f) / 1000f)/100f);
			Rect loc = spr.rect;
			loc.width = loc.width * porcentaje;
			Vector2 pv = new Vector2(0.5f,0.5f);	
			vida.transform.GetComponent<SpriteRenderer>().sprite = Sprite.Create(spr.texture,loc,pv,100.0f);
			
			if (porcentaje > 0.4f)
			{
				var posx2 = (0.56f * (1.08f-porcentaje)) * (-1);
				Vector3 newpos = vida.transform.position;
				newpos.x = pos + posx2;
				vida.transform.position = newpos;
			}
			if (porcentaje > 0.6f)
			{
				var posx1 = (0.56f * (1.05f-porcentaje)) * (-1);
				Vector3 newpos = vida.transform.position;
				newpos.x = pos + posx1;
				vida.transform.position = newpos;
			}
			if (porcentaje > 0.7f)
			{
				float posx0 = (0.56f * (1.01f-porcentaje)) * (-1);
				float newposx = pos + posx0;
				Vector3 newpos = new Vector3(newposx,vida.transform.position.y,vida.transform.position.z);
				newpos.x = pos + posx0;
				vida.transform.position = newpos;
			}
			if (porcentaje == 1)
			{
				Vector3 newpos = vida.transform.position;
				newpos.x = pos + 0;
				vida.transform.position = newpos;
			}
			else
			{
				var posx = (0.56f * (1.1f-porcentaje)) * (-1);
				Vector3 newpos = vida.transform.position;
				newpos.x = pos + posx;
				vida.transform.position = newpos;
			}
		}
	}
	
	float selectDragon(int dracon)
	{
		float a = 0;
		a = GameManager.getVida(dracon);
		return a;	
	}
}
