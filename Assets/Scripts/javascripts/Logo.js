#pragma strict
@script RequireComponent(GUITexture)
@script RequireComponent(AudioSource)

var TiempoFade : float;
var TiempoEspera : float;
var TieneSonido : boolean;
var Sonido : AudioClip;

private var AS : AudioSource;

function fLogo () {
	
	yield Fade.use.Alpha(guiTexture, 0.0, 1.0, TiempoFade, EaseType.In);
	yield WaitForSeconds(TiempoEspera);
	yield Fade.use.Alpha(guiTexture, 1.0, 0.0, TiempoFade, EaseType.Out);
	yield WaitForSeconds(0.5);
	Application.LoadLevel(1);
	
}

function fSonido(){
	if(TieneSonido){
		AS.PlayOneShot(Sonido);
	}
}

function Start () {
	AS = GetComponent(AudioSource);
	fSonido();
	fLogo();
}