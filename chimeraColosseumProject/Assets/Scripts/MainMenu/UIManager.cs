using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnStartClicked() {
        SceneManager.LoadScene("CreatureLab");
    }
}
