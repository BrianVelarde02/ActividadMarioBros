using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument menu;
    private Button botonA;
    private Button botonB;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonA = root.Q<Button>("BotonA");
        botonB = root.Q<Button>("BotonB");
        
        botonA.RegisterCallback<ClickEvent, String>(Jugar, "SampleScene");
        botonB.RegisterCallback<ClickEvent, String>(Jugar, "EscenaMapa");


    }

    private void Jugar(ClickEvent evt, String nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }    
}
