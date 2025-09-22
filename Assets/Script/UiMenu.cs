using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiMainMenu : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private CanvasGroup panelPause;   // Panel de pausa
    [SerializeField] private CanvasGroup panelOptions; // Panel de opciones
    [SerializeField] private CanvasGroup panelCredits; // Panel de cr�ditos

    [Header("Botones")]
    [SerializeField] private Button btnPlay;         // Bot�n para pausar/reanudar
    [SerializeField] private Button btnOptions;      // Bot�n para abrir opciones
    [SerializeField] private Button btnCredits;      // Bot�n para abrir cr�ditos
    [SerializeField] private Button btnExit;         // Bot�n para salir del juego
    [SerializeField] private Button btnOptionsBack;  // Bot�n para volver desde opciones
    [SerializeField] private Button btnCreditsBack;  // Bot�n para volver desde cr�ditos

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
        // Detectar tecla Escape para abrir/cerrar men�s
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
        // Mostrar cr�ditos y ocultar pausa
        FadePanel(panelCredits, true);
        FadePanel(panelPause, false);
    }

    private void HideCredits()
    {
        // Ocultar cr�ditos y mostrar pausa
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