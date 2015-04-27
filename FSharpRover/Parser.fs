module Parser

open System
open Types

let parse (input:string) = 
    let (|Int|_|) str =
        match System.Int32.TryParse(str) with
        | (true,int) -> Some(int)
        | _ -> None

    let (|Direction|_|) d = 
        match d with
        | "N" -> Some North
        | "E" -> Some East
        | "S" -> Some South
        | "W" -> Some West
        | _ -> None

    let (|Movement|_|) m = 
        match m with
        | 'L' -> Some Left
        | 'R' -> Some Right
        | 'M' -> Some Forward
        | _ -> None

    let rec (|MovementsC|_|) chars = 
        match chars with
        | Movement m :: MovementsC tail -> Some (m :: tail)
        | [] -> Some []
        | _ -> None

    let (|Movements|_|) (str:string) = 
        match List.ofArray (str.ToCharArray()) with
        | MovementsC m -> Some m
        | _ -> None

    let (|BoardSize|_|) (str:string) = 
        match str.Split ' ' with
        | [|Int x; Int y|] -> Some (x, y)
        | _ ->  None
    
    let (|Position|_|) (str:string) =
        match str.Split ' ' with
        | [|Int x; Int y; Direction d|] -> Some (x, y, d)
        | _ -> None

    let rec (|RobotInstructions|_|) lines = 
        match lines with
        | Position p :: Movements m :: RobotInstructions tail -> Some ((p, m) :: tail)
        | [] -> Some []
        | _ -> None

    let splitLines (str:string) = 
        let trim (s:string) = s.Trim();
        (input.Split '\r') |> List.ofArray |> List.map trim

    match splitLines input with
        | BoardSize l :: RobotInstructions i -> (l,i)
        | _ -> failwith "Invalid Input" 