module FSharpRover

open System
open Types


let Run mover inputStr  = 

    let moveRobots (boardSize, instructions) = 
        let moveRobot (location, movements) = List.fold mover location movements
        List.map moveRobot instructions

    Parser.parse inputStr |> moveRobots |> Format.format

let Run1 inputStr = 
    let mover1 startLoc movement = 
        match movement with
        | Left -> match startLoc with
                        | (x,y,North) -> (x,y,West)
                        | (x,y,East) -> (x,y,North)
                        | (x,y,South) -> (x,y,East)
                        | (x,y,West) -> (x,y,South)
        | Right ->  match startLoc with
                        | (x,y,North) -> (x,y,East)
                        | (x,y,East) -> (x,y,South)
                        | (x,y,South) -> (x,y,West)
                        | (x,y,West) -> (x,y,North)
        | Forward -> match startLoc with
                        | (x,y,North) -> (x,y + 1,North)
                        | (x,y,East) -> (x + 1,y,East)
                        | (x,y,South) -> (x,y - 1,South)
                        | (x,y,West) -> (x-1,y,West)

    Run mover1 inputStr


let Run2 inputStr = 
    let mover2 (x,y,d) movement = 
        match (movement, d) with
                        | (Left, North)  -> (x,y,West)
                        | (Left, East) -> (x,y,North)
                        | (Left, South) -> (x,y,East)
                        | (Left, West) -> (x,y,South)
                        | (Right, North) -> (x,y,East)
                        | (Right, East)-> (x,y,South)
                        | (Right, South) -> (x,y,West)
                        | (Right, West)-> (x,y,North)
                        | (Forward, North) -> (x,y + 1,North)
                        | (Forward, East)-> (x + 1, y, East)
                        | (Forward, South) -> (x,y - 1, South)
                        | (Forward, West)-> (x-1,y,West)

    Run mover2 inputStr

    // This one would be the easiest to add field bound checking to
let Run3 inputStr = 
    let mover3 (x,y,d) movement = 
        let modX = match (movement, d) with
                        | (Forward, East) -> x + 1
                        | (Forward, West) -> x - 1
                        | _ -> x
        let modY = match (movement, d) with
                        | (Forward, North) -> y + 1
                        | (Forward, South) -> y - 1
                        | _ -> y
        let modD =  match (movement, d) with
                        | (Left, North)  -> West
                        | (Left, East) -> North
                        | (Left, South) -> East
                        | (Left, West) -> South
                        | (Right, North) -> East
                        | (Right, East)-> South
                        | (Right, South) -> West
                        | (Right, West)-> North
                        | _ -> d

        (modX, modY, modD)

    Run mover3 inputStr
