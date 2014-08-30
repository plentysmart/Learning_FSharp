module Tests
open NUnit.Framework
open Kata
open System
[<TestFixture>]
type Add() =
    
    let calculator = StringCalculator()
    let verifyCalculator (parameter:string) (expected:int) = 
        let actual = calculator.Add parameter
        Assert.AreEqual(expected,actual)
    
    [<Test>]
    member x.``called with zero numbers (empty string) should return 0``() =
        verifyCalculator "" 0
    [<Test>]
    member x.``called with one number should returns this number``() =
        verifyCalculator "1" 1
    [<Test>]
    member x.``called with two numbers should return their sum``() =
        verifyCalculator "1,2" 3
    [<Test>]
    member x.``called with any number of number should return their sum``() =
        verifyCalculator "1,2,3,4,5,6,7,8,10,0,10" 56
    [<Test>]
    member x.``should handle \n and , as delimiter``() =
        verifyCalculator "1\n2,3" 6
    [<Test>]
    member x.``//[delimiter]\n at the beggining of the expression should set new delimiter``() =
        verifyCalculator "//;\n1;2" 3
    [<Test>]
    member x.``called with negative number should throw exception "negatives not allowed"``() =
        let exceptionThrown =
            try
                let result = calculator.Add "-3"
                false
            with
                | :? ArgumentException as x -> 
                    Assert.AreEqual("negatives not allowed\n-3",x.Message)
                    true
        Assert.IsTrue(exceptionThrown)