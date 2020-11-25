using System;
using System.Collections.Generic;
namespace DeepSpace
{
        class Estrategia
        {
        	Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			ArbolGeneral<Planeta> arbolaux;
			
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
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
			int Nivel= 0;     //cuenta los niveles
			int Planeta= 0; //cuenta los planetas
			int Poblacion= 0; //cuenta la poblacion por planeta
			string Consu= "\n\n\n";
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
					
					Planeta ++;
					Poblacion = Poblacion + arbolaux.getDatoRaiz().Poblacion();
					if(!arbol.esHoja()) 	//No es una hoja 
						foreach( var hijo in arbolaux.getHijos())
							c.encolar(hijo);

					}
					
		}
			return Consu;
		}
		
		public String Consulta4( ArbolGeneral<Planeta> arbol)
		{
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
					
					if (arbolaux.getDatoRaiz().EsPlanetaDelJugador()){
						Consulta = "Distancia desde la Raiz al planeta del Jugador es: " + Nivel;
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
		
		private void getEnemigo(ArbolGeneral<Planeta> arbol, List<Planeta> result, List<Planeta> best)
		{
			result.Add(arbol.getDatoRaiz());
			if (!arbol.getDatoRaiz().EsPlanetaDelJugador() && !arbol.esHoja()) {
				foreach (var hijo in arbol.getHijos()) { //Busco un camino
					this.getEnemigo(hijo, result, best);
				}
			} else {
				if (arbol.getDatoRaiz().EsPlanetaDelJugador()) {
					if (best.Count == 0 || result.Count < best.Count || best[best.Count - 1].EsPlanetaNeutral()) { //Encontre un mejor camino
						best.Clear();
						best.AddRange(result);
					}
				} else if (best.Count == 0) { //No hay mejor camino calculado, es la inicializacion del mejor camino es el primero encontrado
					best.AddRange(result);
				}
			}
			result.RemoveAt(result.Count - 1);
		}
		
		private Movimiento getEnemigoCercano(ArbolGeneral<Planeta> arbol)
		{
			List<Planeta> result = new List<Planeta>();
			List<Planeta> best = new List<Planeta>();
			this.getEnemigo(arbol, result, best);
			for (int i = best.Count - 2; i > 0; i--) {
				if (best[i].EsPlanetaDeLaIA()) {
					return new Movimiento(best[i], best[i + 1]); //Retorno el movimiento en el camino al planeta enemigo  mas cercano 
				}
			}
			return new Movimiento(best[0], best[1]);
			
		}
		
		private void getRaiz(ArbolGeneral<Planeta> arbol, List<Planeta> result, List<Planeta> best)
		{
			result.Add(arbol.getDatoRaiz());
			if (!arbol.getDatoRaiz().EsPlanetaDeLaIA() && !arbol.esHoja()) {
				foreach (var hijo in arbol.getHijos()) { //Busco un camino
					this.getRaiz(hijo, result, best);
				}
			} else {
				if (arbol.getDatoRaiz().EsPlanetaDeLaIA()) {
					if (best.Count == 0 || result.Count < best.Count || best[best.Count - 1].EsPlanetaNeutral()) { //Encontre un mejor camino
						best.Clear();
						best.AddRange(result);
					}
				} else if (best.Count == 0) { //No hay mejor camino calculado, es la inicializacion del mejor camino es el primero encontrado
					best.AddRange(result);
				}
			}
			result.RemoveAt(result.Count - 1);
		}
		
		private Movimiento getRaizIA(ArbolGeneral<Planeta> arbol)
		{
			List<Planeta> result = new List<Planeta>();
			List<Planeta> best = new List<Planeta>();
			this.getRaiz(arbol, result, best);
			for (int i = best.Count -1  ; i > 0; i ++) {
				if (best[i].EsPlanetaDeLaIA()) {
					return new Movimiento(best[i], best[i - 1]); //Retorno el movimiento en el camino al planeta enemigo  mas cercano 
				}
			}
			return new Movimiento(best[0], best[1]);
			
		}
		
	    public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			Movimiento mov = null;
			
			// Es planeta de la IA conquisto hacia planeta jugador
 			if (!arbol.getDatoRaiz().EsPlanetaDeLaIA())
 			{
 				mov = this.getRaizIA(arbol);
 			}
			else
				mov = this.getEnemigoCercano(arbol);
			
			return mov;
			}
		}
}
