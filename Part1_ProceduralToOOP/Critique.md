# Critique of the Procedural Order System

## 1. Global State

The program stores most of its data in global variables.

This is a problem because any function that has access to these variables can read or modify the shared state. There is no clear ownership of the data, which makes it harder to understand which part of the program is responsible for changing it.

As the program grows, tracking changes to global state becomes more difficult and can lead to unexpected behavior.

---

## 2. Functions Directly Control the Data

The program uses free functions to manage and modify the data instead of having objects responsible for their own state and behavior.

For example, customer, product, and order data is stored separately from the functions that operate on it.

This makes responsibilities less clear because the data and the behavior that belongs to it are separated. It also makes the system harder to maintain and extend.

An object-oriented design would give each domain object responsibility for the behavior related to its own data.

---

## 3. Fixed-Size Arrays

The program relies on fixed-size arrays with predefined limits for storing customers, products, orders, and other data.

This makes the system difficult to scale because reaching one of these limits requires changing the program's capacity or redesigning how the data is stored.

Changes to these limits may also affect multiple parts of the program that depend on them, increasing the maintenance effort and the possibility of mistakes.

---

## 4. Weak Encapsulation

The program does not properly protect its data because the state is stored outside of objects and can be accessed by different functions.

There are no clear boundaries that define which code is allowed to modify a particular piece of data.

This makes it easier for invalid state to be introduced because there is no single object responsible for validating changes to its own data.

Encapsulation would allow the system to control how its state is accessed and modified.

---

## 5. Parallel Arrays

Related data is stored across multiple arrays and connected through their indexes.

For example, customer information is separated into arrays such as customer IDs, names, emails, and cities.

All of these arrays must remain synchronized. If one array is changed incorrectly or an index is handled incorrectly, information from different customers could become mismatched.

This also makes the system harder to extend because adding a new property requires another array and changes to the code that manages the existing arrays.

A `Customer` class can solve this problem by keeping all customer-related data together inside one object.

---

## Conclusion

The main problem with the current design is that the data, behavior, and responsibilities are not organized around the domain objects.

The system can be redesigned using object-oriented principles by representing concepts such as `Customer`, `Product`, `Order`, and `OrderLine` as classes. Each object can then own its state and the behavior related to that state, while avoiding global variables and improving encapsulation.