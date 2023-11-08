using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSelection : MonoBehaviour
{
    [SerializeField] private GeneratorScript generatorScript;
    [SerializeField] private int ruleSetIndex = 0;
    [SerializeField] private List<int[]> ruleSets = new List<int[]>();

    private void Start()
    {

        ruleSets.Add(new int[] { 0, 1, 0, 1, 1, 0, 1, 0 });
        ruleSets.Add(new int[] { 0, 1, 1, 0, 1, 1, 1, 0 });
        ruleSets.Add(new int[] { 0, 1, 1, 1, 1, 0, 0, 0 });
        ruleSets.Add(new int[] { 0, 0, 1, 1, 1, 1, 1, 0 });
    }

    public void ChangeRuleSet()
    {
        ruleSetIndex = (ruleSetIndex + 1) % ruleSets.Count;
        generatorScript.ClearGeneration();
        generatorScript.SetRuleSet(ruleSets[ruleSetIndex]);
        StartCoroutine(generatorScript.GenerateCoroutine());
    }
}
