// A `val` line is a SIGNATURE: the type F# infers for a function or value.
// You see it in the editor tooltip or in `dotnet fsi`. It describes code,
// it is not code you write. Reading `val cube: int -> int` piece by piece:
//   val          -> "this is a value/function bound to a name"
//   cube         -> the name of that function
//   :            -> "has the type"
//   int          -> the input: an integer
//   ->           -> "function from input to output"
//   int          -> the output: an integer
// So: `cube` takes an int and returns an int.
val cube: int -> int

// `val main: string[] -> int` works the same way:
//   main         -> the name of the function
//   string[]     -> the input: an array of strings (the command-line args)
//   int          -> the output: an integer
// So: `main` takes the command-line arguments and returns an int.
//
// That int is the process EXIT CODE: 0 means success, any other number
// means failure. The OS and shells (`echo $?`) read it when the program ends.
//
// In Program.fs, [<EntryPoint>] marks `main` as where the program starts.
// The compiler requires exactly this shape (string[] -> int), which is why
// its return type must be `int` and not `unit`.
val main: string[] -> int
