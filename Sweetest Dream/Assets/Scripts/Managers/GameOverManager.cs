using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
