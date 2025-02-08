
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject MenuList;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPauseGame()
    {
        if(isPaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        playerObject.GetComponent<AudioSource>().enabled = false;
        playerObject.GetComponent<PlayerSounds>().enabled = false;
        playerObject.GetComponent<Animator>().SetBool("isMoving", false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuObject.SetActive(true);

    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        playerObject.GetComponent<PlayerSounds>().enabled = true;
        if (!DialogueManager.Instance.InDialogue)
            playerObject.GetComponent<PlayerInput>().enabled = true;
        playerObject.GetComponent<AudioSource>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuObject.SetActive(false);
        ResetPauseUI();
    }
    private void ResetPauseUI()
    {
        foreach(Transform child in MenuList.transform)
        {
            child.gameObject.SetActive(false);
        }
        pauseStartMenuObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
