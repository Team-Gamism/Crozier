using UnityEngine;
using UnityEngine.UI;

public class UI_Module : MonoBehaviour
{
    Image firstModuleBack;
    Image secondModuleBack;

    Image firstModuleImage;
    Image secondModuleImage;

    Text firstTitle;
    Text secondTitle;
    Text firstModuleExplain;
    Text secondModuleExplain;

    ModuleSO firstModuleSO;
    ModuleSO secondModuleSO;

    private void Start()
    {
        firstModuleBack = Util.FindChild<Image>(gameObject,"FirstModuleBack",true);
        secondModuleBack = Util.FindChild<Image>(gameObject, "SecondModuleBack",true);
        firstModuleImage = Util.FindChild<Image>(gameObject, "FirstModuleImage", true);
        secondModuleImage = Util.FindChild<Image>(gameObject, "SecondModuleImage", true);

        firstTitle = Util.FindChild<Text>(firstModuleBack.gameObject, "Title");
        secondTitle = Util.FindChild<Text>(secondModuleBack.gameObject, "Title");
        firstModuleExplain = Util.FindChild<Text>(firstModuleBack.gameObject, "Explain");
        secondModuleExplain = Util.FindChild<Text>(secondModuleBack.gameObject, "Explain");

        ModuleController.Instance.setModuleUIAction = SetModuleUI;
        ModuleController.Instance.GetModuleImformationToTile(0);
    }

    public void SetModuleUI()
    {
        ModuleController.Instance.SetModuleImforation(ref firstModuleSO,ref secondModuleSO);

        if(firstModuleSO != null)
        {
            firstModuleBack.gameObject.SetActive(true);
            firstModuleImage.sprite = firstModuleSO.moduleImage;
            firstTitle.text = firstModuleSO.moduleName;
            firstModuleExplain.text = firstModuleSO.moduleExplain;
        }
        else
        {
            firstModuleBack.gameObject.SetActive(false);
        }

        if (secondModuleSO != null)
        {
            secondModuleBack.gameObject.SetActive(true);
            secondModuleImage.sprite = secondModuleSO.moduleImage;
            secondTitle.text = secondModuleSO.moduleName;
            secondModuleExplain.text = secondModuleSO.moduleExplain;
        }
        else
        {
            secondModuleBack.gameObject.SetActive(false);
        }
    }
}
