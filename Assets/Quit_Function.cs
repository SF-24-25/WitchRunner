using UnityEngine;
using UnityEngine.Accessibility;

public class Quit_Function : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Quit()
    {
        Debug.Log("Quit");
         Application.Quit();
    }
}
