using UnityEngine;

public class InitPanelsButtons : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] FillSchemePanel fillSchemePanel;

    [SerializeField] COnOffSwitch ConOffSwitch;
    [SerializeField] CParameter Cparameter;
    [SerializeField] CRotatingSwitch CrotatingSwitch;
    [SerializeField] CSlider Cslider;
    [SerializeField] CToggleSwitch CtoggleSwitch;

    [SerializeField] SOnOffSwitch SonOffSwitch;
    [SerializeField] SParameter Sparameter;
    [SerializeField] SRotatingSwitch SrotatingSwitch;
    [SerializeField] SSlider Sslider;
    [SerializeField] SToggleSwitch StoggleSwitch;

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
        };
    }

}
