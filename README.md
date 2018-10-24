# Unidays Coding Challenge

This is my take on the Unidays Coding Challenge (2018) realized in C#

## Installation

### Requirements
* A text-editor such as VS Code
* .NET Core
* Acces to CMD (on Windows) or Terminal (on Linux-based systems)
     * Tip: Use VS Code to run the code from inside Code's terminal!

## Usage

I recommend to build the project from scratch. To do so type this in your terminal:

```
$ dotnet new console -o YourDesiredFolderName
$ cd YourDesiredFolderName
$ dotnet run
```

`dotnet run` will now print *Hello World!* to the terminal. This is created automatically by .NET Core!

Before we replace the code in our *Program.cs*, I advise you to first create the two other required .cs files. Name them *ProductMethods.cs* and *ProductClass.cs*.

Now replace the content in *Program.cs* with the code that I have uploaded here. Do the same for *ProductMethod.cs* and *ProductClass.cs*

Next, enter in your terminal:

```
$ dotnet restore
$ dotnet run
```
You will now be asked to add an item to your cart. The available items are *A, B, C, D, and E*. You can use upper or lower-case letters. All you have to enter is the Item name, followed by a comma, i.e., `,` and then write the quantity demanded. Press the return key <kbd>↩</kbd>.

If you leave the part after the comma blank, or use 0 or a negative number, the quantity will be set to 1. I did this for convenience only!

Example input:
`A, 2`

Press any key (except for Esc) after you added an item using the return key. You will now, again, be asked to ad an item to your cart. If you are finished, press the escape key.

If the shopping cart value is below £50.-, £7.- shipping fee will be added automatically.

---

## Development Approach
For the most part, development was quite easy. All I had to do was to reuse some of my already existing code and rewrite it in such a way that it works with `List<T>` rather than an SQLite database file. In order to implement the necessary algorithms, I had to learn a bit about **LINQ** in order to count duplicates in a `List<T>`. Next, I created some functions/methods that analyze the total quantity of each item and return the total cost for each item after applying the discount. If the quantity is `0`, a total cost of zero (`0`) will be returned.

While there is still some room for code-optimization in regards to readability and possibility computational speed, I decided against doing anything of the sort given that this is only a basic coding challenge and people are probably not expected to create a full-fledged enterprise solition with DB access, etc.
