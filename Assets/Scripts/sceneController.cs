using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    public void enemyDeath()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
