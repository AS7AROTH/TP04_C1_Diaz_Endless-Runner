using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiMainMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private CanvasGroup panelPause;   // Panel de pausa
    [SerializeField] private CanvasGroup panelOptions; // Panel de opciones
    [SerializeField] private CanvasGroup panelCredits; // Panel de créditos

    [Header("Botones")]
    [SerializeField] private Button btnPlay;         // Botón para pausar/reanudar
    [SerializeField] private Button btnOptions;      // Botón para abrir opciones
    [SerializeField] private Button btnCredits;      // Botón para abrir créditos
    [SerializeField] private Button btnExit;         // Botón para salir del juego
    [SerializeField] private Button btnOptionsBack;  // Botón para volver desde opciones
    [SerializeField] private Button btnCreditsBack;  // Botón para volver desde créditos

    private void Awake()
    {
        // Asignar eventos a botones
        btnPlay.onClick.AddListener(TogglePause);
        btnOptions.onClick.AddListener(ShowOptions);
        btnCredits.onClick.AddListener(ShowCredits);
        btnExit.onClick.AddListener(ExitGame);
        btnOptionsBack.onClick.AddListener(HideOptions);
        btnCreditsBack.onClick.AddListener(HideCredits);
    }

    private void Update()
    {
        // Detectar tecla Escape para abrir/cerrar menús
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelOptions != null && panelOptions.gameObject.activeSelf)
                HideOptions();
            else if (panelCredits != null && panelCredits.gameObject.activeSelf)
                HideCredits();
            else
                TogglePause();
        }
    }

    private void OnDestroy()
    {
        // Limpiar listeners para evitar fugas de memoria
        btnPlay.onClick.RemoveAllListeners();
        btnOptions.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
        btnOptionsBack.onClick.RemoveAllListeners();
        btnCreditsBack.onClick.RemoveAllListeners();
    }

    private void TogglePause()
    {
        // Alternar pausa
        bool show = !panelPause.gameObject.activeSelf;
        FadePanel(panelPause, show);
        Time.timeScale = show ? 0 : 1; // Pausar o reanudar juego
    }

    private void ShowOptions()
    {
        // Mostrar opciones y ocultar pausa
        FadePanel(panelOptions, true);
        FadePanel(panelPause, false);
    }

    private void HideOptions()
    {
        // Ocultar opciones y mostrar pausa
        FadePanel(panelOptions, false);
        FadePanel(panelPause, true);
    }

    private void ShowCredits()
    {
        // Mostrar créditos y ocultar pausa
        FadePanel(panelCredits, true);
        FadePanel(panelPause, false);
    }

    private void HideCredits()
    {
        // Ocultar créditos y mostrar pausa
        FadePanel(panelCredits, false);
        FadePanel(panelPause, true);
    }

    private void ExitGame()
    {
        // Salir del juego
        Application.Quit();
    }

    private void FadePanel(CanvasGroup panel, bool show)
    {
        panel.alpha = show ? 1 : 0;
        panel.interactable = show;
        panel.blocksRaycasts = show;
        panel.gameObject.SetActive(show);
    }
}