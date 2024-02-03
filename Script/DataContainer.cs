using System.Collections.Generic;

public class DataContainer
{
    public static DataContainer Instance
    {
        get
        {
            if (instance == null)
            {
                Initialize();
            }
            return instance;
        }
    }
    private static DataContainer instance;

    private Dictionary<string, float> m_FloatDatas;
    private Dictionary<string, int> m_IntDatas;

    private static void Initialize()
    {
        instance = new DataContainer();
    }

    public void AddFloatData(string name, float value)
    {
        m_FloatDatas.Add(name, value);
    }
    public void AddIntData(string  name,int value)
    {
        m_IntDatas.Add(name, value);
    }

    /// <summary>
    /// Float型のDataを取得する
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public float GetFloatData(string name)
    {
        if (m_FloatDatas.ContainsKey(name))
        {
            return m_FloatDatas[name];
        }
        //データが見つからない場合は0
        return 0;
    }

    /// <summary>
    /// Int型のDataを取得する
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public int GetIntData(string name)
    {
        if (m_IntDatas.ContainsKey(name))
        {
            return m_IntDatas[name];
        }
        //データが見つからない場合は0
        return 0;
    }
}
