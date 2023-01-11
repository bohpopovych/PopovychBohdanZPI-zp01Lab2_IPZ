using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            SceneManager.LoadScene(_sceneToLoad);
    }
}
