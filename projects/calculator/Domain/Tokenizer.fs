namespace Tokenizer

open Token

let tokenize (input: string): Token list =
    let rec loop chars acc =
        match chars with
        | [] -> List.rev acc
        // Skip whitespaces characters
        | ' ' :: tail | '\t' :: tail | '\r' :: tail | '\n' :: tail -> 
            loop tail acc
        // Single-character operators
        | '+' :: tail -> loop tail (Plus :: acc)
        | '-' :: tail -> loop tail (Minus :: acc)
        | '*' :: tail -> loop tail (Multiply :: acc)
        | '/' :: tail -> loop tail (Divide :: acc)
        | unknown :: _ ->
            "Lexing error: Unrecognized character '%c'" unknown
    loop (List.ofSeq input) []
 