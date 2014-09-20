#pragma strict

private var pauseGame : boolean = false;
private var showGUI : boolean = false;

function Update () {
	if(Input.GetKeyDown("p"))
		{
			pauseGame = !pauseGame;
			
			if(pauseGame == true)
			{
				Time.timeScale = 0;
				pauseGame = true;
				AudioListener.pause= true;
				Screen.lockCursor = true;
				showGUI = true;
			}
		}
		
		if(pauseGame == false)
		{
			Time.timeScale = 1;
			pauseGame = false;
			AudioListener.pause= false;
			Screen.lockCursor = false;
			showGUI = false;
		}
		if(showGUI == true)
		{
			  gameObject.Find("PausedGUI").guiTexture.enabled = true;
			  gameObject.Find("PausedGUI").transform.position = Vector3.zero;
			  gameObject.Find("PausedGUI").transform.localScale = Vector3.zero;
			  gameObject.Find("PausedGUI").guiTexture.pixelInset.width = Screen.width;
			  gameObject.Find("PausedGUI").guiTexture.pixelInset.height = Screen.height;
		}    
		else
		{
			gameObject.Find("PausedGUI").guiTexture.enabled = false; 
		}
}