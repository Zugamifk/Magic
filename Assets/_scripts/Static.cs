using UnityEngine;
using System.Collections;

public partial class Static : MonoBehaviour{

	static Static instance;
	public void Awake(){
		instance=this;	
	}
    static Static Instance {
        get {
            if (!instance) {
                instance = FindObjectOfType(typeof(Static)) as Static;
            }
            return instance;
        }
    }
	
	public Camera mainCamera;
	public static Camera MainCamera {
		get {return Instance.mainCamera;}
	}
}
