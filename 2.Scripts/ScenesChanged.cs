using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanged : MonoBehaviour
{
    private static int currentSaveSceneNum = 0;

    public bool TestMod = false;

    private void Awake()
    {
        if (TestMod == true)
        {
            MoveScene();
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Empty"))
            MoveScene();
    }

    /// <summary>
    /// 기존 씬에서 다른씬으로 이동 시 실행  메인 씬 에서 실행 시 예) 매인씬 -> 엠프티 -> 게임씬
    /// </summary>
    public void MoveScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main"))
        {
            ScenesChanged.currentSaveSceneNum = 1;
            SceneManager.LoadScene("Empty");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            ScenesChanged.currentSaveSceneNum = 0;
            SceneManager.LoadScene("Empty");
        }
        else
        {
            if (currentSaveSceneNum == 0)
                SceneManager.LoadScene("Main");
            else
                SceneManager.LoadScene("Game");
        }
    }
}