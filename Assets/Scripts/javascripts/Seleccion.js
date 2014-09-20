#pragma strict


public var clic1:AudioClip;
public var clic2:AudioClip;
var izq:GUISkin;
var der:GUISkin;
var partir:GUISkin;
var atras:GUISkin;
var noele:GUISkin;
var escena:int;
var siguente:int;
var anterior:int;
var eselegible: int = 0;

function OnGUI(){
		
        GUI.skin = der;
	    if(GUI.Button(Rect(Screen.width/2+Screen.width*0.09158,Screen.height/2-Screen.height*0.344,Screen.width*0.0555,Screen.height*0.098684)," ")){
	    	audio.clip = clic1;
	    	audio.Play();	    	
	    	WaitTillClipFinishesAndLoadLevel(siguente,0.3);	    	
	    }
	    GUI.skin = izq;
		if(GUI.Button(Rect(Screen.width/2-Screen.width*0.148011,Screen.height/2-Screen.height*0.344,Screen.width*0.0555,Screen.height*0.098684)," ")){
			audio.clip = clic1;
	    	audio.Play();	    	
	    	WaitTillClipFinishesAndLoadLevel(anterior,0.3);
		}
		if (eselegible==1)
		{
		  GUI.skin = partir;
		  if(GUI.Button(Rect(Screen.width/2+Screen.width*0.249768,Screen.height/2+Screen.height*0.3453947,Screen.width*0.13876,Screen.height*0.1743421)," ")){
			audio.clip = clic2;
	    	audio.Play();	    	
	    	WaitTillClipFinishesAndLoadLevel(6,2.3);
		}
		}
		else{
		  GUI.skin = noele;
		   if(GUI.Button(Rect(Screen.width/2+Screen.width*0.249768,Screen.height/2+Screen.height*0.3453947,Screen.width*0.13876,Screen.height*0.1743421)," ")){}
			//something	    	
		}
		GUI.skin =atras;
	    if(GUI.Button(Rect(Screen.width/2-Screen.width*0.5041628,Screen.height/2-Screen.height*0.5016447,Screen.width*0.13876,Screen.height*0.148026)," ")){
			audio.clip = clic1;
	    	audio.Play();	    	
	    	WaitTillClipFinishesAndLoadLevel(1,0.3);
		}
}

function WaitTillClipFinishesAndLoadLevel(pantalla : int, seconds : float){
    yield WaitForSeconds(seconds);
    Application.LoadLevel(pantalla);
}