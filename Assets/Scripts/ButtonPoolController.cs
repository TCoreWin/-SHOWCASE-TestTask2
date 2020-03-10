using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPoolController : Singleton<ButtonPoolController>
{
    [SerializeField] private int poolCount;
    [SerializeField] GameObject buttonPrefab;

    public static Dictionary<GameObject, ButtonItem> buttons = new Dictionary<GameObject, ButtonItem>();
    private Queue<GameObject> currentButtons = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject prefab = Instantiate(buttonPrefab);
            ButtonItem script = prefab.GetComponent<ButtonItem>();
            prefab.SetActive(false);
            buttons.Add(prefab, script);
            currentButtons.Enqueue(prefab);
            prefab.transform.SetParent(transform);
        }
    }

    public void ReturnToPool(GameObject poolObj)
    {
        poolObj.SetActive(false);
        currentButtons.Enqueue(poolObj);
    }

    public GameObject GetButton(string disc)
    {
        if (currentButtons.Count < 1)
            ExpandPool();

        GameObject butItems = currentButtons.Dequeue();
        ButtonItem script = buttons[butItems];
        butItems.SetActive(true);
        butItems.transform.localScale = Vector3.one;
        script.SetText(disc);

        return butItems;
    }

    void ExpandPool()
    {
        GameObject prefab = Instantiate(buttonPrefab);
        ButtonItem script = prefab.GetComponent<ButtonItem>();
        prefab.SetActive(false);
        buttons.Add(prefab, script);
        currentButtons.Enqueue(prefab);
        prefab.transform.SetParent(transform);
    }
}
