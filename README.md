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


## Even Ones Subarray Checker ⚖️

This C# snippet checks whether a subarray of given length contains an equal number of 1s and 0s (or positives and negatives).  

### How It Works 🧩
- Reads an array of integers (1s and 0s). 🔢  
- For each query `(l, r)`, checks the subarray from index `l` to `r`.  
- If the subarray length is **even** and there are enough 1s and 0s to split evenly, it outputs `1` ✅, otherwise `0` ❌.

**Use Case 💡**  
Useful for competitive programming problems involving **subarray parity** and counting elements efficiently.
