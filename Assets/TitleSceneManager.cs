using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class TitleSceneManager : MonoBehaviour
{
    public int inputs;
    public void ChangeScene()
    {
        SceneManager.LoadScene(inputs);
    }
}
