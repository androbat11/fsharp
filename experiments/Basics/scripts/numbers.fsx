// =============================================================================
// NUMERIC TYPES IN F#  (documentation)
// =============================================================================
// Format:  F# name (.NET type) | size | range / precision | literal suffix | example
// Every F# numeric type is a .NET type, so these also work from C# and VB.
// =============================================================================


// -----------------------------------------------------------------------------
// 1. SIGNED INTEGERS
// -----------------------------------------------------------------------------
// sbyte    (System.SByte)  | 8 bits  | -128 .. 127                    | y  | 10y
// int16    (System.Int16)  | 16 bits | -32,768 .. 32,767              | s  | 10s
// int      (System.Int32)  | 32 bits | -2,147,483,648 .. 2,147,483,647| (none) or l | 10, 10l
//          int is the default type of a whole-number literal.
// int64    (System.Int64)  | 64 bits | -9,223,372,036,854,775,808 ..
//                                       9,223,372,036,854,775,807      | L  | 10L
// nativeint(System.IntPtr) | 32 or 64 bits, depends on the platform     | n  | 10n


// -----------------------------------------------------------------------------
// 2. UNSIGNED INTEGERS (no negative values)
// -----------------------------------------------------------------------------
// byte     (System.Byte)   | 8 bits  | 0 .. 255                       | uy | 10uy
// uint16   (System.UInt16) | 16 bits | 0 .. 65,535                    | us | 10us
// uint32   (System.UInt32) | 32 bits | 0 .. 4,294,967,295             | u  | 10u
// uint64   (System.UInt64) | 64 bits | 0 .. 18,446,744,073,709,551,615| UL | 10UL
// unativeint (System.UIntPtr) | 32 or 64 bits, depends on the platform  | un | 10un


// -----------------------------------------------------------------------------
// 3. FLOATING POINT (approximate values, binary)
// -----------------------------------------------------------------------------
// float32  (System.Single) | 32 bits | about +/-3.4e38,   ~7 digits   | f or F | 3.14f
// float    (System.Double) | 64 bits | about +/-1.7e308,  ~15-16 digits| (none) | 3.14, 1e10
//          float is the default type of a decimal-point literal.
//          Note: in F#, `float` means 64-bit double (not 32-bit as in some languages).
// Special values: nan, infinity, -infinity (for example 0.0 / 0.0 is nan)
// Warning: 0.1 + 0.2 <> 0.3 exactly. Do not use floats for money.


// -----------------------------------------------------------------------------
// 4. DECIMAL (exact base-10 arithmetic, use this for money)
// -----------------------------------------------------------------------------
// decimal  (System.Decimal)| 128 bits| about +/-7.9e28, 28-29 digits | M or m | 19.99M


// -----------------------------------------------------------------------------
// 5. ARBITRARY PRECISION INTEGER
// -----------------------------------------------------------------------------
// bigint   (System.Numerics.BigInteger) | unlimited size, limited by memory | I | 100000000000000000000I


// -----------------------------------------------------------------------------
// 6. LITERAL FORMS (other ways to write the same numbers)
// -----------------------------------------------------------------------------
// Decimal      255
// Hexadecimal  0xFF       (prefix 0x)
// Octal        0o377      (prefix 0o)
// Binary       0b11111111 (prefix 0b)
// Underscores  1_000_000  (readability only, they do not change the value)
// Exponent     1.5e3      (= 1500.0, a float)


// -----------------------------------------------------------------------------
// 7. CONVERSIONS (F# never converts numeric types implicitly, be explicit)
// -----------------------------------------------------------------------------
// Conversion functions are named after the target type:
//   int 3.9    -> 3        (truncates, does not round)
//   float 3    -> 3.0
//   int64 5    -> 5L
//   decimal 2  -> 2M
//   byte 300   -> 44       (wraps around silently, no error)
// `1 + 2.0` does not compile: int and float cannot be mixed. Write `float 1 + 2.0`.
// Integer division truncates: 7 / 2 = 3. Use floats for 3.5: 7.0 / 2.0.


// -----------------------------------------------------------------------------
// 8. OVERFLOW
// -----------------------------------------------------------------------------
// By default integer arithmetic wraps around without error:
//   System.Int32.MaxValue + 1  ->  -2147483648
// For checked arithmetic that throws instead, open the Checked module:
//   open Microsoft.FSharp.Core.Operators.Checked


// -----------------------------------------------------------------------------
// 9. QUICK CHOICE GUIDE
// -----------------------------------------------------------------------------
// Counting, indexes, general whole numbers  -> int
// Very large whole numbers (ids, file sizes)-> int64
// Raw bytes, binary data                    -> byte
// Measurements, science, general fractions  -> float
// Money, exact decimal amounts              -> decimal
// Numbers bigger than int64                 -> bigint
