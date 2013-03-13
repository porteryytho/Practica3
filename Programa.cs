using System;
using System.Collections;

namespace tarea3
{
	public class Programa
	{
		private Hashtable datos;

		public Programa ()
		{
			this.datos = new Hashtable();
		}
		public void muestraMenu(){
			Console.WriteLine("Menu");
			Console.WriteLine("1 editar");
			Console.WriteLine("2 eliminar");
			Console.WriteLine("3 mostrar todos");
			Console.WriteLine("4 salir");
			Console.WriteLine("que opcion elige?");
		}



		public void leerEntrada ()
		{

			int opcion = int.Parse (Console.ReadLine ());
			do{
			switch(opcion)
				{
			case 1:
				Console.Clear();
				Console.WriteLine ("editar");
				this.editar();
				System.Console.Read();

				break;
			case 2:
				Console.Clear();
				Console.WriteLine ("eliminar");
				this.eliminar();
				System.Console.Read();

				break;
			case 3:
				Console.Clear();
				Console.WriteLine ("mostrar todos");
				this.imprimirTodos();
				Console.WriteLine ("precione una tecla para continuar");
				System.Console.Read();
				Console.Clear();
				this.muestraMenu();
				this.leerEntrada();
				System.Console.Read();

				break;
			case 4: 
				Console.Clear();
				Console.WriteLine ("Saliendo");
				System.Console.Read();
				break;
			default:
				Console.Clear();
				Console.WriteLine ("error");
				break;
			}
			}while(opcion!=4);
	}

		public void capturar(){
			for(int i = 0; i<4;i++){
				Console.Clear();
				this.capturarDatosPersona(new Persona());
			}
		}
		private void capturarDatosPersona(Persona persona){
			this.capturarDatos(persona);
			this.agregarPersona(persona);
		}
		private void capturarDatos(Persona persona){
			Console.WriteLine("ingreso de los datos");
			if(persona.codigo == ""){
				Console.WriteLine("Introduzca el código");
				persona.codigo = Console.ReadLine();
			}
			
			Console.WriteLine("Introduzca el nombre");
			persona.nombre = Console.ReadLine();
			Console.WriteLine("Introduzca la dirección");
			persona.direccion = Console.ReadLine();
			Console.WriteLine("Introduzca el teléfono");
			persona.telefono = Console.ReadLine();
			Console.WriteLine("Introduzca el facebook");
			persona.facebook = Console.ReadLine();
		}
		
		private void agregarPersona(Persona persona){			
			if(this.datos.ContainsKey(persona.codigo)){
				this.datos.Remove(persona.codigo);
			}
			
			this.datos.Add(persona.codigo,persona);
		}

		public void editar(){
			for(int i = 0; i < 2; i++){
				Console.Clear();
				string codigo = "";
				Console.WriteLine("Introduzca el codigo que desea editar");
				codigo = Console.ReadLine();
				if(this.datos.ContainsKey(codigo)){
					Persona persona = (Persona)this.datos[codigo];
					this.imprimePersona(persona);
					this.capturarDatosPersona(persona);
				}else{
					this.imprimeError();
				}
			}
		}


		private void confirmarEliminacionYEliminar(string codigo){
			Console.WriteLine("¿Esta seguro que desea eliminar?");
			Console.WriteLine("0 = No, 1 = Si");
			string opcion = Console.ReadLine();
			if(opcion != "0"){
				this.datos.Remove(codigo);
			}
		}

		public void eliminar(){
			for(int i = 0; i < 2; i++){
				Console.Clear();
				string codigo = "";
				Console.WriteLine("Dame el código que desea eliminar");
				codigo = Console.ReadLine();
				if(this.datos.ContainsKey(codigo)){
					Persona persona = (Persona) this.datos[codigo];
					this.imprimePersona(persona);
					this.confirmarEliminacionYEliminar(persona.codigo);
				}else{
					this.imprimeError();
				}
			}
		}


		private void imprimeError(){
			Console.WriteLine("No existe el código.");
			Console.WriteLine("Presione cualquier tecla para continuar.");
			Console.ReadLine();
		}


		public void imprimirTodos(){
			ICollection personas = this.datos.Values;
			
			Console.WriteLine();
			foreach( object objeto in personas )
			{
				Persona persona = (Persona) objeto;
				this.imprimePersona(persona);
			}
		}
		
		private void imprimePersona(Persona persona){
			Console.WriteLine("Código: " + persona.codigo);
			Console.WriteLine("Nombre: " + persona.nombre);
			Console.WriteLine("Dirección: " + persona.direccion);
			Console.WriteLine("Teléfono: " + persona.telefono);
			Console.WriteLine("Facebook: " + persona.facebook);
			Console.WriteLine("");
		}

	}
}

