using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{

    public List<List<string>> ReadCSV(string file_name)
    {
        Debug.Log(file_name);
        TextAsset text_asset = Resources.Load(file_name, typeof(TextAsset)) as TextAsset;
        StringReader reader = new StringReader(text_asset.text);

        return csv(reader);
    }

    private List<List<string>> csv(StringReader reader)
    {
        List<List<string>> csv = new List<List<string>>();
        List<string> line = new List<string>();
        while (reader.Peek() > -1)
        {
            line = new List<string>();
            string str = reader.ReadLine();
            string[] value = str.Split(',');
            for (int i = 0; i < value.Length; i++)
            {
                line.Add(value[i]);
            }
            csv.Add(line);
        }
        reader.Close();
        return csv;
    }
}