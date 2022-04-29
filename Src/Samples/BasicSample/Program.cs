﻿using Rehsa.Core;

Console.WriteLine("Hello, World!");


var rehsa = new Rehsa<testc>();
var y = rehsa.Collect(new testc()).Suspect(x => x.Testb.Testd.Age).EqualWith(20).Build().Check();

Console.WriteLine($"result is: {y}");





public class testc
{
    public testb Testb { get; set; }

    public testc()
    {
        Testb = new testb();
    }
}

public class testb
{
    public testd Testd { get; set; }

    public testb()
    {
        Testd = new testd();
    }
}

public class testd
{
    public int Age { get; set; }

    public testd()
    {
        Age = 18;
    }
}