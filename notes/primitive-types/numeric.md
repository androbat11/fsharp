## Numeric types

Every F# numeric type is a .NET type, so they also work from C# and VB.
The same list lives as comments in `experiments/Basics/scripts/numbers.fsx`.

### Signed integers

| F# name | .NET type | Size | Range | Suffix | Example |
|---|---|---|---|---|---|
| `sbyte` | `System.SByte` | 8 bits | -128 .. 127 | `y` | `10y` |
| `int16` | `System.Int16` | 16 bits | -32,768 .. 32,767 | `s` | `10s` |
| `int` | `System.Int32` | 32 bits | -2,147,483,648 .. 2,147,483,647 | none or `l` | `10`, `10l` |
| `int64` | `System.Int64` | 64 bits | -9,223,372,036,854,775,808 .. 9,223,372,036,854,775,807 | `L` | `10L` |
| `nativeint` | `System.IntPtr` | 32 or 64 bits, depends on the platform | platform dependent | `n` | `10n` |

`int` is the default type of a whole-number literal.

### Unsigned integers

No negative values.

| F# name | .NET type | Size | Range | Suffix | Example |
|---|---|---|---|---|---|
| `byte` | `System.Byte` | 8 bits | 0 .. 255 | `uy` | `10uy` |
| `uint16` | `System.UInt16` | 16 bits | 0 .. 65,535 | `us` | `10us` |
| `uint32` | `System.UInt32` | 32 bits | 0 .. 4,294,967,295 | `u` | `10u` |
| `uint64` | `System.UInt64` | 64 bits | 0 .. 18,446,744,073,709,551,615 | `UL` | `10UL` |
| `unativeint` | `System.UIntPtr` | 32 or 64 bits, depends on the platform | platform dependent | `un` | `10un` |

### Floating point

Approximate values, stored in binary.

| F# name | .NET type | Size | Range | Precision | Suffix | Example |
|---|---|---|---|---|---|---|
| `float32` | `System.Single` | 32 bits | about ±3.4e38 | ~7 digits | `f` or `F` | `3.14f` |
| `float` | `System.Double` | 64 bits | about ±1.7e308 | ~15-16 digits | none | `3.14`, `1e10` |

- `float` is the default type of a decimal-point literal.
- In F#, `float` means a 64-bit double, not 32-bit as in some languages.
- Special values: `nan`, `infinity`, `-infinity`. For example `0.0 / 0.0` is `nan`.
- `0.1 + 0.2 = 0.3` is `false`. Do not use floats for money.

### Decimal

Exact base-10 arithmetic. Use it for money.

| F# name | .NET type | Size | Range | Precision | Suffix | Example |
|---|---|---|---|---|---|---|
| `decimal` | `System.Decimal` | 128 bits | about ±7.9e28 | 28-29 digits | `M` or `m` | `19.99M` |

### Arbitrary precision integer

| F# name | .NET type | Size | Suffix | Example |
|---|---|---|---|---|
| `bigint` | `System.Numerics.BigInteger` | unlimited, limited by memory | `I` | `100000000000000000000I` |

### Literal forms

| Form | Prefix | Example |
|---|---|---|
| Decimal | none | `255` |
| Hexadecimal | `0x` | `0xFF` |
| Octal | `0o` | `0o377` |
| Binary | `0b` | `0b11111111` |
| Underscores | `_` | `1_000_000` (readability only, the value does not change) |
| Exponent | `e` | `1.5e3` (= `1500.0`, a float) |

### Conversions

F# never converts numeric types implicitly. Use the conversion function named after the target type.

```fsharp
int 3.9      // 3      truncates, does not round
float 3      // 3.0
int64 5      // 5L
decimal 2    // 2M
byte 300     // 44     wraps around silently, no error
```

- `1 + 2.0` does not compile because `int` and `float` cannot be mixed. Write `float 1 + 2.0`.
- Integer division truncates: `7 / 2` is `3`. Use floats to get `3.5`: `7.0 / 2.0`.

### Overflow

Integer arithmetic wraps around without an error by default.

```fsharp
System.Int32.MaxValue + 1   // -2147483648
```

For checked arithmetic that throws instead, open the `Checked` module:

```fsharp
open Microsoft.FSharp.Core.Operators.Checked
```

### Which type to use

| Need | Type |
|---|---|
| Counting, indexes, general whole numbers | `int` |
| Very large whole numbers (ids, file sizes) | `int64` |
| Raw bytes, binary data | `byte` |
| Measurements, science, general fractions | `float` |
| Money, exact decimal amounts | `decimal` |
| Numbers bigger than `int64` | `bigint` |
