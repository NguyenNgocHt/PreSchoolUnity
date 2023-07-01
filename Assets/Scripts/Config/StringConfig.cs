using Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringConfig : SingletonScriptableObject<StringConfig>
{
    [SerializeField] private string homeSceneName; public static string HomeSceneName { get { return Instance.homeSceneName; }}
    [SerializeField] private string loadSceneName; public static string LoadSceneName { get { return Instance.loadSceneName; } }
    [SerializeField] private string gliderSceneName; public static string GliderSceneName { get { return Instance.gliderSceneName; }}
    [SerializeField] private string merryGoRoundSceneName; public static string MerryGoRoundSceneName { get { return Instance.merryGoRoundSceneName; } }
    [SerializeField] private List<string> merryGoRoundQuestion; public static List<string> MerryGoRoundQuestion { get { return Instance.merryGoRoundQuestion; } }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        if (_instance == null)
        {
            Instance.ToString();
        }
    }
}
