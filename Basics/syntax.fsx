
// let - declaration and assingment 
//  type infered
let identifer_int = 4
let identifer_string = "hello"
let identifer_float = 12.3
// type specified
let identifer:int = 22

// variable -> mutable
let mutable real_variable:int = 10
printfn "before: %d" real_variable
real_variable <- 15
printfn "after: %d" real_variable


// non standard identifer name
let ``let this be a crazy identifer name`` = @"literal string"
printfn "%s " ``let this be a crazy identifer name``

// functions as first class objects
let add  x y = x+y
printfn "1+2 = %d" (add 1 2) 

let isEven x = 
    if x % 2=0 then
        true
    else
        false
printfn "Is 6 even? %b" (isEven 6)

// Scope
let a = 10
let printer a = 
    printfn "printer a: %d" a //redefinition of the identifier inside the scoe
printer 20

let b = 111
let printer2 =
    printfn "printer2 before redefinition: %d" b // identifier from outer scope
    let b = 112 // redefinition of the identifier
    printfn "printer2 after redefinition: %d" b 
    // scope ends => b returns back to old definition
printer2
printfn "b after printer2: %d" b

let logger prefix = 
    let prefixFormatted = Printf.sprintf "[%s]: " prefix
    let logFunction  msg = Printf.sprintf "%s%s" prefixFormatted msg
    logFunction
let formatter = logger "SyntaxLearning"
printfn "%s" (formatter("Sample Message"))

// Recursion

let rec fib x =
    if x = 1 then
        1
    else if x = 2 then
        1
    else
        fib(x-1) + fib(x-2)
printfn "Fibonacci x=6: %d" (fib 6)

// Operators
// Operators are functions when surrounded by ()
let addFunction = (+)
printfn "1+2 = %d" (addFunction 1 2)

// Operators overloading
let (+) a b = a-b
printfn "1+2 = %d" (1 + 2) // Fun -> result - 1

//Piping operator definition let (|>) x y = y x

let pipingResult = 
     add 1 2
     |> add 3
     |> add 4
printfn "pipingResult = %d" pipingResult // should be 1+2+3+4 = 10

// usefull for passing results around i.e. filter |> map |> reduce
