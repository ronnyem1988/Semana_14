//Arboles Binarios
using System;

class Nodo
{
    public int dato;
    public Nodo izquierda, derecha;
    
    public Nodo(int dato)
    {
        this.dato = dato;
        izquierda = derecha = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;
    
    public ArbolBinario()
    {
        raiz = null;
    }
    
    public void Insertar(int dato)
    {
        raiz = InsertarRec(raiz, dato);
    }
    
    private Nodo InsertarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return new Nodo(dato);
        
        if (dato < nodo.dato)
            nodo.izquierda = InsertarRec(nodo.izquierda, dato);
        else if (dato > nodo.dato)
            nodo.derecha = InsertarRec(nodo.derecha, dato);
        
        return nodo;
    }
    
    public bool Buscar(int dato)
    {
        return BuscarRec(raiz, dato);
    }
    
    private bool BuscarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return false;
        if (nodo.dato == dato)
            return true;
        
        return dato < nodo.dato ? BuscarRec(nodo.izquierda, dato) : BuscarRec(nodo.derecha, dato);
    }
    
    public void Inorden()
    {
        InordenRec(raiz);
        Console.WriteLine();
    }
    
    private void InordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRec(nodo.izquierda);
            Console.Write(nodo.dato + " ");
            InordenRec(nodo.derecha);
        }
    }
    
    public void Preorden()
    {
        PreordenRec(raiz);
        Console.WriteLine();
    }
    
    private void PreordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.dato + " ");
            PreordenRec(nodo.izquierda);
            PreordenRec(nodo.derecha);
        }
    }
    
    public void Postorden()
    {
        PostordenRec(raiz);
        Console.WriteLine();
    }
    
    private void PostordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRec(nodo.izquierda);
            PostordenRec(nodo.derecha);
            Console.Write(nodo.dato + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, dato;
        
        do
        {
            Console.WriteLine("\nMenú de Árbol Binario:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());
            
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    dato = int.Parse(Console.ReadLine());
                    arbol.Insertar(dato);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    dato = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(dato) ? "El valor está en el árbol." : "El valor no se encontró.");
                    break;
                case 3:
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.Inorden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.Preorden();
                    break;
                case 5:
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.Postorden();
                    break;
            }
        } while (opcion != 6);
    }
}
