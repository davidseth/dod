using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFade : MonoBehaviour
{
    public GameManager gameManager;
    public Image FadeImg;
    public float fadeSpeed = 5f;
    public bool sceneStarting = true;

    void OnEnable()
    {
        Messenger<string>.AddListener("Player", OnReact);
    }

    void OnDisable()
    {
        Messenger<string>.RemoveListener("Player", OnReact);
    }

    void OnReact(string message)
    {
        if (message == "dead")
        {
            EndScene("main");
        }
    }

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        gameManager = GameObject.FindObjectOfType<GameManager>();
        FadeImg.color = Color.black;
    }

    void Update()
    {

        // If the scene is starting...
        if (Input.anyKey && sceneStarting)
        {
            Debug.Log("A key or mouse click has been detected");

            // ... call the StartScene function.
            StartScene();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            gameManager.Ded();
        }
    }


    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
    }


    void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }


    public IEnumerator EndSceneRoutine(string sceneName)
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
        do
        {
            // Start fading towards black.
            FadeToBlack();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public void EndScene(string sceneName)
    {
        sceneStarting = false;
        StartCoroutine("EndSceneRoutine", sceneName);
    }
}