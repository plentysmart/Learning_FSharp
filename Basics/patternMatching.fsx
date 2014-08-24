
let boolConverter  x =
    match x with 
    | true -> "prawda"
    | false -> "falsz"
printfn "true: %s, false: %s" (boolConverter true) (boolConverter false)
// the same with "_"  wildcard

let boolConverterWildcard  x =
    match x with 
    | true -> "prawda"
    | _ -> "falsz"
printfn "true: %s, false: %s" (boolConverterWildcard true) (boolConverterWildcard false)

// the same but shorter
let boolConverterShort  x =
    match x with true -> "prawda" | _ -> "falsz"
printfn "true: %s, false: %s" (boolConverterShort true) (boolConverterShort false)


let boolreConverter x = 
    match x with 
    | "prawda"  -> true
    | "falsz" -> false
    | _ -> failwith "not found"

printfn "prawda: %b, falsz: %b" (boolreConverter(boolConverter true)) (boolreConverter(boolConverter false))

let boolreConverter2 x =
    match x with 
        | "prawda" | "Prawda" | "True" -> true
        | "falsz" | "Falsz" | "False" -> false
        | _ -> failwith "not found"
printfn "prawda: %b, Prawda: %b,True: %b," (boolreConverter2 "prawda") (boolreConverter2 "Prawda") (boolreConverter2 "True")

// multi argument matching
let customOr x y =
    match x,y with 
    | true, _ -> true // catches 1,0 and 1,1
    | _, true -> true // catches 0,1
    | _ -> false // the rest - 0,0
printfn " 1,0: %b \n 1,1: %b \n 0,1: %b\n 0,0: %b" (customOr true false) (customOr true true) (customOr false true) (customOr false false)

