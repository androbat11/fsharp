// Lesson 2 challenges: records, unions, match.
// Run from this folder:   dotnet fsi challenges.fsx
// Replace each `failwith "TODO"` with your code. Re-run after every change.
// Do them in order. The output tells you which checks pass.

#load "../../assets/check.fsx"
open Check

// ---------------------------------------------------------------
// Challenge 1: records
// `Product` is given. Write `discount` so it returns a COPY of the
// product with the price reduced by 10% (multiply by 0.9m).
// Hint: { p with Price = ... }
// ---------------------------------------------------------------
type Product = { Name: string; Price: decimal }

let discount (p: Product) : Product =
    failwith "TODO"

// ---------------------------------------------------------------
// Challenge 2: your own union
// Define `Shape` with two cases:
//   Circle    carrying one float (the radius)
//   Rectangle carrying two floats (width and height)
// Then write `area`. Circle area = 3.0 * r * r (we use pi = 3.0 to
// keep numbers exact). Rectangle area = width * height.
// Remember: in a union case, `of float * float` carries two values.
// ---------------------------------------------------------------
// type Shape = ...

// let area (s: Shape) : float =
//     failwith "TODO"

// ---------------------------------------------------------------
// Challenge 3: match over a union
// `OrderStatus` is given. Write `statusMessage`:
//   Pending           -> "Waiting to ship"
//   Shipped t         -> "Shipped, tracking " + t
//   Cancelled reason  -> "Cancelled: " + reason
// ---------------------------------------------------------------
type OrderStatus =
    | Pending
    | Shipped of trackingNumber: string
    | Cancelled of reason: string

let statusMessage (s: OrderStatus) : string =
    failwith "TODO"

// ---------------------------------------------------------------
// Challenge 4: records + unions together + a pipeline
// `Order` is given. Write `shippedCount`: how many orders in the list
// have status Shipped (any tracking number).
// Hint: List.filter with a lambda that uses `match`, then List.length.
//   fun o -> match o.Status with | Shipped _ -> true | _ -> false
// ---------------------------------------------------------------
type Order = { Id: int; Status: OrderStatus }

let shippedCount (orders: Order list) : int =
    failwith "TODO"

// ---------------------------------------------------------------
// Challenge 5: change the model, follow the compiler
// Add a fourth case to OrderStatus ABOVE: `Returned of reason: string`.
// Run the file. Read the FS0025 warnings: they point at every match
// that needs a new branch. Then make statusMessage return
//   Returned r -> "Returned: " + r
// and uncomment the check at the bottom.
// ---------------------------------------------------------------

// ================= Checks (don't edit) =========================
printfn "Challenge 1"
check "discount 100 -> 90" (fun () -> (discount { Name = "Pen"; Price = 100m }).Price) 90.0m
check "discount keeps name" (fun () -> (discount { Name = "Pen"; Price = 100m }).Name) "Pen"

printfn "Challenge 2 (uncomment the checks once Shape and area exist)"
// check "circle r=2" (fun () -> area (Circle 2.0)) 12.0
// check "rectangle 3x4" (fun () -> area (Rectangle (3.0, 4.0))) 12.0

printfn "Challenge 3"
check "pending" (fun () -> statusMessage Pending) "Waiting to ship"
check "shipped" (fun () -> statusMessage (Shipped "ABC1")) "Shipped, tracking ABC1"
check "cancelled" (fun () -> statusMessage (Cancelled "no stock")) "Cancelled: no stock"

printfn "Challenge 4"
let sample =
    [ { Id = 1; Status = Pending }
      { Id = 2; Status = Shipped "X" }
      { Id = 3; Status = Cancelled "late" }
      { Id = 4; Status = Shipped "Y" } ]
check "two shipped" (fun () -> shippedCount sample) 2
check "empty list" (fun () -> shippedCount []) 0

printfn "Challenge 5 (uncomment after adding Returned)"
// check "returned" (fun () -> statusMessage (Returned "damaged")) "Returned: damaged"

summary ()
