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

namespace HexTools.Performance
{
    public class FPSLocker : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private bool auto = true;
        [SerializeField] private int cap = 60;
#endif
        private void Awake()
        {
#if UNITY_EDITOR
            if (auto)
                Application.targetFrameRate = (int) Screen.currentResolution.refreshRateRatio.value;
            else
                Application.targetFrameRate = cap;
#else
        Application.targetFrameRate = (int) Screen.currentResolution.refreshRateRatio.value;
#endif
        }
    }
}

