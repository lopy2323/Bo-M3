using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class buildman : MonoBehaviour
{
    public Dictionary<Vector3Int, arrowtower> arrowtowers = new Dictionary<Vector3Int, arrowtower>();
    public static buildman _instance;
    private Sprite buildingsprite;
    private int checkedtype = 0;
    private bool checkednum = false;
    private int towernum { get;  set; } = 0;
    private Vector3 mousepos;
    private GameObject previewTower;

    public enum TowerType
    {
        None,
        Arrow,
        Litning,
        Fireball
    }
    public enum BuildState
    {
        None,
        followmouse,
        build
    }

    public TowerType type = TowerType.None;
    public BuildState buildmode = BuildState.None;

    [SerializeField]private GameObject ArrowTower;
    [SerializeField]private GameObject LitningTower;
    [SerializeField] private GameObject FireballTower;

    
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
         mousepos = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (towernum == 0 && checkednum == false) 
        {
            checkednum = true;
            return;
        }
        if (towernum == 1 && checkednum == false)
        {
            type = TowerType.Arrow;
            checkednum = true;
            return;
        }
        if (towernum == 2 && checkednum == false)
        {
            type = TowerType.Litning;
            checkednum = true;
            return;
        }
        if (towernum == 3 && checkednum == false)
        {
            type = TowerType.Fireball;
            checkednum = true;
            return;
        }
        if (type == TowerType.Arrow)
        {
            if (checkedtype == 0)
            {
                buildingsprite = ArrowTower.GetComponent<SpriteRenderer>().sprite;
                buildmode = BuildState.followmouse;

                previewTower = new GameObject("ArrowTowerPreview");
                SpriteRenderer sr = previewTower.AddComponent<SpriteRenderer>();
                sr.sprite = buildingsprite;
                sr.color = new Color(1f, 1f, 1f, 0.5f);
                sr.sortingOrder = 1;

                checkedtype = 1;
                Debug.Log("Arrow Tower Preview Created");
            }
            if (buildmode == BuildState.followmouse)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Vector3Int cellPosition = new Vector3Int(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y), 0);
                mousepos = cellPosition;
                previewTower.transform.position = new Vector3(cellPosition.x + 0.5f, cellPosition.y + 0.5f, 0f);
                if (Input.GetMouseButtonDown(0))
                {
                    if (!arrowtowers.ContainsKey(cellPosition) && GridManager.instance.GetTileData(cellPosition).road == false)
                    {
                        Instantiate(ArrowTower, new Vector3(cellPosition.x + 0.5f, cellPosition.y + 0.5f, 0f), Quaternion.identity);
                        arrowtowers.Add(cellPosition, ArrowTower.GetComponent<arrowtower>());
                        towernum = 0;
                        checkedtype = 0;
                        checkednum = false;
                        buildmode = BuildState.None;
                        type = TowerType.None;
                        Destroy(previewTower);
                        Debug.Log($"Arrow Tower built at {cellPosition}");
                    }
                }
            }

        }
    }


}
