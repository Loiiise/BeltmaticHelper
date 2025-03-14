# Summary
Beltmatic is a game where numbers are combined using several operators to make specific other numbers in order to upgrade your items and progress through levels.

# Correctness and functionality
This program generates equations based on the starting numbers and previously generated equations. It guarantees to provide an optimal solution. Optimal is defined as an equation with as few operators as possible. Note that for a lot of numbers there are several optimal equations. In its current state the program will only provide one, for quick overview of the user.

# Instructions on how to use the program
Of course you are free to modify and use the code any way you see fit. Or submit an issue in GitHub and I'll take a look at it! The program works in the commandline. Once you've downloaded the executable you can use as instructed below.

## The proper way to do it
`BeltmaticHelper [highest number available] [highest operator available]`
This will generate a solver. After this you can feed it as many numbers as you like. This command will maintain its state in memory, which means every calculation after the first one will be significantly more efficient.

## Quick and dirty
`BeltmaticHelper [highest number available] [highest operator available] [number you want to find]` 
This will figure out the equation for this specific number, after which the entire state is dismissed.

## Arguments
- `[highest number available]`: the highest number available to extractors. 
- `[highest operator available]`: the operator you unlocked most recently. For operator representation, see below.
- `[number you want to find]`: the number you want to generate an equation for.

## Operator representation
In this solver the Beltmatic operators are represented as:
- Adder: `+`
- Multiplier: `*`
- Subtractor: `-`
- Divider: `/`
- Exponentiator: `^`

# Dependencies
Project is built in dotnet 8 depends only on common dotnet libraries (like `LINQ`).

# Rights
I do not own the game or any commercial rights. This is a hobby project meant for private use only.