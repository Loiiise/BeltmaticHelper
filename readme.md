# Summary
Beltmatic is a game where numbers are combined using several operators to make specific other numbers.

# Correctness and functionality
This program generates equasions based on the starting numbers and previously generated equasions. It guarantees to provide an optimal solution. Optimal is defined as an equasion with as few operators as possible. Note that for a lot of numbers there are several optimal equasions. In its current state the program will only provide one, for quick overview of the user.

# Instructions
Of course you are free to modify and use the code any way you see fit. Or submit an issue in GitHub and I'll take a look at it!

## How to call the program
### The proper way to do it
`BeltmaticHelper [highest number available] [highest operator available]`
This will generate a solver. After this you can feed it as many numbers as you like. This command will maintain its state in memory, which means every calculation will be significantly more efficient.

### Quick and dirty
`BeltmaticHelper [highest number available] [highest operator available] [number you want to find]` 
This will figure out the equasion for this specific number, after which the entire state is dismissed.

## Arguments
- `[highest number available]`: the highest number available to extractors. 
- `[highest operator available]`: the operator you unlocked most recently. For operator representation, see below.
- `[number you want to find]`: the number you want to generate an equasion for.

## Operator representation
In this solver the Beltmatic operators are represented as:
- Adder: `+`
- Multiplier: `*`
- Subtractor: `-`
- Divider: `/`
- Exponentiator: `^`

# Rights
I do not own the game or any commercial rights. This is a hobby project meant for private use only.