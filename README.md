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
