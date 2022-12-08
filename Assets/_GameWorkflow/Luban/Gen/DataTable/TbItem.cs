//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace LubanConfig.DataTable
{

public sealed partial class TbItem
{
    private readonly Dictionary<int, DataTable.Item> _dataMap;
    private readonly List<DataTable.Item> _dataList;
    
    public TbItem(JSONNode _json)
    {
        _dataMap = new Dictionary<int, DataTable.Item>();
        _dataList = new List<DataTable.Item>();
        
        foreach(JSONNode _row in _json.Children)
        {
            var _v = DataTable.Item.DeserializeItem(_row);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, DataTable.Item> DataMap => _dataMap;
    public List<DataTable.Item> DataList => _dataList;

    public DataTable.Item GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DataTable.Item Get(int key) => _dataMap[key];
    public DataTable.Item this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    
    partial void PostInit();
    partial void PostResolve();
}

}