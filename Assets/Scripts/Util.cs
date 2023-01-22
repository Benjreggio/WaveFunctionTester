using System;
using System.IO;
using UnityEngine;

public class Util
{
	public static bool Contains(int[,] arr,int[] obj)
	{
        //Debug.Log(ArrayToString(arr));
		for(int i = 0; i<arr.GetLength(0); i++)
		{
			bool same = true;
			for (int j = 0; j < 3; j++)
            {
                if (arr[i, j] != obj[j])
                {
                    same = false;
                    break;
                }
            }
            if (same)
            {
                return true;
            }
		}
		return false;
	}

    public static string ArrayToString(int[,] arr)
    {
        string s = "";
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            int[] row = new int[arr.GetLength(1)];
            for (int i = 0; i < row.Length; i++)
            {
                row[i] = arr[j, i];
            }
            s = s + "\n" + ArrayToString(row);
        }
        return s;
    }

    public static string ArrayToString(int[] arr)
    {
        string s = "[";
        for(int i = 0; i < arr.Length - 1; i++)
        {
            s = s + arr[i].ToString() + ',';
        }
        s = s + arr[arr.Length-1].ToString();
        return s + "]";
    }

    public static string ArrayToString(bool[,] arr)
    {
        string s = "";
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            bool[] row = new bool[arr.GetLength(1)];
            for (int i = 0; i < row.Length; i++)
            {
                row[i] = arr[j, i];
            }
            s = s + "\n" + ArrayToString(row);
        }
        return s;
    }

    public static string ArrayToString(bool[] arr)
    {
        string s = "[";
        for (int i = 0; i < arr.Length - 1; i++)
        {
            s = s + arr[i].ToString() + ',';
        }
        s = s + arr[arr.Length - 1].ToString();
        return s + "]";
    }

    public Util()
	{
	}

    public static bool[,] GetRules(StreamReader sr)
    {
        string nextLine = sr.ReadLine();
        string ss = nextLine.Substring(4);
        int N = Int32.Parse(ss);
        bool[,] matRules = new bool[N,N];
        while(nextLine != null)
        {
            int d = nextLine.IndexOf('-');
            for(int i = 0; i < d; i++)
            {
                string[] firsts = nextLine.Substring(0, d).Split();
                int[] first = new int[firsts.Length];
                for(int j = 0; j < first.Length; j++)
                {
                    first[i] = Int32.Parse(firsts[j]);
                }
                string[] lasts = nextLine.Substring(0, d).Split();
                int[] last = new int[lasts.Length];
                for (int j = 0; j < last.Length; j++)
                {
                    last[i] = Int32.Parse(lasts[j]);
                }
                for (int k = 0; k < first.Length; k++)
                {
                    for (int j = 0; j < last.Length; j++)
                    {
                        matRules[k,j] = true;
                    }
                }
            }
        }
        return matRules;
    }
}
