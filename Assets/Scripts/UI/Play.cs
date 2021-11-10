using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject parametersPanel;
    public InputField inputField_N, inputField_M, inputField_H, inputField_K;

    private int inputN, inputM, inputH, inputK;
    public void PlayGame()
    {
        InitializeParameters();

        //СоздатьПоле(inputN, inputM, inputH, inputK);

        Destroy(parametersPanel);
    }
    private void InitializeParameters()
    {
        inputN = int.Parse(inputField_N.text);
        inputM = int.Parse(inputField_M.text);
        inputH = int.Parse(inputField_H.text);
        inputK = int.Parse(inputField_K.text);
    }
}
