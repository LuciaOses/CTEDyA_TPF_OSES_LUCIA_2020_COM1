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
						Consulta = "Distancia desde la Raiz al planeta de IA es: " + Nivel;
						return Consulta;
				}

					// No es planeta de la IA 		
					else
						if(!arbol.esHoja()) 	//No es una hoja 
								foreach( var hijo in arbolaux.getHijos())
								c.encolar(hijo);

			}
			
		}
	
		return Consulta;	
		}
		
		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			ArbolGeneral<Planeta> arbolaux;
			int Nivel= 0;     //cuenta los niveles
			int Planeta= 0; //cuenta los planetas
			string Consul= "";
	
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
						Consul += "La cantidad de planetas con poblacion mayor a 10 son: " + Planeta + " en el Nivel " + Nivel + "\n";
						Nivel ++;         //incremento nivel
						Planeta = 0;      //reinicio contador planeta
						
				}
					// Si desencolo un nodo
				else{
					// Si es planeta con poblacion mayor a diez.
					if (arbolaux.getDatoRaiz().Poblacion() > 10)
						Planeta = Planeta +1;
					if(!arbol.esHoja()) 	//No es una hoja 
						foreach( var hijo in arbolaux.getHijos())
							c.encolar(hijo);

			}
					
		}
			return Consul;	
		}
		
		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			ArbolGeneral<Planeta> arbolaux;
			int Nivel= 0;     //cuenta los niveles
			int Planeta= 0; //cuenta los planetas
			int Poblacion= 0; //cuenta la poblacion por planeta
			string Consu= "\n\n\n"; //Agrego espacios iniciales asi no se superponene los strings.
	
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
						Consu += "El promedio de Poblacion es: " + Poblacion/Planeta + " en el Nivel " + Nivel + "\n";
						Nivel ++;         //incremento nivel
						Planeta = 0;      //reinicio contador planeta
						Poblacion=0;      //reinicio contador poblacion
				}
					// Si desencolo un nodo
				else{
					// Si es planeta con poblacion mayor a diez.
					Planeta ++;
					Poblacion = Poblacion + arbolaux.getDatoRaiz().Poblacion();
					if(!arbol.esHoja()) 	//No es una hoja 
						foreach( var hijo in arbolaux.getHijos())
							c.encolar(hijo);

			}
					
		}
			return Consu;
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			//Implementar
			
			return null;
		}
	}
}

