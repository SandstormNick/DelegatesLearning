# Delegates

Delegates are used to pass methods as arguments to other methods.

Event handlers are nothing more than methods that are invoked through delegates.

### Delegates Overview

* Delegates allow methods to be passed as parameters.
* Delegates can be used to define callback methods.
* Delegates can be chained together; for example, multiple methods can be called on a single event.


## Using Delegates

The type of a delegate is defined by the name of the delegate. The following example declares a delegate named Del that can encapsulate a method that takes a string as an argument and returns void:
```
 public delegate void Del(string message);
```

Once a delegate is instantiated, a method call made to the delegate will be passed by the delegate to that method.
The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, from the method is returned to the caller by the delegate.
This is known as invoking the delegate. An instantiated delegate can be invoked as if it were the wrapped method itself. For example:
```
// Create a method for a delegate.
public static void DelegateMethod(string message)
{
    Console.WriteLine(message);
}
```

```
// Instantiate the delegate.
Del handler = DelegateMethod;

// Call the delegate.
handler("Hello World");
```

Because the instantiated delegate is an object, it can be passed as an argument, or assigned to a property.
This allows a method to accept a delegate as a parameter, and call the delegate at some later time.
This is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed.

When a delegate is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used. 

The following example method uses the Del type as a parameter:
```
public static void MethodWithCallback(int param1, int param2, Del callback)
{
    callback("The number is: " + (param1 + param2).ToString());
}
```
You can then pass the delegate created above to that method:
```
MethodWithCallback(1, 2, handler);
```
and receive the following output to the console:
```
The number is: 3
```

Using the delegate as an abstraction, ```MethodWithCallback``` does not need to call the console directly — it does not have to be designed with a console in mind. 
What ```MethodWithCallback``` does is simply prepare a string and pass the string to another method. 
This is especially powerful since a delegated method can use any number of parameters.


A delegate can call more than one method when invoked. 
This is referred to as multicasting. 
To add an extra method to the delegate's list of methods — the invocation list—simply requires adding two delegates using the addition or addition assignment operators ('+' or '+='). 
For example:
```
var obj = new MethodClass();
Del d1 = obj.Method1;
Del d2 = obj.Method2;
Del d3 = DelegateMethod;

//Both types of assignment are valid.
Del allMethodsDelegate = d1 + d2;
allMethodsDelegate += d3;
```

To remove a method from the invocation list, use the subtraction or subtraction assignment operators (- or -=). For example:
```
//remove Method1
allMethodsDelegate -= d1;

// copy AllMethodsDelegate while removing d2
Del oneMethodDelegate = allMethodsDelegate - d2;
```

Multicast delegates are used extensively in event handling. 


## Delegates with Named vs. Anonymous Methods

A delegate can be associated with a named method. When you instantiate a delegate by using a named method, the method is passed as a parameter, for example:
```
// Declare a delegate.
delegate void Del(int x);

// Define a named method.
void DoWork(int k) { /* ... */ }

// Instantiate the delegate using the method as a parameter.
Del d = obj.DoWork;
```
This is called using a named method. Delegates constructed with a named method can encapsulate either a static method or an instance method.


## How to declare, instantiate, and use a Delegate

You can declare delegates using any of the following methods:

* Declare a delegate type and declare a method with a matching signature:
```
// Declare a delegate.
delegate void Del(string str);

// Declare a method with the same signature as the delegate.
static void Notify(string name)
{
    Console.WriteLine($"Notification received for: {name}");
}



// Create an instance of the delegate.
Del del1 = new Del(Notify);
```

* Assign a method group to a delegate type:
```
// C# 2.0 provides a simpler way to declare an instance of Del.
Del del2 = Notify;
```

* Declare an anonymous method:
```
// Instantiate Del by using an anonymous method.
Del del3 = delegate(string name)
    { Console.WriteLine($"Notification received for: {name}"); };
```

* Use a lambda expression:
```
// Instantiate Del by using a lambda expression.
Del del4 = name =>  { Console.WriteLine($"Notification received for: {name}"); };
```


### Code run through of the BookDB project
View the BookDB project in the solution that relates to the following bit of code.


* Declaring a delegate.
The following statement declares a new delegate type.
```
public delegate void ProcessBookCallback(Book book);
```
Each delegate type describes the number and types of the arguments, and the type of the return value of methods that it can encapsulate. 
Whenever a new set of argument types or return value type is needed, a new delegate type must be declared.


*Instantiating a delegate.
After a delegate type has been declared, a delegate object must be created and associated with a particular method. 
In the previous example, you do this by passing the ```PrintTitle``` method to the ```ProcessPaperbackBooks``` method as in the following example:
```
bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);
```
In both cases a new delegate object is passed to the ```ProcessPaperbackBooks``` method.

After a delegate is created, the method it is associated with never changes; delegate objects are immutable.

* Calling a delegate.
After a delegate object is created, the delegate object is typically passed to other code that will call the delegate. 
A delegate object is called by using the name of the delegate object, followed by the parenthesized arguments to be passed to the delegate. 
Following is an example of a delegate call:
```
processBook(b);
```