using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] GameObject[] ObjectsList;

    public static MonsterManager Instance;

    private const int MAX_APPEARING_TIMES = 2;
    private GameObject finalMonsterObject;
    private GameObject monsterObj;
    private Dictionary<GameObject, int> objectAppearingTimes;

    public GameObject[] GetGameObjects(){
        return ObjectsList;
    }

    private void Start()
    {
        if (!Instance)
            Instance = this;

        objectAppearingTimes = new Dictionary<GameObject, int>();
        foreach (var obj in ObjectsList)
            objectAppearingTimes.Add(obj, MAX_APPEARING_TIMES);

        HideAllPossibleObjects();
        SelectFinalMonsterObject();
        SelectRandomMonsterObject();
    }

    private void HideAllPossibleObjects()
    {
        foreach (var item in ObjectsList)
        {
            item.SetActive(false);
        }
    }

    private void SelectFinalMonsterObject()
    {
        finalMonsterObject = objectAppearingTimes.ElementAt(Random.Range(0, objectAppearingTimes.Count)).Key;
        objectAppearingTimes[finalMonsterObject]--;
    }

    public void SelectRandomMonsterObject()
    {
        if (monsterObj != null)
            monsterObj.SetActive(false);

        monsterObj = objectAppearingTimes.ElementAt(Random.Range(0, objectAppearingTimes.Count)).Key;
        objectAppearingTimes[monsterObj]--;
        monsterObj.SetActive(true);
    }
}
