## Basic elements
- x |> f - means "pass x to f" lets you read data top to down.

```
let result =
  [1; 2; 3; 4; 5; 6]
  |> List.filter(fun n -> n % 2 = 0)
  |> List.map double
  |> List.sum
```
