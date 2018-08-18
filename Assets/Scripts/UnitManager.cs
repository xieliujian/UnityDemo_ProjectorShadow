using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance = null;

    private const float GenRange = 50.0f;

    private List<GameObject> mUnitList = new List<GameObject>();

    public List<GameObject> UnitList
    {
        get { return mUnitList; }
    }

    #region 内置函数

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        Generate();
        mUnitList.Add(Player.Instance.gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #endregion

    #region 函数

    private void Generate()
    {
        for (int i = 0; i < 200; i++)
        {
            string prefabname = ((i % 2) == 0) ? "Female" : "Male";
            GameObject instgo = Resources.Load<GameObject>(prefabname);

            GameObject go = GameObject.Instantiate(instgo);
            mUnitList.Add(go);

            Vector3 pos = new Vector3(Random.Range(-GenRange, GenRange), 0.0f, Random.Range(-GenRange, GenRange));
            go.transform.position = pos;
        }
    }

    #endregion
}
