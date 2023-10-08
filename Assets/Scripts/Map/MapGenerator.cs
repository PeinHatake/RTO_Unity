using NaughtyAttributes;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
   [SerializeField] private int indexMap;
   [SerializeField] private MapItem mapPrefab;
   [SerializeField] private MapDataModule mapModule;

#if UNITY_EDITOR
   [Button]
   public void GenMap()
   {
       var mapIns = Instantiate(mapPrefab, transform);
       mapIns.name = $"Map_{indexMap}";
       mapIns.map = mapModule.listMap[indexMap];
       mapIns.mapModule = mapModule;
       mapIns.GenMainMap();
   }
#endif

    private void Awake()
    {
        var prefab = mapModule.listMap[indexMap].prefab;
        if (prefab != null)
        {
            Instantiate(prefab, transform);
        }
    }
}
