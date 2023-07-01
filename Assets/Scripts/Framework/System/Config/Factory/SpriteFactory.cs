using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class SpriteFactory : SingletonScriptableObject<SpriteFactory>
    {
        [SerializeField] private List<Sprite> animal; public static List<Sprite> Animal { get { return Instance.animal; } }
        [SerializeField] private List<Sprite> fruit; public static List<Sprite> Fruit { get { return Instance.fruit; } }
        [SerializeField] private List<Sprite> geometry; public static List<Sprite> Geometry { get { return Instance.geometry; } }
        [SerializeField] private List<Sprite> homeAppliance; public static List<Sprite> HomeAppliance { get { return Instance.homeAppliance; } }
        [SerializeField] private List<Sprite> insect; public static List<Sprite> Insect { get { return Instance.insect; } }
        [SerializeField] private List<Sprite> learningTool; public static List<Sprite> LearningTool { get { return Instance.learningTool; } }
        [SerializeField] private List<Sprite> meanOfTransportation; public static List<Sprite> MeanOfTransportation { get { return Instance.meanOfTransportation; } }
        [SerializeField] private List<Sprite> vegetable; public static List<Sprite> Vegetable { get { return Instance.vegetable; } }
        [SerializeField] private List<Sprite> tree; public static List<Sprite> Tree { get { return Instance.tree; } }
        [SerializeField] private List<Sprite> worldWonder; public static List<Sprite> WorldWonder { get { return Instance.worldWonder; } }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            if (_instance == null)
            {
                Instance.ToString();
            }
        }
    }

}