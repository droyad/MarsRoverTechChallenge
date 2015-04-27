module Format

open Types
open System

let rec format results = 
    let formatDirection d = 
        match d with 
        | North -> "N"
        | East -> "E"
        | South -> "S"
        | West -> "W"

    let formatResult (x,y,d) = sprintf "%d %d %s" x y (formatDirection d)
    let lines = List.map formatResult results
    String.Join("\r\n", lines)
