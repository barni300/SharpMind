# C# Algorithms Collection 🗃️

This repository contains a collection of C# algorithms implemented as standalone classes or methods.  
The code is intended for learning and reference purposes.

## ChainHashTable ⛓️

`ChainHashTable` is a simple hash table implementation in C# using **separate chaining** to handle collisions.  
It stores key-value pairs 🔑➡️📄, supports insertion, deletion, and searching, and dynamically resizes when it becomes too full.

### Use Case 💡
Ideal for storing key-value data with fast lookups while handling collisions efficiently. Each bucket uses a linked list 🔗 to store multiple entries with the same hash.

## OpenAddressingHashTable 🏷📬

`OpenAddressingHashTable` uses **open addressing** (linear probing) to handle collisions.  
Colliding entries are placed in the next available slot in the array.

**Use Case 💡**  
Great for storing key-value data with fast lookups without using linked lists, resolving collisions by probing sequential slots.
