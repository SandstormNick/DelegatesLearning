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




