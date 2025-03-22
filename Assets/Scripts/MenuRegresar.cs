using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuRegresar : MonoBehaviour
{
    private UIDocument UIRegresar;
    private Button botonRegresar;

    void OnEnable()
    {
        UIRegresar = GetComponent<UIDocument>();
        var root = UIRegresar.rootVisualElement; 
        botonRegresar = root.Q<Button>("BotonRegresar");

        botonRegresar.RegisterCallback<ClickEvent, String>(RegresarMenu, "EscenaMenu");
    }

    private void RegresarMenu(ClickEvent evt, String nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
