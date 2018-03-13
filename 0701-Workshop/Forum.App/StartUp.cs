using Forum.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
            Engine engine = new Engine();
            engine.Run();
        }
	}
}
