//1.
/*
using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> _items;

    public MyStack()
    {
        _items = new List<T>();
    }

    // Returns the number of elements in the stack
    public int Count()
    {
        return _items.Count;
    }

    // Removes and returns the top element from the stack
    public T Pop()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }
        T topItem = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return topItem;
    }

    // Adds an element to the top of the stack
    public void Push(T element)
    {
        _items.Add(element);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine(stack.Count()); // Output: 3
        Console.WriteLine(stack.Pop());   // Output: 30
        Console.WriteLine(stack.Count()); // Output: 2

        stack.Push(40);
        Console.WriteLine(stack.Pop());   // Output: 40
        Console.ReadLine();
    }
}
*/

//2.
/*
using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> _items;

    public MyList()
    {
        _items = new List<T>();
    }

    // Adds an element to the list
    public void Add(T element)
    {
        _items.Add(element);
    }

    // Removes an element at the specified index and returns it
    public T Remove(int index)
    {
        if (index < 0 || index >= _items.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        T removedItem = _items[index];
        _items.RemoveAt(index);
        return removedItem;
    }

    // Checks if the list contains a specific element
    public bool Contains(T element)
    {
        return _items.Contains(element);
    }

    // Clears all elements from the list
    public void Clear()
    {
        _items.Clear();
    }

    // Inserts an element at the specified index
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > _items.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        _items.Insert(index, element);
    }

    // Deletes an element at the specified index
    public void DeleteAt(int index)
    {
        if (index < 0 || index >= _items.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        _items.RemoveAt(index);
    }

    // Finds and returns the element at the specified index
    public T Find(int index)
    {
        if (index < 0 || index >= _items.Count)
        {
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }
        return _items[index];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>();
        myList.Add(10);
        myList.Add(20);
        myList.Add(30);

        Console.WriteLine(myList.Find(1)); // Output: 20
        myList.InsertAt(25, 1);
        Console.WriteLine(myList.Find(1)); // Output: 25

        myList.DeleteAt(1);
        Console.WriteLine(myList.Find(1)); // Output: 20

        Console.WriteLine(myList.Contains(30)); // Output: True

        myList.Clear();
        Console.WriteLine(myList.Contains(10)); // Output: False
        Console.ReadLine();
    }
}
*/

//3.
/*
using System;
using System.Collections.Generic;
using System.Linq;

// Base entity class
public abstract class Entity
{
    public int Id { get; set; }
}

// IRepository interface
public interface IRepository<T> where T : Entity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

// GenericRepository class
public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> _items;

    public GenericRepository()
    {
        _items = new List<T>();
    }

    // Adds an item to the repository
    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        _items.Add(item);
    }

    // Removes an item from the repository
    public void Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        _items.Remove(item);
    }

    // Simulates saving changes (e.g., to a database)
    public void Save()
    {
        // In a real implementation, this method would persist changes to the data source
        Console.WriteLine("Changes saved.");
    }

    // Retrieves all items from the repository
    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    // Retrieves an item by its ID
    public T GetById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }
}

// Example entity class
public class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        GenericRepository<Product> repository = new GenericRepository<Product>();

        var product1 = new Product { Id = 1, Name = "Laptop", Price = 1000.0m };
        var product2 = new Product { Id = 2, Name = "Phone", Price = 500.0m };

        repository.Add(product1);
        repository.Add(product2);

        foreach (var product in repository.GetAll())
        {
            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }

        var retrievedProduct = repository.GetById(1);
        Console.WriteLine($"Retrieved Product: ID: {retrievedProduct.Id}, Name: {retrievedProduct.Name}");

        repository.Remove(product1);
        repository.Save();

        Console.WriteLine("After removal:");
        foreach (var product in repository.GetAll())
        {
            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}
*/