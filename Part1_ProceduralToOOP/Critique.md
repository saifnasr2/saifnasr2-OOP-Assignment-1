1. Entities aren't represented as cohesive objects
- Every entity isn't independent
- The data of every entity is shared across the program, which means
  every function can access it without restrictions
- The data is scattered across arrays, which may make the arrays
  affect each other

2. Doesn't apply SRP
- There are functions that have more than one responsibility

3. The program has a limit on users
- It isn't flexible for future growth
- If the number of orders, customers ,products, and lines per order
  grows the system will not be able to deal with the additional data

4. The data isn't flexible to add/change
- Adding another array to save additional information for a customer
  will require updating the rest of the arrays that the customer uses

5. Repetition in search methods