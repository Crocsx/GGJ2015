using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
    [System.Serializable]
    public class newButton
    {
        public string _name;
        public string _actionName;
        public bool _rotate;
        public Rect _rect;
        public Texture2D _icon;
    }
    public newButton[] buttonList;

    [System.Serializable]
    public class newText
    {
        public string _name;
        public bool _rotate;
        public Rect _rect;
        public Texture2D _icon;
    }
    public newText[] textList;
    // REMOVE ON RELEASE
    public bool Debug_UI = false;

    private float ScreenRatioX;
    private float ScreenRatioY;
    private GUIStyle style;
    private GameObject _camera;


    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
    }

    void Update()
    {
        ScreenRatioX = Screen.width *0.01f;
        ScreenRatioY = Screen.height * 0.01f;
    }
    void OnGUI()
    {
       LevelButton();
    }

    void AddButton(newButton thisButton, Rect rect)
    {
        GUI.Label(new Rect(rect.x + rect.width, rect.y + (rect.height * 0.1f), rect.width, rect.height), thisButton._name, style);
        Matrix4x4 Backup = GUI.matrix;
        Vector2 pivotPoint = new Vector2(rect.x + rect.width * 0.5f, rect.y + rect.height * 0.5f);
        float camRotation = (thisButton._rotate) ? -_camera.transform.eulerAngles.y + 180 : 0;
        GUIUtility.RotateAroundPivot(camRotation, pivotPoint);
        if (GUI.Button(rect, new GUIContent(thisButton._icon), style))
        {
            if (thisButton._name.Length > 0)
            {
                int numberRemaining = int.Parse(thisButton._name);
                if (numberRemaining > 0)
                    thisButton._name = (numberRemaining - 1).ToString();
            }
            ActionButton(thisButton._actionName);
        }
        GUI.matrix = Backup;
    }
    void AddText(newText thisText, Rect rect)
    {
        GUI.Label(new Rect(rect.x + rect.width, rect.y + (rect.height * 0.1f), rect.width, rect.height), thisText._name, style);
        Matrix4x4 Backup = GUI.matrix;
        Vector2 pivotPoint = new Vector2(rect.x + rect.width * 0.5f, rect.y + rect.height * 0.5f);
        float camRotation = (thisText._rotate) ? -_camera.transform.eulerAngles.y + 180 : 0;
        GUIUtility.RotateAroundPivot(camRotation, pivotPoint);
        GUI.matrix = Backup;
    }
    public string getNextLevelName()
    {
        string[] nextLevel = Application.loadedLevelName.Split('_');
        if (nextLevel[1].Length >0)
        {
            int nextLevelNum = int.Parse(nextLevel[1])+1;
            string nextLevelName = (nextLevelNum < 10) ? "Level_0" : "Level_";
            return nextLevelName + nextLevelNum.ToString();
        }
        return "Menu";
    }

    public void LevelButton()
    {
        if (!Debug_UI)
            GUI.backgroundColor = Color.clear;

        //Button cases
        int l = buttonList.Length;
        for (var i = 0; i < l; i++)
        {
            newButton thisButton = buttonList[i];
            Rect rectangleScaled = new Rect(ScreenRatioX * thisButton._rect.x, ScreenRatioY * thisButton._rect.y, ScreenRatioX * thisButton._rect.width, ScreenRatioY * thisButton._rect.height);
            AddButton(thisButton, rectangleScaled);
        }

        l = textList.Length;
        for (var i = 0; i < l; i++)
        {
            newText thisText = textList[i];
            Rect rectangleScaled = new Rect((ScreenRatioX * thisText._rect.x), ScreenRatioY * thisText._rect.y, ScreenRatioX * thisText._rect.width, ScreenRatioY * thisText._rect.height);
            AddText(thisText, rectangleScaled);
        }
    }

    void ActionButton(string actionName)
    {
        string[] action = actionName.Split('%');
        if (action[0].Length > 0)
        {
            switch (action[0])
            {
                case "LoadLevel":
                    if (action[1].Length > 0)
                        Application.LoadLevel(action[1]);
                    break;
            }
        }
    }
}
