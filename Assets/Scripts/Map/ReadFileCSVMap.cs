using System;
using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
#if UNITY_EDITOR

public class ReadFileCSVMap : MonoBehaviour
{
    [SerializeField] private MapDataModule mapModule;
    public TextAsset csvFile; // Thả tệp TextAsset vào đây trong Inspector.
    [Button]
    public void ReadFile()
    {
        // Đọc nội dung của tệp TextAsset.
        string csvText = csvFile.text;

        // Chuyển đổi nội dung từ CSV thành danh sách MapData.
        List<MapData> mapDataList = ParseCsv(csvText);

        // Xử lý danh sách MapData theo cách bạn muốn ở đây.
        foreach (MapData mapData in mapDataList)
        {
            // Ví dụ: In ra các thuộc tính của từng MapData.
            Debug.Log($"ID: {mapData.id}, Row: {mapData.row}, Column: {mapData.column}, Data: {mapData.data}");
        }

        mapModule.listMap = mapDataList;
    }
    private static List<MapData> ParseCsv(string _csvText)
    {
        List<MapData> data = new List<MapData>();

        // Phân tích nội dung CSV thành danh sách MapData.
        string[] lines = _csvText.Split('\n');
        foreach (string line in lines)
        {
            string[] values = line.Split(';');

            // Kiểm tra xem có đủ số lượng trường trong hàng CSV hay không.
            if (values.Length >= 5)
            {
                var numBG = values[4].Substring(2, values[4].Length - 5);
                var dataMap = values[3].Substring(1, values[3].Length - 2);
                MapData mapData = new MapData();
                mapData.id = int.Parse(values[0]);
                mapData.row = int.Parse(values[1]);
                mapData.column = int.Parse(values[2]);
                mapData.imgBgr = Array.ConvertAll(numBG.Split(','), int.Parse);
                mapData.data = dataMap;

                data.Add(mapData);
            }
            else
            {
                Debug.LogWarning("Invalid CSV row: " + line);
            }
        }

        return data;
    }
}
#endif
