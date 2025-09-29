using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    #region SceneManagement

    /// <summary>
    /// Load scene by name.
    /// </summary>
    public void LoadScene(string sceneName/*, LoadSceneMode mode = LoadSceneMode.Single*/)
    {
        SceneManager.LoadScene(sceneName/*, mode*/);
    }

    /// <summary>
    /// A public method to load a scene from a button.
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadSceneFromButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }    
    /// <summary>
    /// Reload current active scene.
    /// </summary>
    public void ReloadCurrentScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    /// <summary>
    /// Load scene asynchronously with optional delay or loading screen.
    /// </summary>
    public void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        StartCoroutine(AsyncScene(sceneName, mode));
    }
    
    public void CloseApplication()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
        #endif
    }
    
    private IEnumerator AsyncScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, mode);
        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    #endregion
}