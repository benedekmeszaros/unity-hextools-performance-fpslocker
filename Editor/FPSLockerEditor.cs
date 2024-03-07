/*
  _    _                     _                                  _                 _   _         
 | |  | |                   | |                                | |               | | (_)        
 | |__| |   ___  __  __   __| |   ___     __ _   ______   ___  | |_   _   _    __| |  _    ___  
 |  __  |  / _ \ \ \/ /  / _` |  / _ \   / _` | |______| / __| | __| | | | |  / _` | | |  / _ \ 
 | |  | | |  __/  >  <  | (_| | | (_) | | (_| |          \__ \ | |_  | |_| | | (_| | | | | (_) |
 |_|  |_|  \___| /_/\_\  \__,_|  \___/   \__, |          |___/  \__|  \__,_|  \__,_| |_|  \___/ 
                                          __/ |                                                 
                                         |___/             
*/
using UnityEngine;
using UnityEditor;

namespace HexTools.Performance.Editor
{
  [CustomEditor(typeof(FPSLocker))]
  public class FPSLockerEditor : UnityEditor.Editor
  {
    private SerializedProperty auto;
    private SerializedProperty cap;
    private int FPS { get => FPSToIndex(cap.intValue); set => cap.intValue = IndexToFPS(value); }

    private void OnEnable()
    {
      auto = serializedObject.FindProperty("auto");
      cap = serializedObject.FindProperty("cap");
    }

    public override void OnInspectorGUI()
    {
      EditorGUI.BeginChangeCheck();
      serializedObject.Update();
      EditorGUILayout.PropertyField(auto);
      GUI.enabled = !auto.boolValue;
      FPS = EditorGUILayout.Popup("FPS Cap", FPS, new string[] { "Uncapped", "244 FPS", "144 FPS", "75 FPS", "60 FPS", "30 FPS" });
      if (EditorGUI.EndChangeCheck())
      {
        Application.targetFrameRate = auto.boolValue ? Screen.currentResolution.refreshRate : cap.intValue;
        serializedObject.ApplyModifiedProperties();
      }
    }

    private int IndexToFPS(int index)
    {
      switch (index)
      {
        case 0: return -1;
        case 1: return 244;
        case 2: return 144;
        case 3: return 75;
        case 4: return 60;
        case 5: return 30;
        default: return -1;
      }
    }
    private int FPSToIndex(int FPS)
    {
      switch (FPS)
      {
        case -1: return 0;
        case 244: return 1;
        case 144: return 2;
        case 75: return 3;
        case 60: return 4;
        case 30: return 5;
        default: return 0;
      }
    }
  }
}


