namespace Kata
open System

type StringCalculator() = 
    let parseDelimiters (delimitersCommand:string)= 
        delimitersCommand.Split([|'[';']'|], StringSplitOptions.RemoveEmptyEntries)
    let split (delimiters:string[]) (expression:string) =
        expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
    let onlyNonNegative list =
        match List.partition (fun x -> x>=0) list with
        |_,[] -> list
        |_,x -> 
            let negativeNumbers = String.Join("\n",x)
            raise (ArgumentException("negatives not allowed\n"+negativeNumbers))
    member x.Add(calculatorExpression:string):int =
        let delimiters, expression = 
            if calculatorExpression.StartsWith("//") then
                let customDelimiters = 
                    calculatorExpression.Substring(2,calculatorExpression.IndexOf('\n')-2)
                    |> parseDelimiters 
                let remainingExpression = calculatorExpression.Substring(calculatorExpression.IndexOf('\n')+1)
                customDelimiters, remainingExpression
            else 
                [|",";"\n"|], calculatorExpression
    
        let splitNumbers = 
            expression
                |> split delimiters
        if splitNumbers.Length = 0 then
            0
        else
            splitNumbers
                |> List.ofArray
                |> List.map Int32.Parse
                |> onlyNonNegative
                |> List.filter (fun x -> x <= 1000)
                |> List.reduce (+)

        
            
       