using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Atom
{
    public string atomName;
    public int atomNumber;
    public string symbol;
    public string latinName;
    public GameObject gameobject;

    public Atom(int atomNumber, string name, string Symbol, string latinname)
    {
        this.atomNumber = atomNumber;
        this.atomName = name;
        this.symbol = Symbol;
        this.latinName = latinname;
    }

    public static Atom Create(string atomName)
    {
        using (var reader = new StreamReader(@"Assets\Atomdex.csv"))
        {
            reader.ReadLine();
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if(values[1].ToLower() == atomName.ToLower())
                {
                    return new Atom(int.Parse(values[0]), values[1], values[2], values[3]);
                }
            }
        }

        throw new ArgumentException("Ikkegyldigt atom");
    }

    public static Atom Create(int atomNumber)
    {
        using (var reader = new StreamReader(@"Assets\Atomdex.csv"))
        {
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                if (int.Parse(values[0]) == atomNumber)
                {
                    return new Atom(int.Parse(values[0]), values[1], values[2], values[3]);
                }
            }
        }

        throw new ArgumentException("Ikkegyldigt atom");
    }
}
