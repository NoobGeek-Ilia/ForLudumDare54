using UnityEngine;

public class InitPanelsButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FillSchemePanel fillSchemePanel;

    [SerializeField] private COnOffSwitch ConOffSwitch;
    [SerializeField] private CParameter Cparameter;
    [SerializeField] private CRotatingSwitch CrotatingSwitch;
    [SerializeField] private CSlider Cslider;
    [SerializeField] private CToggleSwitch CtoggleSwitch;

    [SerializeField] private SOnOffSwitch SonOffSwitch;
    [SerializeField] private SParameter Sparameter;
    [SerializeField] private SRotatingSwitch SrotatingSwitch;
    [SerializeField] private SSlider Sslider;
    [SerializeField] private SToggleSwitch StoggleSwitch;
    [SerializeField] private SFloorButtons SfloorButtons;

    private void Start()
    {
        gameManager.onBoxFull += () =>
        {
            ConOffSwitch.InitBoxButtons();
            Cparameter.InitBoxButtons();
            CrotatingSwitch.InitBoxButtons();
            Cslider.InitBoxButtons();
            CtoggleSwitch.InitBoxButtons();
        };
        fillSchemePanel.onBoxFull += () =>
        {
            SonOffSwitch.InitBoxButtons();
            Sparameter.InitBoxButtons();
            SrotatingSwitch.InitBoxButtons();
            Sslider.InitBoxButtons();
            StoggleSwitch.InitBoxButtons();
            SfloorButtons.InitBoxButtons();
        };
    }
}