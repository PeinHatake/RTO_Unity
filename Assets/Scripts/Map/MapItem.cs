using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapItem : MonoBehaviour
{
    public MapData map { get; set; }
    public MapDataModule mapModule { get; set; }
    
#if UNITY_EDITOR
    //[SerializeField] private SpriteAtlas mapMainAtlas, bgAtlas;
    [SerializeField] private SpriteRenderer mapMain;
    [SerializeField] private SpriteRenderer[] mapBgRenderers;
    [SerializeField] private Transform[] mapBgTransforms;
    [SerializeField] private PolygonCollider2D boundaryBoxColliderArea;
    
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tileBase;
    [SerializeField] private int[][] data;
    
    public void GenMainMap()
    {
        SetMainMapSprite();
        GenTileMap();
        GenMapBackground();
    }
    private void SetMainMapSprite()
    {
        //var sprite = mapMainAtlas.GetSprite($"{map.id}");
        var sprite = mapModule.listMapMain[map.id];
        mapMain.sprite = sprite;
        Vector2 spriteSize = sprite.bounds.size;
        
        var points = new Vector2[4];
        points[0] = new Vector2(-spriteSize.x / 2, -spriteSize.y / 2);
        points[1] = new Vector2(spriteSize.x / 2, -spriteSize.y / 2);
        points[2] = new Vector2(spriteSize.x / 2, spriteSize.y / 2);
        points[3] = new Vector2(-spriteSize.x / 2, spriteSize.y / 2);
        
        boundaryBoxColliderArea.points = points;

        var cam = FindObjectOfType<CinemachineConfiner>();
        if (cam != null)
        {
            cam.m_BoundingShape2D = boundaryBoxColliderArea;
        }
    }
    private void GenMapBackground()
    {
        if (map.imgBgr.Length <= 0) return;
        SetStartBg(0);
        GenMoreBg(0);
        if (map.imgBgr.Length <= 1) return;
        SetStartBg(1);
        GenMoreBg(1);
        if (map.imgBgr.Length <= 2) return;
        SetStartBg(2);
        GenMoreBg(2);
    }
    private void SetStartBg(int _indexBg)
    {
        var sprite = mapModule.listMapBg[map.imgBgr[_indexBg]];
        //var sprite = bgAtlas.GetSprite($"{map.imgBgr[_indexBg]}");
        mapBgRenderers[_indexBg].sprite = sprite;
        
        var leftEdgeBig = mapMain.bounds.min.x;
        var leftEdgeSmall = mapBgRenderers[_indexBg].bounds.min.x;

        // Tính toán sự điều chỉnh cần thiết để đặt mép bên trái của SpriteRenderer nhỏ trùng với mép bên trái của SpriteRenderer lớn
        var adjustment = leftEdgeBig - leftEdgeSmall;

        // Áp dụng sự điều chỉnh này vào vị trí của SpriteRenderer nhỏ
        var smallSpritePosition = mapBgRenderers[_indexBg].transform.position;
        smallSpritePosition.x += adjustment;
        mapBgRenderers[_indexBg].transform.position = smallSpritePosition;
    }
    private void GenMoreBg(int _indexBg)
    {
        var bgBefore = mapBgRenderers[_indexBg];
        while (bgBefore.bounds.max.x <= mapMain.bounds.max.x)
        {
            var bgMore = Instantiate(mapBgRenderers[_indexBg], mapBgTransforms[_indexBg]);
            var rightEdgeBgBefore = bgBefore.bounds.max.x;
            var leftEdgeBgAfter = bgMore.bounds.min.x;

            var adjustment = rightEdgeBgBefore - leftEdgeBgAfter;

            var transformBg = bgMore.transform;
            var smallSpritePosition = transformBg.position;
            smallSpritePosition.x += adjustment;
            transformBg.position = smallSpritePosition;
            bgBefore = bgMore;
        }
    }
    private void GenTileMap()
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
        for (var j = 0; j < data[0].Length; j++)
        {
            tilemap.SetTile(new Vector3Int(j, 1, 0), tileBase); 
        }
        for (var i = 0; i < data.Length; i++)
        {
            for (var j = 0; j < data[i].Length; j++)
            {
                tilemap.SetTile(new Vector3Int(j, -i, 0), data[i][j] == 1 ? tileBase : null); 
            }
        }

        AdjustTileX();
        AdjustTileY();
    }

    private void AdjustTileX()
    {
        var colliderTileMap = tilemap.GetComponent<CompositeCollider2D>();
        var leftEdgeBig = mapMain.bounds.min.x;
        var leftEdgeSmall = colliderTileMap.bounds.min.x;

        // Tính toán sự điều chỉnh cần thiết để đặt mép bên trái của SpriteRenderer nhỏ trùng với mép bên trái của SpriteRenderer lớn
        var adjustment = leftEdgeBig - leftEdgeSmall;

        // Áp dụng sự điều chỉnh này vào vị trí của SpriteRenderer nhỏ
        var smallSpritePosition = colliderTileMap.transform.position;
        smallSpritePosition.x += adjustment;
        tilemap.transform.position = smallSpritePosition;
    }
    private void AdjustTileY()
    {
        var colliderTileMap = tilemap.GetComponent<CompositeCollider2D>();
        var botEdgeBig = mapMain.bounds.min.y;
        var botEdgeSmall = colliderTileMap.bounds.min.y;

        var adjustment = botEdgeBig - botEdgeSmall;

        var smallPosition = colliderTileMap.transform.position;
        smallPosition.y += adjustment;
        tilemap.transform.position = smallPosition;
    }
    // [Button]
    // public void GetDataFromJson()
    // {
    //     var textData = dataMap.text;
    //     map = JsonUtility.FromJson<MapData>(textData);
    // }
#endif
}
