namespace Kata
open System
type StringCalculator() = 
    let parseNumber (numberString:string) = 
        Int32.Parse(numberString)
    let defaultDelimiters = [|',';'\n'|]
    let extractDelimiters (stringExpression:string)= 
            let charListExpression =List.ofArray (stringExpression.ToCharArray())
            match charListExpression with
            |'/'::'/'::d::'\n'::tail -> 
                let rec skipUntilNewLine (stringList:char list)= 
                        match stringList with
                        | [] -> []
                        | '\n'::tail -> tail
                        | _::tail -> skipUntilNewLine tail
                let expressionOnlyList = skipUntilNewLine charListExpression
                [|d|],String(Array.ofList expressionOnlyList)
            |_ -> defaultDelimiters,stringExpression
    member x.Add(numbersExpression:string):int =
        let delimiters, expression = extractDelimiters numbersExpression
        let stringNumbers = List.ofArray (expression.Split (delimiters,StringSplitOptions.RemoveEmptyEntries ))
        if List.isEmpty stringNumbers then 
            0
        else
           let numbers = 
                stringNumbers
                    |> List.map parseNumber
           if List.exists (fun x -> x < 0) numbers then
                let negativeNumbers = numbers |> List.filter (fun x-> x< 0)
                let negativeArguments = String.Join("\n", negativeNumbers)
                let message = "negatives not allowed\n"+negativeArguments
                raise (ArgumentException(message))
            else
                numbers
                |> List.reduce (+)