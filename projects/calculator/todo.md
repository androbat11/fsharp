# TODO

## Project / build
- [ ] `calculator.fsproj` targets `net10.0` but the installed SDK is 8.0: install .NET 10 SDK or switch `TargetFramework` to `net8.0`.
- [ ] `git add Domain/types/` (still untracked).

## Layering
- [ ] Create the missing layers as files (compile order in the `.fsproj` enforces dependency direction):
  1. `Domain/Token.fs`, `Domain/Expression.fs` (pure types)
  2. `Domain/Tokenizer.fs`, `Domain/Parser.fs`, `Domain/Evaluator.fs` (pure logic, no I/O)
  3. `Infrastructure/Input.fs` (reading from the console)
  4. `Presentation/Program.fs` (entry point, ties the layers together)
- [ ] Rename `AbstractTree.fs` to `Parser.fs` (the AST already lives in `Expressions.fs`; the missing piece is tokens -> tree).
- [ ] Keep Domain pure: no printing or throwing; return values/errors and let Infrastructure/Presentation decide what to do.

## Tokenizer.fs
- [ ] Use `module Tokenizer` instead of `namespace Tokenizer` (a namespace can't hold a `let`).
- [ ] Fix case names: the type has `PlusToken`, `MinusToken`, `MultiplyToken`, `DevideToken`, not `Plus`, `Minus`, `Multiply`, `Divide`.
- [ ] Fix the error branch: `"Lexing error..." unknown` needs `sprintf`, and must return a `Token list`. Prefer returning `Result<Token list, string>`.
- [ ] Handle the missing cases: numbers (digits and `.`), identifiers, `(` and `)`, and decide whether `EndOfToken` is needed.
- [ ] Minor: remove trailing space on the last line; whitespace pattern can be `(' ' | '\t' | '\r' | '\n') :: tail`.

## Token.fs
- [ ] Namespace `Token` and type `Token` share a name: use `module Token` (or `namespace Domain` + `open Domain`).
- [ ] Rename `DevideToken` -> `DivideToken`.
- [ ] Rename `LeftParentToken`/`RightParentToken` -> `LeftParenToken`/`RightParenToken`.
- [ ] Consider `IdentificationToken` -> `IdentifierToken`.

## Expressions.fs
- [ ] Typos: `Sustract` -> `Subtract`, `Devide` -> `Divide`.
- [ ] `UnaryOp of UnaryOperator` has no operand: make it `UnaryOp of UnaryOperator * Expression`.
- [ ] Watch for name clashes between `Multiply` (expressions) and the token cases if the `Token` suffix is ever dropped.
- [ ] Decide whether `Int`/`Float` split is needed; a single `Number of float` is simpler (the tokenizer only produces `float`).

## Program.fs
- [ ] Use `[<EntryPoint>]` (not `[<Main>]`), signature `let main argv = ...` returning an `int`.
- [ ] Fill in the body (currently empty).
