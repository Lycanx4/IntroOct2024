# Day 2 Review

## Assemblies and Visual Studio
What is your understanding of what is meant by the term "Assembly" in .NET?
- Assembly is the complied code that CLR executes.

What is the relationship between an assembly and visual studio Project?
- In Visual Studio each project can compiles into an assembly by CLR. Then, it can be used by other project as reference if needed.

What is a solution in Visual Studio?
- Solution is a kind of container tthat holds one or more related projects that helps to organize and manage the app development.

What are the two types of Assemblies discussed in class?
- Executable(.exe) assemblies which are stand alone applications
- Dynamic Link Library (.dll) assemblies which are reusable code libraries 

What is the thing that makes an assembly "Runnable" - what is the *entry* point of an Assembly?
- typically the Main() method for application assembly

## What is the "Common Language Runtime (CLR)" 
The CLR is the execution engin of the .NET framework and managing crucial services like, memory, security and execution. That support developers to write safe, quality and reliable code.

## What is "Dotnet Core"? What's that all about?
.NET Core is an open-source, cross-platform framework for building mordern, cloud-based and high performance application.

## What is the Common Type System (CTS)?
It is a key system of .NET framework that responsible for how data types are declared, used, and manage. There are two categories of types in CTS, Value Type(store data directly on stack memory) and Reference Type (store a pointer/address in stack that point to the actual data in heap memory). 

## What are the "First Class Citizens" of .NET?
First Class Citizens are entities such as objects and functions that can be used flexibly within the code.
