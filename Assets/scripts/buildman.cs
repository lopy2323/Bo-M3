using System.Collections.Generic;
using UnityEngine;

public class buildman : MonoBehaviour
{
    public Dictionary<Vector3Int, arrowtower> arrowtowers = new Dictionary<Vector3Int, arrowtower>();
    public static buildman _instance;
    public int buildmode = 0;

    private Sprite ArrowTower;
    private Sprite LitningTower;
    private Sprite FireballTower;
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
