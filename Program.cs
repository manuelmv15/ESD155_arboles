namespace arboles
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

            arbol.Insertar(50);
            arbol.Insertar(30);
            arbol.Insertar(70);
            arbol.Insertar(20);
            arbol.Insertar(40);
            arbol.Insertar(60);
            arbol.Insertar(80);

            Console.WriteLine("Recorrido Inorden:");
            arbol.RecorridoInorden();

            Console.WriteLine("\nBuscar 40: " + (arbol.Buscar(40) ? "Encontrado" : "No encontrado"));
            Console.WriteLine("Eliminar 20");
            arbol.Eliminar(20);

            Console.WriteLine("Recorrido Inorden después de eliminar:");
            arbol.RecorridoInorden();

            
        }
    }

    public class Nodo
    {
        public int Valor;
        public Nodo Izquierdo, Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = Derecho = null;
        }
    }

    public class ArbolBinarioBusqueda
    {
        public Nodo Raiz;

        public ArbolBinarioBusqueda()
        {
            Raiz = null;
        }
        public void Insertar(int valor)
        {
            Raiz = InsertarNodo(Raiz, valor);
        }

        private Nodo InsertarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarNodo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarNodo(nodo.Derecho, valor);

            return nodo;
        }
        public bool Buscar(int valor)
        {
            return BuscarNodo(Raiz, valor);
        }

        private bool BuscarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return false;

            if (valor == nodo.Valor)
                return true;
            else if (valor < nodo.Valor)
                return BuscarNodo(nodo.Izquierdo, valor);
            else
                return BuscarNodo(nodo.Derecho, valor);
        }
        public void Eliminar(int valor)
        {
            Raiz = EliminarNodo(Raiz, valor);
        }

        private Nodo EliminarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return nodo;

            if (valor < nodo.Valor)
                nodo.Izquierdo = EliminarNodo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = EliminarNodo(nodo.Derecho, valor);
            else
            {
                // Caso 1: Nodo sin hijos
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                // Caso 2: Nodo con un solo hijo
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;
                else if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                // Caso 3: Nodo con dos hijos
                Nodo sucesor = EncontrarMinimo(nodo.Derecho);
                nodo.Valor = sucesor.Valor;
                nodo.Derecho = EliminarNodo(nodo.Derecho, sucesor.Valor);
            }
            return nodo;
        }

        private Nodo EncontrarMinimo(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;
            return nodo;
        }
        public void RecorridoPreorden()
        {
            RecorridoPreorden(Raiz);
            Console.WriteLine();
        }

        private void RecorridoPreorden(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                RecorridoPreorden(nodo.Izquierdo);
                RecorridoPreorden(nodo.Derecho);
            }
        }
        public void RecorridoInorden()
        {
            RecorridoInorden(Raiz);
            Console.WriteLine();
        }

        private void RecorridoInorden(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoInorden(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                RecorridoInorden(nodo.Derecho);
            }
        }
        public void RecorridoPostorden()
        {
            RecorridoPostorden(Raiz);
            Console.WriteLine();
        }

        private void RecorridoPostorden(Nodo nodo)
        {
            if (nodo != null)
            {
                RecorridoPostorden(nodo.Izquierdo);
                RecorridoPostorden(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }
    }
}