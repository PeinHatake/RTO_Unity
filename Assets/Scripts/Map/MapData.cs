using System;

[Serializable]
public struct MapData
{
    public int id;
    public string name;
    public int type;
    public int planeId;
    public int row;
    public int column;
    public int[] imgBgrs;
    public string[] colorBgrs;
    public string data;
}
