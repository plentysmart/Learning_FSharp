let emptyList = [] // emtpylist
printfn "emtpyList: %A" emptyList

let one = ["one"]
let two =  List.rev ("two" :: one)
let threeAndFour = ["three"; "four"]
let all = two @ threeAndFour // concatenating two lists
printfn "all: %A" all //all: ["one"; "two"; "three"; "four"]

// all elements in the list have to be of the same type
// you can always box them
// box operator http://msdn.microsoft.com/en-us/library/ee340516.aspx
let boxedlist = [ box 1; box true; box 12.2; box "bleh"]
printfn "boxedList: %A" boxedlist

let listOfLists = [[1;2;3];[3;4;5];[5;6;7]]

//patterns matching
let rec flattedList x = 
    match x with
    | head::tail -> head @ flattedList(tail)
    | [] -> []

printfn "listOfLists: %A \nflattedList: %A" (listOfLists) (flattedList(listOfLists))
