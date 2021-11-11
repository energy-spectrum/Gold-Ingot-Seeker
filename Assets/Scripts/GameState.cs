using UnityEngine;
using UnityEngine.UI;
public class GameState
{
    private Transform canvas;
    private GameObject restartPanelPrefab;
    private int numberAwards, numberShovels, numberCollectedAwards;
    private Text numberShovelsText, numberAwardsText, rightAmountAwardsText;
    public GameState(int inputNumberAwards, int inputNumberShovels, GameObject restartPanelPrefab, Transform canvas, 
                     Text numberShovelsText, Text numberAwardsText, Text rightAmountAwardsText)
    {
        this.numberAwards = inputNumberAwards;
        this.numberShovels = inputNumberShovels;

        this.restartPanelPrefab = restartPanelPrefab;
        this.canvas = canvas;

        this.numberShovelsText = numberShovelsText;
        this.numberAwardsText = numberAwardsText;
        this.rightAmountAwardsText = rightAmountAwardsText;

        InitializeTextUI(inputNumberShovels, inputNumberAwards);
    }
    private void InitializeTextUI(int inputNumberShovels, int inputNumberAwards)
    {
        numberShovelsText.text = inputNumberShovels.ToString();
        rightAmountAwardsText.text = inputNumberAwards.ToString();
        numberAwardsText.text = "0";
    }
    public bool GameIsOver()
    {
        if(numberAwards == numberCollectedAwards)
        {
            CreateRestartPanel(true);
        }
        else if(numberShovels == 0){
            CreateRestartPanel(false);
        }
        else
        {
            return false;
        }
        return true;
    }


    public void IncreaseNumberCollectedAwards()
    {
        numberCollectedAwards += 1;

        numberAwardsText.text = numberCollectedAwards.ToString();
    }

    public void ReduceNumberShovels()
    {
        numberShovels -= 1;

        numberShovelsText.text = numberShovels.ToString();
    }
  
    private void CreateRestartPanel(bool isWiner)
    {
        Object.Instantiate(restartPanelPrefab, canvas);
    }
}