// For more information see https://aka.ms/fsharp-console-apps
let add x y = x + y

type Customer = { Name: string; Age: int }
let ann = { Name = "Ann"; Age = 30 }

let older = { ann with Age = 31 }

// A discriminated union (usually just "union") says 
// a value is exactly on of a fixed list of cases.
// 
// Each line
type PaymentMethod =
  | Cash
  | Card of number: string
  | Transfer of bank: string * account: string



printfn "%A" older
