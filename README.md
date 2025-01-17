# Harry Potter Kata 
The **Harry Potter** Kata is a coding exercise that provides an opportunity to practice object-oriented programming (OOP) principles and clever optimization algorithms. Let’s delve into the details:

# Problem Description
A fictional bookshop offers five different Harry Potter books. To boost sales, they’ve introduced a discount system. Here are the rules:
1.	Base Price: Each copy of any Harry Potter book costs 8 EUR.
2.	Discounts:
*	If you buy two different books, you get a 5% discount on those two books.
*	If you buy three different books, you get a 10% discount.
*	If you buy four different books, you get a 20% discount.
*	If you go all out and buy all five books, you get a whopping 25% discount.
*	Note that if you buy, say, four books, of which three are different titles, you get a 10% discount on the three that form part of a set, but the fourth book still costs 8 EUR.

# Mission
Your task is to write a piece of code that calculates the price of any conceivable shopping basket containing only Harry Potter books, giving the maximum possible discount. For example, consider this basket:
-	2 copies of the Book I
-	2 copies of the Book II
-	2 copies of the Book III
-	1 copy of the Book IV
-	1 copy of the Book V
  
| Books	 | Quantity	| Price     |
| ------ | -------- | --------- |
| 1	     | 1	       | 08.00 EUR |
| 2	     | 2	       | 15.20 EUR |
| 3	     | 3	       | 21.60 EUR |
| 4	     | 4	       | 25.60 EUR |
| 5	     | 5	       | 30.00 EUR |
|        |          |
| Total		           | 51.20 EUR |

 The answer should be 51.20 EUR. Here’s how the calculation works:

# **Complete Solutions available at** [HERE](https://github.com/ssssage/code-kata/tree/master/4th-version)

# Formula
To calculate the price, follow this formula:
-	For each set of different books, apply the appropriate discount.
-	Sum up the prices for all sets.

For example, the final price for the given basket is:
- 3 sets of 5 different books: 3 * (5 * 8 * 0.75) = 141.20 EUR
- 2 sets of 4 different books: 2 * (4 * 8 * 0.8) = 51.20 EUR


**The Harry Potter Code Kata** is a delightful exercise that not only hones your coding skills but also provides valuable insights into real-world problem-solving. Let’s explore its usefulness and how it relates to C# .NET jobs

# Object-Oriented Programming (OOP) Practice:
    *	The Kata encourages you to model the problem using classes and objects (such as Book and Basket).
    *	You’ll learn about encapsulation, inheritance, and polymorphism by designing classes that represent different aspects of the problem.

# Algorithm Optimization:
    *	The challenge lies in finding an efficient way to calculate the maximum discount for a given set of books.
    *	You’ll explore strategies to group books into sets that minimize the total cost.
    *	This mirrors real-world scenarios where optimizing algorithms is crucial for performance.

# Test-Driven Development (TDD):
    *	The provided test cases demonstrate TDD principles.
    *	You’ll write tests before implementing the solution, ensuring correctness and maintainability.
    *	TDD is a valuable skill in professional software development.

# Handling Business Rules:
    *	The Kata simulates business rules (discounts based on book combinations).
    *	In professional projects, you’ll encounter similar scenarios (e.g., pricing rules, promotions).
    *	Learning to translate business requirements into code is crucial.

# Unit Testing and Assertions:
    *	The provided test cases validate correctness.
    *	In C# .NET jobs, writing unit tests ensures code quality and prevents regressions.

# Code Review and Feedback:
    *	Posting your solution on platforms like Code Review Stack Exchange allows others to review your code.
    *	Constructive feedback helps improve your coding style and practices.

# Community Learning and Collaboration:
    *	Katas are popular among developers, fostering a sense of community.
    *	Collaborating with others, sharing solutions, and learning from different approaches are essential skills.

# Transferrable Skills:
    *	The problem-solving mindset developed during Katas translates directly to real-world projects.
    *	Whether you’re building web applications, APIs, or desktop software, the ability to tackle complex problems remains relevant.
 
 # Summay
 In summary, the Harry Potter Code Kata serves as a fun yet educational exercise that prepares you for real-world challenges in C# .NET development. By mastering the Kata, you’ll gain practical skills applicable 
 to various job roles and projects.

