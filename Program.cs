using System;

class Node
{
    public int Data { get; set; }
    public Node Prev { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}

class ListaDoblementeEnlazada
{
    private Node head;

    public ListaDoblementeEnlazada()
    {
        head = null;
    }

    // Agregar al final de la lista
    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Prev = temp;
        }
    }

    // Eliminar un nodo por valor
    public void Remove(int data)
    {
        if (head == null) return;

        Node temp = head;

        // Buscar el nodo a eliminar
        while (temp != null && temp.Data != data)
        {
            temp = temp.Next;
        }

        if (temp == null) return;

        // Si es el único nodo
        if (temp.Prev == null && temp.Next == null)
        {
            head = null;
        }
        else if (temp.Prev == null)
        {
            head = temp.Next;
            head.Prev = null;
        }
        else if (temp.Next == null)
        {
            temp.Prev.Next = null;
        }
        else
        {
            temp.Prev.Next = temp.Next;
            temp.Next.Prev = temp.Prev;
        }
    }

    // Buscar un nodo por valor
    public Node Search(int data)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data == data)
            {
                return temp;
            }
            temp = temp.Next;
        }
        return null;
    }

    // Modificar un nodo por valor
    public void Modify(int oldData, int newData)
    {
        Node nodeToModify = Search(oldData);
        if (nodeToModify != null)
        {
            nodeToModify.Data = newData;
        }
    }

    // Imprimir lista hacia adelante
    public void PrintForward()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    // Imprimir lista hacia atrás
    public void ImprimirHaciaAtras()
    {
        if (head == null) return;

        Node temp = head;

        // Ir al último nodo
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        // Imprimir en reversa
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Prev;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaDoblementeEnlazada list = new ListaDoblementeEnlazada();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Menú de Lista Doblemente Enlazada ---");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Modificar");
            Console.WriteLine("5. Imprimir hacia adelante");
            Console.WriteLine("6. Imprimir hacia atrás");
            Console.WriteLine("7. Salir");
            Console.Write("Elige una opción: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Ingresa el valor a agregar: ");
                    int AgregarValor = int.Parse(Console.ReadLine());
                    list.Add(AgregarValor);
                    Console.WriteLine($"Agregado: {AgregarValor}");
                    break;

                case "2":
                    Console.Write("Ingresa el valor a eliminar: ");
                    int EliminarValor = int.Parse(Console.ReadLine());
                    list.Remove(EliminarValor);
                    Console.WriteLine($"Eliminado: {EliminarValor}");
                    break;

                case "3":
                    Console.Write("Ingresa el valor a buscar: ");
                    int BuscarValor = int.Parse(Console.ReadLine());
                    Node foundNode = list.Search(BuscarValor);
                    Console.WriteLine(foundNode != null ? $"Encontrado: {foundNode.Data}" : "No encontrado");
                    break;

                case "4":
                    Console.Write("Ingresa el valor actual a modificar: ");
                    int AntiguoValor = int.Parse(Console.ReadLine());
                    Console.Write("Ingresa el nuevo valor: ");
                    int NuevoValor = int.Parse(Console.ReadLine());
                    list.Modify(AntiguoValor, NuevoValor);
                    Console.WriteLine($"Modificado: {AntiguoValor} -> {NuevoValor}");
                    break;

                case "5":
                    Console.WriteLine("Lista hacia adelante:");
                    list.PrintForward();
                    break;

                case "6":
                    Console.WriteLine("Lista hacia atrás:");
                    list.ImprimirHaciaAtras();
                    break;

                case "7":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}
