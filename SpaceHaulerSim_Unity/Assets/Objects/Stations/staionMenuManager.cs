using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class staionMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeaveButton();
        }
    }

    public void AssignmentMenuButton()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(2, UnloadSceneOptions.None);
        Debug.Log("Assignment Menu");
    }

    public void CargobayButton()
    {
        SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(2, UnloadSceneOptions.None);
        Debug.Log("CargoBay Menu");
    }

    public void LeaveButton()
    {
        dockingScript.leave = true;
    }
}
