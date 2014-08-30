module Tests
open NUnit.Framework
open Kata
open System
[<TestFixture>]
type Add() =
    let calculator = StringCalculator()
    [<Test>]
    member x.``called with zero numbers (empty string) should return 0``() =
        Assert.AreEqual(0, calculator.Add "")

    [<TestCase("1",Result=1)>]
    [<TestCase("111",Result=111)>]
    member x.``called with one number should returns this number`` expression =
        calculator.Add expression

    [<TestCase("1,2",Result=3)>]
    [<TestCase("12,44",Result=56)>]
    member x.``called with two numbers should return their sum`` expression =
        calculator.Add expression

    [<TestCase("1,2,3,4,5,6,7,8,10,0,10",Result=56)>]
    [<TestCase("33,22,11",Result=66)>]
    member x.``called with any number of number should return their sum`` expression =
        calculator.Add expression

    [<TestCase("1\n2,3",Result=6)>]
    [<TestCase("1\n2,3,22\n11",Result=39)>]
    member x.``should handle \n and , as delimiter`` expression=
        calculator.Add expression

    [<TestCase("//;\n1;2",Result=3)>]
    member x.``//[delimiter]\n at the beggining of the expression should set new delimiter`` expression =
        calculator.Add expression

    [<TestCase("-3",ExpectedException=typeof<ArgumentException> ,ExpectedMessage="negatives not allowed\n-3" )>]
    member x.``called with negative number should throw exception "negatives not allowed"`` expression =
        calculator.Add expression |> ignore
   
    [<TestCase("1,2,3,1002,1200,123131,1",Result=7)>]
    [<TestCase("1000,1001,22",Result=1022)>]
    member x.``should ignore numbers above 1000`` expression =
        calculator.Add expression

    [<TestCase("//[***]\n1***2***3",Result=6)>]
    [<TestCase("//[//]\n1//2//3",Result=6)>]
    member x.``should handle delimiters longer than one character`` expression =
        calculator.Add expression

    [<TestCase("//[*][%]\n1*2%3",Result=6)>]
    member x.``should handle more than one delimiter`` expression =
        calculator.Add expression

    [<TestCase("//[***][%$]\n1%$2***3***14",Result=20)>]
    member x.``should handle more than one delimiter with length longer than one char`` expression =
        calculator.Add expression
