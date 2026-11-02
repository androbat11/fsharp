// For more information see https://aka.ms/fsharp-console-apps
// Run with: dotnet run -- Hello World
open System

let output = 0
[<EntryPoint>]
let main (args: string[]): int =
  if args.Length <> 2 then
    failwith "Error: Expected arguments <greetings> and <thing>"

  // FIX 1: these lines were indented 4 spaces, which put them INSIDE the
  // `if` block, right after `failwith`. They only ran when the arguments
  // were wrong, and never ran (failwith throws first). Indenting them 2
  // spaces puts them at the same level as the `if`, in the body of `main`.
  let greeting, thing = args.[0], args.[1]
  let timeofday = DateTime.Now.ToString("hh:mm tt")

  // FIX 2: the arguments were in the wrong order. The format is
  // "<greeting>, <thing> at <time>", so it must be greeting, thing, timeofday.
  printfn "%s, %s at %s" greeting thing timeofday

  output
