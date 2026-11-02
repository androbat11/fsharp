// https://www.codewars.com/kata/5279f6fe5ab7f447890006a7/train/fsharp
// Problem:
// You will return the "peak" element,
// which means you will take the highest one.
// Basically I have to return an object containing the pos and peak

// Returned: { pos: [position], peaks: [values]}, 
// if empty, return { pos: [], peak: []}

// Questions:
// - What determines the peak?
// - 
let pickPeaks (items : int list) : PeakPositionInfo =
    { Pos = []; Peaks = [] }

