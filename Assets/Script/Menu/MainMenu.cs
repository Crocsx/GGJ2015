using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    [System.Serializable]
    public class HUDElement
    {
        public string _name;
        public bool _clickable;
        public string _actionName;
        public int _size;
        public Rect _rect;
        public Texture2D _icon;
    }

    [System.Serializable]
    public class SUBMenu
    {
        public string _name;
        public HUDElement[] buttonList;
    }
    public SUBMenu[] menuScreen;

    // REMOVE ON RELEASE
    public bool Debug_UI = false;

    private SUBMenu LevelToShow;

    void Start(){
        LevelToShow = findSubMenu("Menu");
    }
    void OnGUI()
    {
        float ScreenRatioX = Screen.width / 100;
        float ScreenRatioY = Screen.height / 100;

        if (!Debug_UI)
            GUI.backgroundColor = Color.clear;

        //Button cases
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 72;
        myStyle.normal.textColor = Color.white;
        //GUI.Label(new Rect(ScreenRatioY * 100, ScreenRatioY * 3, Screen.width, Screen.height), LevelToShow._name, myStyle);

        for (var i = 0; i < LevelToShow.buttonList.Length; i++)
        {
            HUDElement thisButton = LevelToShow.buttonList[i];
            myStyle.fontSize = thisButton._size;
            Rect rectangleScaled = new Rect(ScreenRatioX * thisButton._rect.x, ScreenRatioY * thisButton._rect.y, ScreenRatioX * thisButton._rect.width, ScreenRatioY * thisButton._rect.height);
            AddButton(thisButton, rectangleScaled);
        }
    }

    SUBMenu findSubMenu(string subMenuName)
    {
        for (var i = 0; i < menuScreen.Length; i++)
        {
            if(menuScreen[i]._name == subMenuName)
                return menuScreen[i];
        }
        return null;
    }

    void AddButton(HUDElement thisButton, Rect rect)
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 54;
        myStyle.normal.textColor = Color.white;
        if (!Debug_UI)
            GUI.backgroundColor = Color.clear;
        if (thisButton._clickable)
        {
            if (GUI.Button(rect, new GUIContent(thisButton._name, thisButton._icon), myStyle))
            {
                ActionButton(thisButton._actionName);
            }
        }
    }

    void ActionButton(string actionName)
    {
        string[] action = actionName.Split('%');
        if (action[0].Length > 0)
        {
            switch (action[0])
            {
                case "NewGame":
                    // Load Level 1 Application.LoadLevel();
                    break;
                case "Load LeveL":
                    // Affiche le menu des levels
                    break;
                case "loadSubMenu":
                    if (action[1].Length > 0)
                        LevelToShow = findSubMenu(action[1]);
                    break;
            }
        }
    }
}
