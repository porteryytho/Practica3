using System;

namespace tarea3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Programa programa = new Programa();
			programa.capturar();
			Console.Clear();

			programa.muestraMenu();
			programa.leerEntrada();
			System.Console.Read();
			
		}
	}
}
