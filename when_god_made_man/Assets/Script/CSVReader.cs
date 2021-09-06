// CSVReader
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVReader
{
	private static string SPLIT_RE = ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";

	private static string LINE_SPLIT_RE = "\\r\\n|\\n\\r|\\n|\\r";

	private static char[] TRIM_CHARS = new char[1]
	{
		'"'
	};

	public static List<Dictionary<string, object>> Read(string file)
	{
		List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
		TextAsset textAsset = Resources.Load(file) as TextAsset;
		string[] array = Regex.Split(textAsset.text, CSVReader.LINE_SPLIT_RE);
		if (array.Length <= 1)
		{
			return list;
		}
		string[] array2 = Regex.Split(array[0], CSVReader.SPLIT_RE);
		for (int i = 1; i < array.Length; i++)
		{
			string[] array3 = Regex.Split(array[i], CSVReader.SPLIT_RE);
			if (array3.Length != 0 && !(array3[0] == string.Empty))
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				for (int j = 0; j < array2.Length && j < array3.Length; j++)
				{
					string text = array3[j];
					text = text.TrimStart(CSVReader.TRIM_CHARS).TrimEnd(CSVReader.TRIM_CHARS).Replace("\\", string.Empty);
					object value = text;
					int num = default(int);
					float num2 = default(float);
					if (int.TryParse(text, out num))
					{
						value = num;
					}
					else if (float.TryParse(text, out num2))
					{
						value = num2;
					}
					dictionary[array2[j]] = value;
				}
				list.Add(dictionary);
			}
		}
		return list;
	}
}
