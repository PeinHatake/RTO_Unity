using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tileBase;
    [SerializeField] private Vector3Int position;
    [SerializeField] private TextAsset dataMap;
    [SerializeField] private MapData map;
    [SerializeField] private int[][] data;
    
    [Button]
    public void SetTileMap()
    {
        tilemap.SetTile(position, tileBase);
    }
    [Button]
    public void ClearTileMap()
    {
        tilemap.SetTile(position, null);
    }
    [Button]
    public void GetDataFromJson()
    {
        var textData = dataMap.text;
        map = JsonUtility.FromJson<MapData>(textData);
    }

    [Button]
    public void ConvertStringToInt()
    {
        int[][] resultArray = new int[map.row][];

        for (var i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = new int[map.column];
        }

        int currentIndex = 0;

        for (int i = 0; i < map.row; i++)
        {
            for (int j = 0; j < map.column; j++)
            {
                // Chuyển ký tự từ chuỗi thành số nguyên
                int digit = map.data[currentIndex] - '0';
                resultArray[i][j] = digit;

                currentIndex++; // Di chuyển đến ký tự tiếp theo trong chuỗi
            }
        }

        data = resultArray;
        
        tilemap.ClearAllTiles();
        for (var i = 0; i < data.Length; i++)
        {
            for (var j = 0; j < data[i].Length; j++)
            {
                tilemap.SetTile(new Vector3Int(-j, -i, 0), data[i][j] == 1 ? tileBase : null); 
            }
        }
    }
}
