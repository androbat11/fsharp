// Tiny test helper shared by all exercises. Usage: check "name" (fun () -> myFunction 1) expected
let mutable private passed = 0
let mutable private failed = 0

let check (name: string) (actual: unit -> 'a) (expected: 'a) =
    try
        let result = actual ()
        if result = expected then
            passed <- passed + 1
            printfn "  PASS  %s" name
        else
            failed <- failed + 1
            printfn "  FAIL  %s\n        expected %A\n        got      %A" name expected result
    with ex ->
        failed <- failed + 1
        printfn "  FAIL  %s\n        %s" name (ex.Message.Split('\n').[0])

let summary () =
    printfn "\n%d passed, %d failed" passed failed
