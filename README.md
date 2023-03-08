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