using System;
using System.Collections.Generic;

namespace DeepSpace
{
	public class ArbolGeneral<T>
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
	
		public int altura() {
			return 0;
		}
	
		
		public int nivel(T dato) {
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolaux;
			int nivel =0; //lleva la cuenta de nivel
			c.encolar(this);
			c.encolar(null);
			
			while(!c.esVacia())
			{
				arbolaux=c.desencolar();
				
				//si es separador
				if( arbolaux == null){
				
					if(c.esVacia())
						c.encolar(null);
						nivel ++;
				
				
				}
				//si es un nodo (arbol)
				else{
					//encolamos hijos
					foreach(var hijo in arbolaux.getHijos())
						c.encolar(hijo);
					
				}	
			}
			return nivel;
			
		}
		
	}
	
}
	
	
