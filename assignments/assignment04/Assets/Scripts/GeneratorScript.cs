using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;

    private int[] _cells;
    private int[] _ruleset;
    private List<GameObject> _objectPool = new List<GameObject>();

    private Vector3 _startPos = new Vector3(0, 0, 0);
    private int _currentGeneration = 0;
    private const int _maxGeneration = 100;
    private const int _rowCellsCount = 201;
    private const float _spacing = 1;
    private const float _zOffsetPerGeneration = 1;
    private const float _generationInterval = 0.2f;

    private void Awake()
    {
        _cells = new int[_rowCellsCount];
        _cells[_rowCellsCount / 2] = 1;
        InitializeObjectPool();
    }

    private void InitializeObjectPool()
    {
        // The number of objects to instantiate and add to the object pool.
        const int objectPoolCount = 6308;

        for (int i = 0; i < objectPoolCount; i++)
        {
            GameObject obj = Instantiate(_objectPrefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            _objectPool.Add(obj);
        }
    }

    // Coroutine to generate new generations
    public IEnumerator GenerateCoroutine()
    {
        while (_currentGeneration < _maxGeneration)
        {
            Generate();
            yield return new WaitForSeconds(_generationInterval);
        }
    }

    // Reset and clear the generated objects and cell data
    public void ClearGeneration()
    {
        foreach (GameObject obj in _objectPool)
        {
            obj.SetActive(false);
        }

        // Reset the current generation count.
        _currentGeneration = 0;

        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = 0;
        }
    }

    // Set a new ruleset and clear the generation
    public void SetRuleSet(int[] newRuleSet)
    {
        _ruleset = newRuleSet;
        ClearGeneration();
        _cells[_rowCellsCount / 2] = 1;
    }

    private void Generate()
    {
        if (_objectPrefab == null)
        {
            Debug.LogError("Object prefab is not assigned.");
            return;
        }

        int centerCellIndex = _cells.Length / 2;
        float zOffset = _currentGeneration * _zOffsetPerGeneration;

        for (int i = 0; i < _cells.Length; i++)
        {
            // Calculate the position for each cell based on the generation and spacing
            Vector3 position = _startPos + new Vector3((i - centerCellIndex) * _spacing, 0, zOffset);

            if (_cells[i] == 1)
            {
                // Get an inactive object from the pool.
                GameObject obj = GetPooledObject();
                // Set the position of the object.
                obj.transform.position = position;
                obj.SetActive(true);
            }
        }


        // Create a new array to store the next generation of cells.
        int[] nextGen = new int[_cells.Length];

        for (int i = 1; i < _cells.Length - 1; i++)
        {
            // Calculate the next generation of cells based on the ruleset
            int left = _cells[i - 1];
            int me = _cells[i];
            int right = _cells[i + 1];
            nextGen[i] = Rules(left, me, right);
        }

        _cells = nextGen;
        _currentGeneration++;
    }

    private int Rules(int a, int b, int c)
    {
        // Apply rules to determine the next cell state based on the values of the three neighboring cells.
        string s = "" + a + b + c;
        int index = System.Convert.ToInt32(s, 2);
        return _ruleset[index];
    }

    private GameObject GetPooledObject()
    {
        foreach (GameObject obj in _objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
