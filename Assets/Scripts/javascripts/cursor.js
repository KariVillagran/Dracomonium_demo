#pragma strict

	

    var yourCursor : Texture2D;  // Your cursor texture
    var cursorSizeX : int = 16;  // Your cursor size x
    var cursorSizeY : int = 16;  // Your cursor size y
     
    function Start()
    {
        Screen.showCursor = false;
    }
     
    function OnGUI()
    {
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, Screen.width*0.022201, Screen.height*0.0394736), yourCursor);
    }

