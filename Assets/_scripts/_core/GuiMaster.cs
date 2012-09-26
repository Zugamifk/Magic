using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class GuiMaster : MonoBehaviour{
	
	List<GUIObject> main;
	// Use this for initialization
	void Start () {
		main = new List<GUIObject>();
		OpenWindow(buildMainToolbar());
	}
	
	// Update is called once per frame
	void OnGUI() {
		foreach(GUIObject o in main) {
			o.DrawElement();
		}
	}
	
	public GUIObject buildMainToolbar() {
		GUIObject res = new GUIObject("MainBar", new Rect(0, Screen.height-60, Screen.width, 60), "SDAF"), opts, spels;
		res.SetDrawAction((g) => {
			g.DrawAllChildren();	
		});
		
		opts = new GUIObject("OptionsBar", new Rect(0, 0, 300, 60), "");
			
		opts.AddChild(new GUIObject(
			"MagickWindow",
			new Rect(5, 5, 50, 50),
			"SPELLS",
			(g) => {
				if (GUI.Button(g.rect, g.text)) {ToggleWindow(buildSpellMakerWindow());}
			}
			));
		
		spels = new GUIObject("SpellBar", new Rect(opts.rect.width+15, 0, 300, 60), "dslkhsghj");
		
		res.AddChild(opts);
		res.AddChild(spels);
		
		return res;
	}
	
	public GUIObject buildSpellMakerWindow() {
		GUIObject res = new GUIObject(
				"SpellMaker",
				new Rect(15, 15, Screen.width-30, Screen.height-90),
				"SDGJK"
			);
		
		return res;
	}
	
	public bool isOpen(GUIObject window) {
		return main.Any((g) => g.name == window.name);
	}
	
	public bool OpenWindow(GUIObject window) {
		if (isOpen(window)) return false;
		main.Add(window);
        Static.MouseBlocker.AddRect(window.name, window.rect);
		return true;
	}
	
	public bool CloseWindow(GUIObject window) {
		if (isOpen(window)) {
			main = main.Where((g) => g.name != window.name).ToList();;
            Static.MouseBlocker.RemoveRect(window.name);
			return true;
		}
		return false;
	}
	
	public void ToggleWindow(GUIObject window) {
		if (isOpen(window))	CloseWindow(window);
		else  				OpenWindow(window);
	}
}

[System.Serializable]
public class GUIObject {
	public string name;
	public Rect rect;
	public string text;
	public delegate void DrawLambda(GUIObject g);
	private event DrawLambda draw;
	public List<GUIObject> children;
	public GUIObject(){name = ""; rect = new Rect(0, 0, 0, 0); text = ""; children = new List<GUIObject>();}
	public GUIObject(string n, Rect r, string t, DrawLambda l = null) {
		name = n; rect = r; text = t; draw = l; children = new List<GUIObject>();
	}
	public void DrawElement() {
		if (draw == null) {
			GUI.Box(rect, text)	;
			DrawAllChildren();
		} else {
			draw(this);	
		}
	}
	public void DrawAllChildren() {
		GUI.BeginGroup(rect);
		foreach (GUIObject child in children) {
		//	GUI.BeginGroup(child.rect);
			child.DrawElement();
		//	GUI.EndGroup();
		}
		GUI.EndGroup();
	}
	public List<GUIObject> GetChildren() {return children;}
	public void SetChildren(List<GUIObject> list) {children = list;}
	public void AddChild(GUIObject child) {children.Add(child);}
	public void SetDrawAction(DrawLambda d) {draw = d;}
}

public partial class Static {
	public GuiMaster guiMaster;
	public static GuiMaster GuiMaster {
		get {return Instance.guiMaster;}
	}

    public MouseBlocker mouseBlocker;
    public static MouseBlocker MouseBlocker {
        get {return Instance.mouseBlocker;}
    }
}