#pragma strict

public var clic1:AudioClip;
public var clic2:AudioClip;
var loadskin:GUISkin;
var newskin:GUISkin;
var exitskin:GUISkin;

function OnGUI(){

		GUI.skin = newskin;
	    if(GUI.Button(Rect(Screen.width/2-Screen.width*0.138760,Screen.height/2+Screen.height*0.1315789,Screen.width*0.2775208,Screen.height*0.14802631)," ")){
	    	Application.LoadLevel(2);
	    	audio.clip = clic2;
	    	audio.Play();	    	
	    	WaitTillClipFinishesAndLoadLevel(6,2.3);
	    }


	    GUI.skin = loadskin;
	    if(GUI.Button(Rect(Screen.width/2-Screen.width*0.138760,Screen.height/2+Screen.height*0.2302631,Screen.width*0.2775208,Screen.height*0.14802631)," ")){
	    
	    }
	

		GUI.skin = exitskin;
		if(GUI.Button(Rect(Screen.width/2-Screen.width*0.138760,Screen.height/2+Screen.height*0.3289473,Screen.width*0.2775208,Screen.height*0.14802631)," ")){
		Application.Quit();
		}
	
}

function WaitTillClipFinishesAndLoadLevel(pantalla : int, seconds : float){
    yield WaitForSeconds(seconds);
    Application.LoadLevel(pantalla);
}