using System;
using System.Collections;
using System.Runtime.CompilerServices;

public class test<T> where T : class // this is constraint for passing class only, and you can add other constrainrt
{                                    // syntax constraint  where T : specifications
    private T[] array = new T[1];
    int length = 0;

    public bool isEmpty() {
        if (array[0] == null)
            return true;
        return false;
    }

    public void add(T cust) {
        if (isEmpty())
            array[0] = cust;
        else
        {
            T[] newArray = new T[array.Length + 1];
            for (int x = 0; x < array.Length; x++) {
                newArray[x] = array[x];
            }
            newArray[array.Length] = cust;
            array = newArray;
            length++;
        }
    }

    public void display() {
        Console.Write("[ ");
        for (int x = 0; x < array.Length; x++) {
            Console.Write(array[x]);
            if (array.Length-1>x)
            Console.Write(" , ");
        }
        Console.Write("] ");
    }

    public void getLength() {
        Console.WriteLine("length of array: " + array.Length);
    }

    public int getSize() { return array.Count(); }

    public void remove(int position) {
        if (position < 0 || position > array.Length)
            return;

        var index = 0;
        var dest = new T[array.Length - 1];
        for (int x = 0; x < array.Length; x++) {
            if (position == x)
                continue;
            dest[index++] = array[x];
        }
        array = dest;
        display();
    }

}

public class Customers {

    private string name;
    private int id;
    private int NumOforders;
    private double price;

    public Customers()
    {
        this.name = string.Empty;
        this.id = 0;
        this.NumOforders = 0;
        this.price = 0;
    }

    public Customers(string name, int id, int numOforders, double price)
    {
        this.checkName(name);
        this.checkId(id);
        this.checkNumOforders(numOforders);
        this.checkPrice(price);
    }

    private void checkName(string name) {
        if (string.IsNullOrEmpty(name)) 
             this.name = string.Empty;
        else
            this.name = name;
    }

    public void setName(string name) {
        this.checkName(name);
    }

    private void checkId(int id)
    {
        if (id<=0)
            this.id = 0;
        else
            this.id = id;
    }

    public void setId(int id)
    {
        this.checkId(id);
    }

    private void checkNumOforders(int NumOforders) {
        if (NumOforders <= 0)
            this.NumOforders = 0;
        else
            this.NumOforders= NumOforders;
    }

    public void setNumOforders(int NumOforders) { this.checkNumOforders(NumOforders); }
    private void checkPrice(double price) { 
    if(price <= 0)
            this.price = 0;
    else
            this.price= price;
    }
    public void setPrice(double price) { this.checkPrice(price); }


    public string getName() { return this.name; }
    public int getId() { return this.id;}
    public int getNumOforders() { return this.NumOforders; }
    public double getPrice() { return this.price;}

    public void getAll() {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("id: " + id);
        Console.WriteLine("number of orders: " + NumOforders);
        Console.WriteLine("price: " + price);
    }

    public override string ToString() // must exist for printing
    {
        return "( "+ name+ " -  " + id + " - "+price+" - "+NumOforders+" )";
    }

}



internal class Program
{
    private static void Main(string[] args)
    {
        // if i use the array or i will deal with array
        Customers customer = new Customers("Gamal", 1121, 4, 345.5);
        Customers customer2 = new Customers("Ali", 1121, 4, 345.5);
        Customers customer3 = new Customers("ahmed", 1121, 4, 345.5);
        Customers customer4 = new Customers("bilal", 1121, 4, 345.5);


        test<Customers> customers = new test<Customers>();

        customers.add(customer);
        customers.add(customer2);
        customers.add(customer3);
        customers.add(customer4);

        customers.display();
        Console.WriteLine("\n numbero f size is: " + customers.getSize());
        customers.getLength();

        customers.remove(3);

        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        // if i will deal with List and there are like this bult in function.

        List<Customers> people = new List<Customers>();
        
        people.Add(customer);
        people.Add(customer2);
        people.Add(customer3);
        people.Add(customer4);
        people.Count();
        people.Remove(customer);
        people.Insert(0, customer);
        people.RemoveAt(0);
        people.Insert(1, customer);
        Console.WriteLine();

        foreach (Customers i in people) {
            Console.Write( i+" ");
        }



        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        // if i want to deal with arrayList.

        ArrayList arraylist=new ArrayList();

        arraylist.Add(customer);
        arraylist.Add(customer2);
        arraylist.Add(customer3);
        arraylist.Add(customer4);
        arraylist.LastIndexOf(customer);
        arraylist.Insert(3, customer2);
        arraylist.Insert(2, customer2);
        arraylist.Insert(1, customer2);

        foreach (Customers i in arraylist) {
            Console.Write("( " + i + "  ),");
        }







        Console.ReadKey();
    }
}