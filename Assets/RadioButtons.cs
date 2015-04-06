/*
found at:http://forum.unity3d.com/threads/heres-a-radio-buttons-solution-radiobuttons.281018/
For Unity3D's new UI (4.6>)
 
Automatic, easy-to-use implementation of RadioButtons
(ie, exclusiveOr buttons, http://en.wikipedia.org/wiki/Radio_button)
 
(1) simply MAKE A PANEL (ie, UnityEngine.UI.Panel)
 
(2) put a few BUTTONS INSIDE THE PANEL (ie, UnityEngine.UI.Button)
 
(3) in the editor set the NAME (.name) of the EACH BUTTON to the logical
value you want for that button.  For example, "a", "b" and "c".
Note that the text on the button is irrelevant - use anything.
 
(4) Drop this script ON THE PANEL.
 
(5) That's it - it's all automatic.
 
Note -- if you leave the default value blank, it's the first one.
 
Note -- there's no problem having other items in the Panel (eg, labels etc)
 
Note -- just set the event (in the editor) same way as with all Unity UI controls
Simply look at the value (.currentValue) when you get the onValueChanged callback.
 
Note -- the callback "onValueChanged" WILL NOT BE CALLED,
when the default is set at startup, etc etc.
only when user pushes a button or you call ForceToValue().
 
Note -- call ForceToValue() to change (display and currentValue) programmatically.
if you send a nonexistent value it goes to the default.
 
Note -- this script is self-contained. No extensions etc needed.
 
Note -- it simply uses white / blue for the selected.
If you really need to change that, it's easy
*/

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadioButtons:MonoBehaviour
{
	public string defaultValue;
	
	public UnityEvent onValueChanged;
	[NonSerialized] public string currentValue;
	
	public void ForceToValue(string v)
	{
		_oneRadioButtonLiterallyClicked(v);
	}
	
	///////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		_setup();
		_unselectAll();
		_selectDefault();
	}
	
	//// private ...
	
	void Start()
	{
	}
	
	private void _setup()
	{
		int k=0;
		var tts = gameObject.GetComponentsInChildren<Transform>();
		foreach ( Transform tt in tts )
		{
			if ( tt.GetComponent<Button>() )
			{
				Button bb = tt.GetComponent<Button>();
				string val = tt.name;
				Debug.Log("\t\t\tIn RadioButtons " +gameObject.name +" there's a button: " +val);
				bb.onClick.AddListener(delegate { _oneRadioButtonLiterallyClicked(val); });
				k++;
			}
		}
		Debug.Log("\t\t\tIn RadioButtons " +gameObject.name +" there are count buttons: " +k);
		if (k==0) Debug.Log("\t\t\tYOU HAVE AN EMPTY RadioButton Panel, named " +gameObject.name);
	}
	
	public void _oneRadioButtonLiterallyClicked(string v)
	{
		_unselectAll();
		_selectValue(v);
		onValueChanged.Invoke();
	}
	
	/// set the whole group ...
	
	private void _unselectAll()
	{
		var tts = gameObject.GetComponentsInChildren<Transform>();
		foreach ( Transform tt in tts )
		{
			if ( tt.GetComponent<Button>() )
			{
				Button bb = tt.GetComponent<Button>();
				_unselectedStyle(bb);
			}
		}
	}
	
	private void _selectValue(string v)    // select this named button; and set the currentValue
	{
		var tts = gameObject.GetComponentsInChildren<Transform>();
		foreach ( Transform tt in tts )
		{
			if ( tt.GetComponent<Button>() )
			{
				if ( tt.name == v )
				{
					Button bb = tt.GetComponent<Button>();
					_selectedStyle(bb);
					currentValue = tt.name;
					//Debug.Log(currentValue);
					return;
				}
			}
		}
		Debug.Log("\t\t\tNON-EXISTENT VALUE " +v +" for RadioButton Panel, named " +gameObject.name);
		_selectDefault();
	}
	
	private void _selectDefault()    // if dev has not set default in editor, use first one
	{
		if ( defaultValue == "" )
		{
			_selectFirstOne();
			return;
		}
		
		var tts = gameObject.GetComponentsInChildren<Transform>();
		foreach ( Transform tt in tts )
		{
			if ( tt.GetComponent<Button>() )
			{
				if ( tt.name == defaultValue )
				{
					Button bb = tt.GetComponent<Button>();
					_selectedStyle(bb);
					currentValue = tt.name;
					return;
				}
			}
		}
		Debug.Log("\t\t\tNON-EXISTENT DEFAULT VALUE on RadioButton Panel, named " +gameObject.name);
		currentValue = "";
	}
	
	private void _selectFirstOne()
	{
		var tts = gameObject.GetComponentsInChildren<Transform>();
		foreach ( Transform tt in tts )
		{
			if ( tt.GetComponent<Button>() )
			{
				Button bb = tt.GetComponent<Button>();
				_selectedStyle(bb);
				currentValue = tt.name;
				//Debug.Log(currentValue);
				return;
			}
		}
		Debug.Log("\t\t\tYOU HAVE AN EMPTY RadioButton Panel, named " +gameObject.name);
		currentValue = "";
	}
	
	/// set colors on Button ...
	
	private void _unselectedStyle(Button bb)        // ie, "white"
	{
		ColorBlock cb = bb.colors;
		cb.normalColor = Color.white;
		cb.highlightedColor = Color.white;
		bb.colors = cb;
	}
	
	private void _selectedStyle(Button bb)        // ie, "blue"
	{
		ColorBlock cb = bb.colors;
		cb.normalColor = Color.blue;
		cb.highlightedColor = Color.blue;
		bb.colors = cb;
	}
}


/*
For testing, make a script UnitTest, attach to say the camera.
On your RadioButtons (say, "motorSpeed"), be sure to set the
OnValueChanged callback to
 
using UnityEngine;
 
public class UnitTest:MonoBehaviour
    {
    void Awake()
        {
        InvokeRepeating("_teste",3.0f,3.0f);
        }
 
    void _teste()
        {
        GameObject.Find("motorSpeed").GetComponent<RadioButtons>().ForceToValue("c");
        // "c" is one of the values (that is, the .name) of one of your buttons
        }
 
    public void ClickedExample()
        {
        Debug.Log("Testing: motorSpeed changed to .. "+
            GameObject.Find("motorSpeed").GetComponent<RadioButtons>().currentValue );
        }
    }
*/