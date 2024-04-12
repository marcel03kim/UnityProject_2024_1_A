using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{
   public void GoToGame()
   {
        SceneManager.LoadScene("ResultScene");
   }
   
}
