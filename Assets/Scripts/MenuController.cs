using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument menu;
    private Button botonA;
    private Button botonB;
    private Button botonC;
    private Button exit;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonA = root.Q<Button>("BotonA");
        botonB = root.Q<Button>("BotonB");
        botonC = root.Q<Button>("BotonC");
        exit = root.Q<Button>("Exit");
        
        botonA.RegisterCallback<ClickEvent, String>(Jugar, "EscenaMapa");
        botonB.RegisterCallback<ClickEvent, String>(Jugar, "EscenaAyuda");
        botonC.RegisterCallback<ClickEvent, String>(Jugar, "EscenaCreditos");
        exit.RegisterCallback<ClickEvent>(CerrarJuego);


    }

    private void CerrarJuego(ClickEvent evt)
    {   
        Debug.Log("Juego Cerrado");
        Application.Quit();
    }

    private void Jugar(ClickEvent evt, String nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }    
}
