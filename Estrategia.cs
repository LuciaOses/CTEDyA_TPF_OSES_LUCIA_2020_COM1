using System;
using System.Collections.Generic;
namespace DeepSpace
{
        //Clase Estrategia

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			ArbolGeneral<Planeta> arbolaux;
			int Nivel= 0; //cuenta los niveles
			string Consulta= "";
			c.encolar(arbol); //raiz a la cola
			c.encolar(null); //separador a la cola
			
			// Si la cola no es vacia
			while( ! c.esVacia())
			{
				// Si desencolo un separador
				arbolaux= c.desencolar();
				if (arbolaux == null)
				{
					if(! c.esVacia())  
					c.encolar(null);
					Nivel ++;         //incremento nivel
					
				}
				// Si desencolo un nodo
				else{
					// Si es planeta de la inteligencia artificial
					if (arbolaux.getDatoRaiz().EsPlanetaDeLaIA()){
						Consulta = "Distancia desde la Raiz al planeta de IA es:" + Nivel;
						return Consulta;
				}
						
					// No es planeta de la IA 		
					else
						foreach( var hijo in arbolaux.getHijos()) //<----El for es sobre arbolaux y no arbol, por eso quedaba en loop infinito.
								c.encolar(hijo);
					
					
					
					
				}
			}
			return Consulta;
		}
		

		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			return"imp";
			
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar";
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			//Implementar
			
			return null;
		}
	}
}
