using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using UnityEngine.UI;

public class OnClickButtonChangeScene : MonoBehaviour
{
    [SerializeField] protected ESceneName sceneName;
    private Button buttonChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        buttonChangeScene = transform.GetComponent<Button>();
        buttonChangeScene.onClick.AddListener(OnClickChangeScene);
    }
    private void OnClickChangeScene()
    {
        SceneTransitionHelper.Load(sceneName);
    }
}
