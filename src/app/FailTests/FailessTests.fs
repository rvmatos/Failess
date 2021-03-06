﻿open System
open Fuchu
open Failess
open System.Text.RegularExpressions

let tests = 
    testList "Failess tests" [ 
        testCase "Failess Test" <| 
            fun _ -> 
                Assert.Equal("Failess"
                    , ( try CSS ("custom.css") [
                                code @ Color.black
                                "/* When highlighted code blocks are too wide, they wrap. Resulting in the */"
                                "/* line numbers column's rows not lining up with the code rows. Prevent */"
                                "/* wrapping. */"
                                pre -|[
                                    whiteSpace  -- pre
                                    width       -- inh
                                ]
                            ]
                            "CSS: " + String.Join(System.Environment.NewLine
                                      , System.IO.File.ReadAllLines("custom.css"))
                            |> System.Console.WriteLine
                            true
                        with | _ -> false)
                    , true)
        ]

[<EntryPoint>]
let main _ = run tests