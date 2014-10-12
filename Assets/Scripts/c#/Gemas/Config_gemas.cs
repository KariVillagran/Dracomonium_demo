using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Config_gemas {
	static List<Gems> gemas1 = new List<Gems>();
	static List<Gems> gemas2 = new List<Gems>();

	public static void addGema1(Gems item)
	{
		gemas1.Add(item);
	}

	public static void addGema2(Gems item)
	{
		gemas2.Add(item);
	}

	public static int countJ1()
	{
		return gemas1.Count;
	}

	public static int countJ2()
	{
		return gemas2.Count;
	}

	public static List<Gems> getJ1()
	{
		return gemas1;
	}
	
	public static List<Gems> getJ2()
	{
		return gemas2;
	}

}





