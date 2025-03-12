using System;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    public static ModuleController Instance { get { return instance; }  set { instance = value; } }
    static ModuleController instance;

    private void Awake()
    {
        instance = this;
        GetModuleListToTile();
    }

    [SerializeField] ModuleSO moduleSO; 

    List<ModuleSO> ownedModuleList = new List<ModuleSO>();

    List<Tile> tileList = new List<Tile>();
    public class Tile
    {
        public ModuleSO firstModule;
        public ModuleSO secondModule;
    }

    ModuleSO firstModuleInfo = null;
    ModuleSO secondModuleInfo = null;

    public Action setModuleUIAction;

    //타일리스트 세팅
    void GetModuleListToTile()
    {
        for (int i = 0; i < 16; i++)
        {
            Tile tile = new Tile();
            tile.firstModule = moduleSO;
            tile.secondModule = moduleSO;
            tileList.Add(tile);
        }
    }

    public void GetModuleImformationToTile(int tileIndex)
    {
        firstModuleInfo = tileList[tileIndex].firstModule;
        secondModuleInfo = tileList[tileIndex].secondModule;

        setModuleUIAction.Invoke();
    }

    public void SetModuleImforation(ref ModuleSO firstModule,ref ModuleSO secondModule)
    {
        firstModule = firstModuleInfo;
        secondModule = secondModuleInfo;
    }
}
