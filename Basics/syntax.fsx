
// let - declaration and assingment 
//  type infered
let variable_int = 4
let variable_string = "hello"
let variable_float = 12.3
// type specified
let variable:int = 22

// functions as first class objects
let add  x y = x+y
printfn "1+2 = %d" (add 1 2) 

let isEven x = 
    if x % 2=0 then
        true
    else
        false
printfn "Is 6 even? %b" (isEven 6)

