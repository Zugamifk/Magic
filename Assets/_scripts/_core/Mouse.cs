using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	
    Vector3 mouseClick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0) && !Static.MouseBlocker.MouseIsBlocked()) {
			mouseClick = Input.mousePosition;
			Static.Fizzixer.AddRay(new Tuple<WorldObject, Ray>(Static.CameraController, Static.MainCamera.ScreenPointToRay(mouseClick)));
		}
	}
}

public partial class Static {
	public Mouse mouse;
	public static Mouse Mouse {
		get {return Instance.mouse;}
	}
}
