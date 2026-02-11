using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get { return GetInstance(); }
    }

    private static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindFirstObjectByType<T>();
            if (instance == null)
            {
                new GameObject(typeof(T).ToString(), typeof(T));
            }
            else if (instance.gameObject.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(instance.gameObject);
            }
        }

        return instance;
    }

    public void Awake()
    {
        GetInstance();

        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Destroying duplicate {typeof(T)} component.");
            Destroy(this);
        }
    }
}
